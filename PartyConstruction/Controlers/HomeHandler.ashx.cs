using PartyConstruction.Helper;
using PartyConstruction.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartyConstruction.Controlers
{
    /// <summary>
    /// HomeHandler 的摘要说明
    /// </summary>
    public class HomeHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            var request = context.Request;
            var response = context.Response;
            try
            {
                string cmd = context.Request.Form["CMD"];
                string param1 = context.Request.Form["param1"];
                if (context.Session["LoginedUser"] == null)
                {
                    response.Write("Unlogin");
                    return;
                }
                switch (cmd)
                {
                    case "GetUser":
                        DBUser user = context.Session["LoginedUser"] as DBUser;
                        Dictionary<string, object> responseData = new Dictionary<string, object>();
                        responseData.Add("result", "ok");
                        responseData.Add("user", user);
                        string strjson= JsonHelper.ObjectToJSON(responseData);
                        response.Write(strjson);
                        break;
                    default:
                        response.Write("UnknowCMD");
                        break;
                }
            }
            catch (Exception e)
            {
                FileHelper.WriteLog(e);
                response.Write(e);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}