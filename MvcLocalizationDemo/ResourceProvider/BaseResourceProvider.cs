using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Web.Compilation;
using MvcLocalizationDemo.DTO;
using MvcLocalizationDemo.Models;

namespace MvcLocalizationDemo.ResourceProvider
{
    public abstract class BaseResourceProvider : IResourceProvider
    {
        public object GetObject(string resourceKey, CultureInfo culture)
        {
            if (string.IsNullOrEmpty(resourceKey) || string.IsNullOrWhiteSpace(resourceKey))
            {
                throw new ArgumentNullException(nameof(resourceKey));
            }
            return ReadResource(resourceKey, culture).Value;
        }

        public IResourceReader ResourceReader { get; } = null;

        protected abstract ResourceEntry ReadResource(string name, CultureInfo culture);
    }
}