using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Compilation;
using MvcLocalizationDemo.Data;

namespace MvcLocalizationDemo.ResourceProvider
{
    public class Resources
    {
        private static readonly IResourceProvider _resourceProvider= new SqlResourceProvider();

        public static string Name
        {
            get { return _resourceProvider.GetObject("Name", CultureInfo.CurrentUICulture) as string; }
        }

        public static string Title
        {
            get { return _resourceProvider.GetObject("Title", CultureInfo.CurrentUICulture) as string; }
        }

        public static string Department
        {
            get { return _resourceProvider.GetObject("Department", CultureInfo.CurrentUICulture) as string; }
        }
    }
}