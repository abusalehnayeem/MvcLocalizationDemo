using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcLocalizationDemo.Controllers
{
    public class BaseController : Controller
    {
        protected override void Initialize(RequestContext requestContext)
        {
            var languages = requestContext?.HttpContext.Request.UserLanguages;
            if (languages == null)
            {
                return;
            }
            foreach (var lang in languages.Select(language => language.ToLowerInvariant().Trim()))
            {
                try
                {
                    Thread.CurrentThread.CurrentCulture=Thread.CurrentThread.CurrentUICulture=CultureInfo.GetCultureInfo(lang);
                }
                catch (CultureNotFoundException)
                {
                }
            }
            base.Initialize(requestContext);
        }

        protected override bool DisableAsyncSupport => true;
    }
}