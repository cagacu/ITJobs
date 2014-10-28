using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITJobs.Resource
{
    public class ResourceHelper
    {
        public static string GetText(string key)
        {
            object returnValue = ITJobs.Util.GlobalResource.ResourceManager.GetObject(key);
            if (returnValue == null)
                returnValue = key;
            return returnValue.ToString();
        }

    }
}
