﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;
#if ASYNC
using System.Threading.Tasks; 
#endif
using MYOB.AccountRight.SDK.Communication;
using MYOB.AccountRight.SDK.Contracts;
using MYOB.AccountRight.SDK.Extensions;

namespace MYOB.AccountRight.SDK.Services
{
    /// <summary>
    /// Base service operations
    /// </summary>
    public abstract class ServiceBase
    {
        /// <exclude/>
        protected readonly IApiConfiguration Configuration;

        /// <exclude/>
        protected readonly IWebRequestFactory RequestFactory;
        private readonly IOAuthKeyService _keyService;
        private readonly IApiRequestHandlerFactory _apiRequestHandlerFactory;

        /// <summary>
        /// Initialise base instance
        /// </summary>
        /// <param name="configuration">The configuration required to communicate with the API service</param>
        /// <param name="webRequestFactory">A custom implementation of the <see cref="WebRequestFactory"/>, if one is not supplied a default <see cref="WebRequestFactory"/> will be used.</param>
        /// <param name="keyService">An implementation of a service that will store/persist the OAuth tokens required to communicate with the cloud based API at http://api.myob.com/accountright </param>
        /// <param name="apiRequestHandlerFactory">A custom implementation of the <see cref="IApiRequestHandlerFactory"/>, if one is not supplied a default <see cref="ApiRequestHandlerFactory"/> will be used.</param>
        protected ServiceBase(IApiConfiguration configuration, IWebRequestFactory webRequestFactory, IOAuthKeyService keyService, IApiRequestHandlerFactory apiRequestHandlerFactory)
        {
            Configuration = configuration;
            RequestFactory = webRequestFactory ?? WebRequestFactory.SharedWebRequestFactory ?? new WebRequestFactory(configuration);
            _keyService = keyService;
            _apiRequestHandlerFactory = apiRequestHandlerFactory ?? new ApiRequestHandlerFactory(); ;
        }

        private void WrapApiRequestWithOAuthRenew(Action<OAuthTokens> apiRequest, Action<Uri, Exception> onError)
        {
            if (_keyService != null && _keyService.OAuthResponse.Maybe(_ => _.HasExpired))
            {
                var oauth = new OAuthRequestHandler(Configuration);
                oauth.RenewOAuthTokens(RequestFactory.Create(OAuthRequestHandler.OAuthRequestUri),
                                       _keyService.OAuthResponse,
                                       (code, response) =>
                                           {
                                               _keyService.OAuthResponse = response;
                                               apiRequest(response);
                                           },
                                       onError);
            }
            else
            {
                apiRequest(_keyService.Maybe(_ => _.OAuthResponse));
            }
        }

#if ASYNC
        private async Task RenewOAuthTokensAsync(CancellationToken cancellationToken)
        {
            if (_keyService != null && _keyService.OAuthResponse.Maybe(_ => _.HasExpired))
            {
                var oauth = new OAuthRequestHandler(Configuration);
                var task = await oauth.RenewOAuthTokensAsync(this.RequestFactory.Create(OAuthRequestHandler.OAuthRequestUri), this._keyService.OAuthResponse, cancellationToken);
                _keyService.OAuthResponse = task.Item2;
            }
        } 
#endif

        /// <exclude/>
        protected void MakeApiGetRequestDelegate<T>(Uri uri, ICompanyFileCredentials credentials, Action<HttpStatusCode, T> onComplete, Action<Uri, Exception> onError, string eTag) where T : class
        {
            WrapApiRequestWithOAuthRenew(response =>
            {
                var api = _apiRequestHandlerFactory.GetApiRequestHandler(Configuration, credentials, response);
                api.Get(RequestFactory.Create(uri), onComplete, onError, eTag);
            }, onError);
        }

        /// <exclude/>
        protected void MakeApiGetRequestDelegateStream(Uri uri, string acceptEncoding, ICompanyFileCredentials credentials, Action<HttpStatusCode, Stream> onComplete, Action<Uri, Exception> onError)
        {
            WrapApiRequestWithOAuthRenew(response =>
            {
                var api = new ApiStreamRequestHandler(Configuration, credentials, response);
                api.Get(RequestFactory.Create(uri, acceptEncoding), onComplete, onError);
            }, onError);
        }
#if ASYNC
        /// <exclude/>
        protected Task<T> MakeApiGetRequestAsync<T>(Uri uri, ICompanyFileCredentials credentials, string eTag) where T : class
        {
            return this.MakeApiGetRequestAsync<T>(uri, credentials, CancellationToken.None, eTag);
        } 

        /// <exclude/>
        async protected Task<T> MakeApiGetRequestAsync<T>(Uri uri, ICompanyFileCredentials credentials, CancellationToken cancellationToken, string eTag) where T : class
        {
            await RenewOAuthTokensAsync(cancellationToken);
            var api = _apiRequestHandlerFactory.GetApiRequestHandler(Configuration, credentials, GetOAuthResponse());
            var data = await api.GetAsync<T>(this.RequestFactory.Create(uri), cancellationToken, eTag);
			return data.Item2;
        } 
#endif

#if ASYNC
        /// <exclude/>
        async protected Task<Stream> MakeApiGetRequestAsyncStream(Uri uri, string acceptEncoding, ICompanyFileCredentials credentials, CancellationToken cancellationToken, string eTag)
        {
            await RenewOAuthTokensAsync(cancellationToken);
            var api = new ApiStreamRequestHandler(Configuration, credentials, GetOAuthResponse());
            var data = await api.GetAsync(this.RequestFactory.Create(uri, acceptEncoding), cancellationToken);
            return data.Item2;
        }

        private OAuthTokens GetOAuthResponse()
        {
            return _keyService.Maybe(_ => _.OAuthResponse);
        }
#endif

        /// <exclude/>
        protected T MakeApiGetRequestSync<T>(Uri uri, ICompanyFileCredentials credentials, string eTag) where T : class
        {
            using (var wait = new AutoResetEvent(false))
            {
                Exception ex = null;
                var entity = default(T);
                var requestUri = default(Uri);

                MakeApiGetRequestDelegate<T>(
                    uri, credentials,
                    (code, data) =>
                    {
                        entity = data;
                        wait.Set();
                    },
                    (exUri, exception) =>
                    {
                        requestUri = exUri;
                        ex = exception;
                        wait.Set();
                    }, eTag);

                if (wait.WaitOne(new TimeSpan(0, 0, 0, 180)))
                {
                    ex.ProcessException(requestUri);
                }
                return entity;
            }
        }

        /// <exclude/>
        protected Stream MakeApiGetRequestSyncPdf(Uri uri, string acceptEncoding, ICompanyFileCredentials credentials)
        {
            using (var wait = new AutoResetEvent(false))
            {
                Exception ex = null;
                var entity = default(Stream);
                var requestUri = default(Uri);

                MakeApiGetRequestDelegateStream(
                    uri, acceptEncoding, credentials,
                    (code, data) =>
                    {
                        entity = data;
                        wait.Set();
                    },
                    (exUri, exception) =>
                    {
                        requestUri = exUri;
                        ex = exception;
                        wait.Set();
                    });

                if (wait.WaitOne(new TimeSpan(0, 0, 0, 180)))
                {
                    ex.ProcessException(requestUri);
                }

                return entity;
            }
        }

        /// <exclude/>
        protected void MakeApiDeleteRequestDelegate(Uri uri, ICompanyFileCredentials credentials, Action<HttpStatusCode> onComplete, Action<Uri, Exception> onError)
        {
            WrapApiRequestWithOAuthRenew(response =>
            {
                var api = _apiRequestHandlerFactory.GetApiRequestHandler(Configuration, credentials, response);
                api.Delete(RequestFactory.Create(uri), onComplete, onError);
            }, onError);
        }

#if ASYNC
        /// <exclude/>
        protected Task MakeApiDeleteRequestAsync(Uri uri, ICompanyFileCredentials credentials)
        {
            return this.MakeApiDeleteRequestAsync(uri, credentials, CancellationToken.None);
        } 

        /// <exclude/>
        async protected Task MakeApiDeleteRequestAsync(Uri uri, ICompanyFileCredentials credentials, CancellationToken cancellationToken)
        {
            await RenewOAuthTokensAsync(cancellationToken);

            var api = _apiRequestHandlerFactory.GetApiRequestHandler(Configuration, credentials, _keyService.Maybe(_ => _.OAuthResponse));
            await api.DeleteAsync(this.RequestFactory.Create(uri), cancellationToken);
        } 
#endif

        /// <exclude/>
        protected void MakeApiDeleteRequestSync(Uri uri, ICompanyFileCredentials credentials)
        {
            using (var wait = new AutoResetEvent(false))
            {
                Exception ex = null;
                var requestUri = default(Uri);

                MakeApiDeleteRequestDelegate(
                    uri, credentials,
                    (code) =>
                    {
                        wait.Set();
                    },
                    (exUri, exception) =>
                    {
                        requestUri = exUri;
                        ex = exception;
                        wait.Set();
                    });

                if (wait.WaitOne(new TimeSpan(0, 0, 0, 180)))
                {
                    ex.ProcessException(requestUri);
                }
            }
        }

        /// <exclude/>
        protected void MakeApiPostRequestDelegate<T>(Uri uri, T entity, ICompanyFileCredentials credentials, Action<HttpStatusCode, string> onComplete, Action<Uri, Exception> onError)
            where T : class
        {
            MakeApiPostRequestDelegate<T, T>(uri, entity, credentials, (code, s, response) => onComplete(code, s), onError);
        }

        /// <exclude/>
        protected void MakeApiPostRequestDelegate<TRequestEntity, TResponseEntity>(Uri uri, TRequestEntity entity, ICompanyFileCredentials credentials, 
            Action<HttpStatusCode, string, TResponseEntity> onComplete, Action<Uri, Exception> onError)
            where TRequestEntity : class
            where TResponseEntity : class
        {
            WrapApiRequestWithOAuthRenew(response =>
            {
                var api = _apiRequestHandlerFactory.GetApiRequestHandler(Configuration, credentials, response);
                api.Post(RequestFactory.Create(uri), entity, onComplete, onError);
            }, onError);
        }

#if ASYNC
        /// <exclude/>
        protected Task<string> MakeApiPostRequestAsync<T>(Uri uri, T entity, ICompanyFileCredentials credentials) where T : class
        {
            return this.MakeApiPostRequestAsync(uri, entity, credentials, CancellationToken.None);
        }

        /// <exclude/>
        async protected Task<string> MakeApiPostRequestAsync<T>(Uri uri, T entity, ICompanyFileCredentials credentials, CancellationToken cancellationToken) where T : class
        {
            await RenewOAuthTokensAsync(cancellationToken);
            var api = _apiRequestHandlerFactory.GetApiRequestHandler(Configuration, credentials, _keyService.Maybe(_ => _.OAuthResponse));
            var res = await api.PostAsync(this.RequestFactory.Create(uri), entity, cancellationToken);
            return res;
        }

        /// <exclude/>
        protected Task<TResponse> MakeApiPostRequestAsync<TRequest, TResponse>(Uri uri, TRequest entity, ICompanyFileCredentials credentials)
            where TRequest : class
            where TResponse : class
        {
            return this.MakeApiPostRequestAsync<TRequest, TResponse>(uri, entity, credentials, CancellationToken.None);
        }

        /// <exclude/>
        async protected Task<TResponse> MakeApiPostRequestAsync<TRequest, TResponse>(Uri uri, TRequest entity, ICompanyFileCredentials credentials, CancellationToken cancellationToken) 
            where TRequest : class
            where TResponse: class
        {
            await RenewOAuthTokensAsync(cancellationToken);
            var api = _apiRequestHandlerFactory.GetApiRequestHandler(Configuration, credentials, _keyService.Maybe(_ => _.OAuthResponse));
            var res = await api.PostAsync<TRequest, TResponse>(this.RequestFactory.Create(uri), entity, cancellationToken);
            return res;
        } 
#endif

        /// <exclude/>
        protected string MakeApiPostRequestSync<T>(Uri uri, T entity, ICompanyFileCredentials credentials) where T : class
        {
            return MakeApiPostRequestSync<T, T>(uri, entity, credentials).Key;
        }

        /// <exclude/>
        protected KeyValuePair<string, TResponse> MakeApiPostRequestSync<TRequest, TResponse>(Uri uri, TRequest entity, ICompanyFileCredentials credentials) 
            where TRequest : class
            where TResponse: class
        {
            using (var wait = new AutoResetEvent(false))
            {
                Exception ex = null;
                var requestUri = default(Uri);
                string retlocation = null;
                TResponse responseEntity = null;

                MakeApiPostRequestDelegate<TRequest, TResponse>(
                    uri, entity, credentials,
                    (code, location, response) =>
                    {
                        retlocation = location;
                        responseEntity = response;
                        wait.Set();
                    },
                    (exUri, exception) =>
                    {
                        requestUri = exUri;
                        ex = exception;
                        wait.Set();
                    });

                if (wait.WaitOne(new TimeSpan(0, 0, 0, 180)))
                {
                    ex.ProcessException(requestUri);
                }

                return new KeyValuePair<string, TResponse>(retlocation, responseEntity);
            }
        }

        /// <exclude/>
        protected void MakeApiPutRequestDelegate<T>(Uri uri, T entity, ICompanyFileCredentials credentials, Action<HttpStatusCode, string> onComplete, Action<Uri, Exception> onError)
            where T : class
        {
            MakeApiPutRequestDelegate<T, T>(uri, entity, credentials, (code, s, response) => onComplete(code, s), onError);
        }

        /// <exclude/>
        protected void MakeApiPutRequestDelegate<TRequest, TResponse>(Uri uri, TRequest entity, ICompanyFileCredentials credentials, Action<HttpStatusCode, string, TResponse> onComplete, Action<Uri, Exception> onError)
            where TRequest : class
            where TResponse : class
        {
            WrapApiRequestWithOAuthRenew(response =>
            {
                var api = _apiRequestHandlerFactory.GetApiRequestHandler(Configuration, credentials, response);
                api.Put(RequestFactory.Create(uri), entity, onComplete, onError);
            }, onError);
        }

#if ASYNC
        /// <exclude/>
        protected Task<string> MakeApiPutRequestAsync<T>(Uri uri, T entity, ICompanyFileCredentials credentials) where T : class
        {
            return this.MakeApiPutRequestAsync(uri, entity, credentials, CancellationToken.None);
        } 

        /// <exclude/>
        async protected Task<string> MakeApiPutRequestAsync<T>(Uri uri, T entity, ICompanyFileCredentials credentials, CancellationToken cancellationToken) where T : class
        {
            await RenewOAuthTokensAsync(cancellationToken);
            var api = _apiRequestHandlerFactory.GetApiRequestHandler(Configuration, credentials, _keyService.Maybe(_ => _.OAuthResponse));
            var res = await api.PutAsync(RequestFactory.Create(uri), entity, cancellationToken);
            return res;
        }

        /// <exclude/>
        protected Task<TResponse> MakeApiPutRequestAsync<TRequest, TResponse>(Uri uri, TRequest entity, ICompanyFileCredentials credentials) 
            where TRequest : class where TResponse : class
        {
            return this.MakeApiPutRequestAsync<TRequest, TResponse>(uri, entity, credentials, CancellationToken.None);
        }

        /// <exclude/>
        async protected Task<TResponse> MakeApiPutRequestAsync<TRequest, TResponse>(Uri uri, TRequest entity, ICompanyFileCredentials credentials, CancellationToken cancellationToken) 
            where TRequest : class where TResponse : class
        {
            await RenewOAuthTokensAsync(cancellationToken);
            var api = _apiRequestHandlerFactory.GetApiRequestHandler(Configuration, credentials, _keyService.Maybe(_ => _.OAuthResponse));
            var res = await api.PutAsync<TRequest, TResponse>(RequestFactory.Create(uri), entity, cancellationToken);
            return res;
        } 
#endif

        /// <exclude/>
        protected string MakeApiPutRequestSync<T>(Uri uri, T entity, ICompanyFileCredentials credentials) where T : class
        {
            return MakeApiPutRequestSync<T, T>(uri, entity, credentials).Key;
        }

        /// <exclude/>
        protected KeyValuePair<string, TResponse> MakeApiPutRequestSync<TRequest, TResponse>(Uri uri, TRequest entity,
            ICompanyFileCredentials credentials)
            where TRequest : class
            where TResponse : class
        {
            using (var wait = new AutoResetEvent(false))
            {
                Exception ex = null;
                var requestUri = default(Uri);
                string retlocation = null;
                TResponse responseEntity = null;

                MakeApiPutRequestDelegate<TRequest, TResponse>(
                    uri, entity, credentials,
                    (code, location, response) =>
                    {
                        retlocation = location;
                        responseEntity = response;
                        wait.Set();
                    },
                    (exUri, exception) =>
                    {
                        requestUri = exUri;
                        ex = exception;
                        wait.Set();
                    });

                if (wait.WaitOne(new TimeSpan(0, 0, 0, 180)))
                {
                    ex.ProcessException(requestUri);
                }

                return new KeyValuePair<string, TResponse>(retlocation, responseEntity);
            }
        }
    }
}
