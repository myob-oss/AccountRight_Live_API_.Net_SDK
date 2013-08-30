using System;
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
    public abstract class ServiceBase
    {
        protected readonly IApiConfiguration Configuration;
        protected readonly IWebRequestFactory WebRequestFactory;
        private readonly IOAuthKeyService _keyService;

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

        protected void MakeApiGetRequestDelegate<T>(Uri uri, ICompanyFileCredentials credentials, Action<HttpStatusCode, T> onComplete, Action<Uri, Exception> onError) where T : class
        {
            WrapApiRequestWithOAuthRenew(response =>
            {
                var api = new ApiRequestHandler(Configuration, credentials, response);
                api.Get(WebRequestFactory.Create(uri), onComplete, onError);
            }, onError);
        }

#if ASYNC
        async protected Task<T> MakeApiGetRequestAsync<T>(Uri uri, ICompanyFileCredentials credentials) where T : class
        {
            return await RenewOAuthTokensAsync().ContinueWith(async t =>
                {
                    var api = new ApiRequestHandler(Configuration, credentials, _keyService.Maybe(_ => _.OAuthResponse));
                    var data = await api.GetAsync<T>(WebRequestFactory.Create(uri));
                    return data.Item2;
                }).Result;
        } 
#endif

        protected T MakeApiGetRequestSync<T>(Uri uri, ICompanyFileCredentials credentials) where T : class
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

        
        protected void MakeApiDeleteRequestDelegate(Uri uri, ICompanyFileCredentials credentials, Action<HttpStatusCode> onComplete, Action<Uri, Exception> onError)
        {
            WrapApiRequestWithOAuthRenew(response =>
            {
                var api = new ApiRequestHandler(Configuration, credentials, response);
                api.Delete(WebRequestFactory.Create(uri), onComplete, onError);
            }, onError);
        }

#if ASYNC
        async protected Task MakeApiDeleteRequestAsync(Uri uri, ICompanyFileCredentials credentials)
        {
            await RenewOAuthTokensAsync().ContinueWith(async t =>
                {
                    var api = new ApiRequestHandler(Configuration, credentials, _keyService.Maybe(_ => _.OAuthResponse));
                    await api.DeleteAsync(WebRequestFactory.Create(uri));
                });
        } 
#endif

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

        protected void MakeApiPostRequestDelegate<T>(Uri uri, T entity, ICompanyFileCredentials credentials, Action<HttpStatusCode, string> onComplete, Action<Uri, Exception> onError) 
            where T : class
        {
            WrapApiRequestWithOAuthRenew(response =>
            {
                var api = new ApiRequestHandler(Configuration, credentials, response);
                api.Post(WebRequestFactory.Create(uri), entity, onComplete, onError);
            }, onError);
        }

#if ASYNC
        async protected Task<string> MakeApiPostRequestAsync<T>(Uri uri, T entity, ICompanyFileCredentials credentials) where T : class
        {
            return await RenewOAuthTokensAsync().ContinueWith(async t =>
                {
                    var api = new ApiRequestHandler(Configuration, credentials, _keyService.Maybe(_ => _.OAuthResponse));
                    var res = await api.PostAsync(WebRequestFactory.Create(uri), entity);
                    return res;
                }).Result;
        } 
#endif

        protected string MakeApiPostRequestSync<T>(Uri uri, T entity, ICompanyFileCredentials credentials) where T : class
        {
            var wait = new AutoResetEvent(false);
            Exception ex = null;
            var requestUri = default(Uri);
            string retlocation = null;

            MakeApiPostRequestDelegate(
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
        async protected Task<string> MakeApiPutRequestAsync<T>(Uri uri, T entity, ICompanyFileCredentials credentials) where T : class
        {
            return await RenewOAuthTokensAsync().ContinueWith(async t =>
                {
                    var api = new ApiRequestHandler(Configuration, credentials, _keyService.Maybe(_ => _.OAuthResponse));
                    var res = await api.PutAsync(WebRequestFactory.Create(uri), entity);
                    return res;
                }).Result;
        } 
#endif

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