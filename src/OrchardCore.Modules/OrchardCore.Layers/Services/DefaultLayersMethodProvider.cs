using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Scripting;

namespace OrchardCore.Layers.Services
{
    public class DefaultLayersMethodProvider : IGlobalMethodProvider
    {
        private readonly GlobalMethod _isHomepage;
        private readonly GlobalMethod _isAnonymous;
        private readonly GlobalMethod _isAuthenticated;
        private readonly GlobalMethod _url;
        private readonly GlobalMethod _culture;

        private readonly GlobalMethod[] _allMethods;

        public DefaultLayersMethodProvider()
        {
            _isHomepage = new GlobalMethod
            {
                Name = "isHomepage",
                Method = serviceProvider => (Func<bool>)(() =>
                {
                    var httpContext = serviceProvider.GetRequiredService<IHttpContextAccessor>().HttpContext;
                    var requestPath = httpContext.Request.Path;
                    return requestPath == "/" || string.IsNullOrEmpty(requestPath);
                })
            };

            _isAnonymous = new GlobalMethod
            {
                Name = "isAnonymous",
                Method = serviceProvider => (Func<bool>)(() =>
                {
                    var httpContext = serviceProvider.GetRequiredService<IHttpContextAccessor>().HttpContext;
                    return httpContext.User?.Identity.IsAuthenticated != true;
                })
            };

            _isAuthenticated = new GlobalMethod
            {
                Name = "isAuthenticated",
                Method = serviceProvider => (Func<bool>)(() =>
                {
                    var httpContext = serviceProvider.GetRequiredService<IHttpContextAccessor>().HttpContext;
                    return httpContext.User?.Identity.IsAuthenticated == true;
                })
            };

            _url = new GlobalMethod
            {
                Name = "url",
                Method = serviceProvider => (Func<string, bool>)(url =>
                {
                    if (url.StartsWith("~/"))
                        url = url.Substring(1);

                    var httpContext = serviceProvider.GetRequiredService<IHttpContextAccessor>().HttpContext;
                    string requestPath = httpContext.Request.Path;

                    // Tenant home page could have an empty string as a request path, where
                    // the default tenant does not.
                    if (string.IsNullOrEmpty(requestPath))
                        requestPath = "/";

                    return url.EndsWith("*")
                        ? requestPath.StartsWith(url.TrimEnd('*'), StringComparison.OrdinalIgnoreCase)
                        : string.Equals(requestPath, url, StringComparison.OrdinalIgnoreCase);
                })
            };

            _culture = new GlobalMethod
            {
                Name = "culture",
                Method = serviceProvider => (Func<string, bool>)(culture =>
                {
                    var currentCulture = CultureInfo.CurrentCulture;

                    return string.Equals(culture, currentCulture.Name, StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(culture, currentCulture.Parent.Name, StringComparison.OrdinalIgnoreCase);
                })
            };

            _allMethods = new[] { _isAnonymous, _isAuthenticated, _isHomepage, _url, _culture };
        }

        public IEnumerable<GlobalMethod> GetMethods()
        {
            return _allMethods;
        }
    }
}
