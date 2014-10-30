using ITJobs.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ITJobs.UI
{
    public static class HtmlHelperExtension
    {
        public static IHtmlString Submit(this HtmlHelper htmlHelper, string resourceKey)
        {
            return new HtmlString(String.Format("<input type='submit' value='{0}' />",ResourceHelper.GetText(resourceKey)));
        }


    }
}
