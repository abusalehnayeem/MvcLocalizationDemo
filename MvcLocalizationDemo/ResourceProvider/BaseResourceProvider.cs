using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Web;
using System.Web.Compilation;

namespace MvcLocalizationDemo.ResourceProvider
{
    public abstract class BaseResourceProvider: IResourceProvider
    {
        public object GetObject(string resourceKey, CultureInfo culture)
        {
            return null;
        }

        public IResourceReader ResourceReader { get; }
    }
}