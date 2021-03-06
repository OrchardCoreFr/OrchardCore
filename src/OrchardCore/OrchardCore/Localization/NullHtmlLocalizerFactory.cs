using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.Localization;

namespace OrchardCore.Localization
{
    /// <remarks>
    /// LocalizedHtmlString's arguments will be HTML encoded and not the main string. So the result
    /// should just contained the localized string containing the formatting placeholders {0...} as is.
    /// </remarks>
    public class NullHtmlLocalizerFactory : IHtmlLocalizerFactory
    {
        public IHtmlLocalizer Create(string baseName, string location) => NullLocalizer.Instance;

        public IHtmlLocalizer Create(Type resourceSource) => NullLocalizer.Instance;

        private class NullLocalizer : IHtmlLocalizer
        {
            private static readonly PluralizationRuleDelegate _defaultPluralRule = n => (n == 1) ? 0 : 1;

            public static NullLocalizer Instance { get; } = new NullLocalizer();

            public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
                => Enumerable.Empty<LocalizedString>();

            public LocalizedHtmlString this[string name] => new LocalizedHtmlString(name, name, true);

            public LocalizedHtmlString this[string name, params object[] arguments]
            {
                get
                {
                    var translation = name;

                    if (arguments.Length == 1 && arguments[0] is PluralizationArgument pluralArgument)
                    {
                        translation = pluralArgument.Forms[_defaultPluralRule(pluralArgument.Count)];

                        arguments = new object[pluralArgument.Arguments.Length + 1];
                        arguments[0] = pluralArgument.Count;
                        Array.Copy(pluralArgument.Arguments, 0, arguments, 1, pluralArgument.Arguments.Length);
                    }

                    return new LocalizedHtmlString(name, translation, false, arguments);
                }
            }

            public LocalizedString GetString(string name) =>
                NullStringLocalizerFactory.NullLocalizer.Instance.GetString(name);

            public LocalizedString GetString(string name, params object[] arguments) =>
                NullStringLocalizerFactory.NullLocalizer.Instance.GetString(name, arguments);

            IHtmlLocalizer IHtmlLocalizer.WithCulture(CultureInfo culture) => Instance;
        }
    }
}
