using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;

namespace ITJobs.UI
{
    public class SessionManager
    {
        private StateBag CurrentBag
        {
            get 
            {
                StateBag currentBag = HttpContext.Current.Session["ItSession"] as StateBag;
                if(currentBag == null)
                    HttpContext.Current.Session["ItSession"] = new StateBag();
                return HttpContext.Current.Session["ItSession"] as StateBag;
            }
        }


        public void AddToState(string key, object value)
        {
            CurrentBag.Add(key, value);
        }

        public object GetFromState(string key)
        {
            return CurrentBag[key];
        }

        public T GetFromState<T>(string key) where T:class
        {
            return GetFromState(key) as T;
        }

    }
}
