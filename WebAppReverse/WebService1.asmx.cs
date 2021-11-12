using System;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;

namespace WebAppReverse
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WebService1 : WebService
    {
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json, XmlSerializeString = false)]
        public string reverse(string data)
        {
            int n;                 
            if (int.TryParse(data, out n))
            {                
                var rtn = new
                {
                    result = Math.Sqrt(n)
                };
                return new JavaScriptSerializer().Serialize(rtn);
            }
            else 
            {
                char[] charArray = data.ToCharArray();
                Array.Reverse(charArray);
                var rtn = new
                {
                    result = new string(charArray)
                };
                return new JavaScriptSerializer().Serialize(rtn);
            }            
        }        
    }
}
