using System;
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
        protected readonly IWebRequestFactory WebRequestFactory;
        private readonly IOAuthKeyService _keyService;

        /// <summary>
        /// Initialise base instance
        /// </summary>
        /// <param name="configuration">The configuration required to communicate with the API service</param>
        /// <param name="webRequestFactory">A custom implementation of the <see cref="WebRequestFactory"/>, if one is not supplied a default <see cref="WebRequestFactory"/> will be used.</param>
        /// <param name="keyService">An implementation of a service that will store/persist the OAuth tokens required to communicate with the cloud based API at http://api.myob.com/accountright </param>
        protected ServiceBase(IApiConfiguration configuration, IWebRequestFactory webRequestFactory, IOAuthKeyService keyService)
        {
            Configuration = configuration;
            WebRequestFactory = webRequestFactory ?? new WebRequestFactory();
            _keyService = keyService;
        }

        private void WrapApiRequestWithOAuthRenew(Action<OAuthTokens> apiRequest, Action<Uri, Exception> onError)
        {
            if (_keyService != null && _keyService.OAuthResponse.Maybe(_ => _.HasExpired))
            {
                var oauth = new OAuthRequestHandler(Configuration);
                oauth.RenewOAuthTokens(WebRequestFactory.Create(OAuthRequestHandler.OAuthRequestUri),
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
        private async Task RenewOAuthTokensAsync()
        {
            if (_keyService != null && _keyService.OAuthResponse.Maybe(_ => _.HasExpired))
            {
                var oauth = new OAuthRequestHandler(Configuration);
                var task = await oauth.RenewOAuthTokensAsync(WebRequestFactory.Create(OAuthRequestHandler.OAuthRequestUri), _keyService.OAuthResponse);
                _keyService.OAuthResponse = task.Item2;
            }
        } 
#endif

        /// <exclude/>
        protected void MakeApiGetRequestDelegate<T>(Uri uri, ICompanyFileCredentials credentials, Action<HttpStatusCode, T> onComplete, Action<Uri, Exception> onError) where T : class
        {
            WrapApiRequestWithOAuthRenew(response =>
            {
                var api = new ApiRequestHandler(Configuration, credentials, response);
                api.Get(WebRequestFactory.Create(uri), onComplete, onError);
            }, onError);
        }

        /// <exclude/>
        protected void MakeApiGetRequestDelegateStream(Uri uri, string acceptEncoding, ICompanyFileCredentials credentials, Action<HttpStatusCode, Stream> onComplete, Action<Uri, Exception> onError)
        {
            WrapApiRequestWithOAuthRenew(response =>
            {
                var api = new ApiStreamRequestHandler(Configuration, credentials, response);
                api.Get(WebRequestFactory.Create(uri, acceptEncoding), onComplete, onError);
            }, onError);
        }
#if ASYNC
        /// <exclude/>
        async protected Task<T> MakeApiGetRequestAsync<T>(Uri uri, ICompanyFileCredentials credentials) where T : class
        {
            await RenewOAuthTokensAsync();
            var api = new ApiRequestHandler(Configuration, credentials, GetOAuthResponse());
            var data = await api.GetAsync<T>(WebRequestFactory.Create(uri));
            return data.Item2;
        } 
#endif

#if ASYNC
        /// <exclude/>
        async protected Task<Stream> MakeApiGetRequestAsyncStream(Uri uri, string acceptEncoding, ICompanyFileCredentials credentials)
        {
            await RenewOAuthTokensAsync();
            var api = new ApiStreamRequestHandler(Configuration, credentials, GetOAuthResponse());
            var data = await api.GetAsync(WebRequestFactory.Create(uri, acceptEncoding));
            return data.Item2;
        }

        private OAuthTokens GetOAuthResponse()
        {
            return _keyService.Maybe(_ => _.OAuthResponse);
        }
#endif

        /// <exclude/>
        protected T MakeApiGetRequestSync<T>(Uri uri, ICompanyFileCredentials credentials, Action<HttpWebRequest> transform = null) where T : class
        {
            var wait = new AutoResetEvent(false);
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
                    });

            if (wait.WaitOne(new TimeSpan(0, 0, 0, 60)))
            {
                ex.ProcessException(requestUri);
            }

            return entity;
        }

        /// <exclude/>
        protected Stream MakeApiGetRequestSyncPdf(Uri uri, string acceptEncoding, ICompanyFileCredentials credentials)
        {
            var wait = new AutoResetEvent(false);
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

            if (wait.WaitOne(new TimeSpan(0, 0, 0, 60)))
            {
                ex.ProcessException(requestUri);
            }

            return entity;
        }

        /// <exclude/>
        protected void MakeApiDeleteRequestDelegate(Uri uri, ICompanyFileCredentials credentials, Action<HttpStatusCode> onComplete, Action<Uri, Exception> onError)
        {
            WrapApiRequestWithOAuthRenew(response =>
            {
                var api = new ApiRequestHandler(Configuration, credentials, response);
                api.Delete(WebRequestFactory.Create(uri), onComplete, onError);
            }, onError);
        }

#if ASYNC
        /// <exclude/>
        async protected Task MakeApiDeleteRequestAsync(Uri uri, ICompanyFileCredentials credentials)
        {
            await RenewOAuthTokensAsync().ContinueWith(async t =>
                {
                    var api = new ApiRequestHandler(Configuration, credentials, _keyService.Maybe(_ => _.OAuthResponse));
                    await api.DeleteAsync(WebRequestFactory.Create(uri));
                });
        } 
#endif

        /// <exclude/>
        protected void MakeApiDeleteRequestSync(Uri uri, ICompanyFileCredentials credentials)
        {
            var wait = new AutoResetEvent(false);
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

            if (wait.WaitOne(new TimeSpan(0, 0, 0, 60)))
            {
                ex.ProcessException(requestUri);
            }
        }

        /// <exclude/>
        protected void MakeApiPostRequestDelegate<T>(Uri uri, T entity, ICompanyFileCredentials credentials, Action<HttpStatusCode, string> onComplete, Action<Uri, Exception> onError)
            where T : class
        {
            MakeApiPostRequestDelegate<T, T>(uri, entity, credentials, (code, s, response) => onComplete(code, s), onError);
        }

        /// <exclude/>
        protected void MakeApiPostRequestDelegate<TRequestEntity, TResponseEntity>(Uri uri, TRequestEntity entity, ICompanyFileCredentials credentials, Action<HttpStatusCode, string, TResponseEntity> onComplete, Action<Uri, Exception> onError)
            where TRequestEntity : class
            where TResponseEntity : class
        {
            WrapApiRequestWithOAuthRenew(response =>
            {
                var api = new ApiRequestHandler(Configuration, credentials, response);
                api.Post(WebRequestFactory.Create(uri), entity, onComplete, onError);
            }, onError);
        }

#if ASYNC
        /// <exclude/>
        async protected Task<string> MakeApiPostRequestAsync<T>(Uri uri, T entity, ICompanyFileCredentials credentials) where T : class
        {
            await RenewOAuthTokensAsync();
            var api = new ApiRequestHandler(Configuration, credentials, _keyService.Maybe(_ => _.OAuthResponse));
            var res = await api.PostAsync(WebRequestFactory.Create(uri), entity);
            return res;
        }

        /// <exclude/>
        async protected Task<TResponse> MakeApiPostRequestAsync<TRequest, TResponse>(Uri uri, TRequest entity, ICompanyFileCredentials credentials) 
            where TRequest : class
            where TResponse: class
        {
            await RenewOAuthTokensAsync();
            var api = new ApiRequestHandler(Configuration, credentials, _keyService.Maybe(_ => _.OAuthResponse));
            var res = await api.PostAsync<TRequest, TResponse>(WebRequestFactory.Create(uri), entity);
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
            var wait = new AutoResetEvent(false);
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

            if (wait.WaitOne(new TimeSpan(0, 0, 0, 60)))
            {
                ex.ProcessException(requestUri);
            }

            return new KeyValuePair<string, TResponse>(retlocation, responseEntity);
        }

        /// <exclude/>
        protected void MakeApiPutRequestDelegate<T>(Uri uri, T entity, ICompanyFileCredentials credentials, Action<HttpStatusCode, string> onComplete, Action<Uri, Exception> onError)
            where T : class
        {
            WrapApiRequestWithOAuthRenew(response =>
            {
                var api = new ApiRequestHandler(Configuration, credentials, response);
                api.Put(WebRequestFactory.Create(uri), entity, onComplete, onError);
            }, onError);
        }

#if ASYNC
        /// <exclude/>
        async protected Task<string> MakeApiPutRequestAsync<T>(Uri uri, T entity, ICompanyFileCredentials credentials) where T : class
        {
            await RenewOAuthTokensAsync();
            var api = new ApiRequestHandler(Configuration, credentials, _keyService.Maybe(_ => _.OAuthResponse));
            var res = await api.PutAsync(WebRequestFactory.Create(uri), entity);
            return res;
        } 
#endif

        /// <exclude/>
        protected string MakeApiPutRequestSync<T>(Uri uri, T entity, ICompanyFileCredentials credentials) where T : class
        {
            var wait = new AutoResetEvent(false);
            Exception ex = null;
            var requestUri = default(Uri);
            string retlocation = null;

            MakeApiPutRequestDelegate(
                uri, entity, credentials,
                (code, location) =>
                    {
                        retlocation = location;
                        wait.Set();
                    },
                (exUri, exception) =>
                    {
                        requestUri = exUri;
                        ex = exception;
                        wait.Set();
                    });

            if (wait.WaitOne(new TimeSpan(0, 0, 0, 60)))
            {
                ex.ProcessException(requestUri);
            }

            return retlocation;
        }

    }
}
