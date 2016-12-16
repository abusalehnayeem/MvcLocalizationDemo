using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Web;
using System.Web.Compilation;
using MvcLocalizationDemo.Models;

namespace MvcLocalizationDemo.ResourceProvider
{
    public abstract class BaseResourceProvider: IResourceProvider
    {
        public static Dictionary<string, ResourceEntry> Resources { get; set; } = null;
        public static object LockResources { get; } = new object();
        protected bool Cache { get; set; } // Cache resources ?

        public object GetObject(string resourceKey, CultureInfo culture)
        {
            if (string.IsNullOrEmpty(resourceKey) || string.IsNullOrWhiteSpace(resourceKey))
            {
                throw new ArgumentNullException(nameof(resourceKey));
            }

            var cultureName = culture?.Name ?? CultureInfo.CurrentUICulture.Name;

            cultureName = cultureName.ToLowerInvariant();

            if (!Cache || Resources != null) return null;
            lock (LockResources)
            {
                if (Resources != null) return null;
                var dictionary= ReadResources().ToDictionary(r => $"{r.Culture.ToLowerInvariant()}.{r.Name}");
                Resources = dictionary;
            }

            return Cache ? Resources[$"{cultureName}.{resourceKey}"].Value : ReadResource(resourceKey,cultureName).Value;
        }

        public IResourceReader ResourceReader { get; } = null;

        protected abstract IEnumerable<ResourceEntry> ReadResources();

        protected abstract ResourceEntry ReadResource(string name, string culture);
    }
}