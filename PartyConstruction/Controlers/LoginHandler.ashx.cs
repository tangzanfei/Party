using PartyConstruction.DBUtility;
using PartyConstruction.Helper;
using PartyConstruction.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartyConstruction.Controlers
{
    /// <summary>
    /// LoginHandler 的摘要说明
    /// </summary>
    public class LoginHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            var request = context.Request;
            var response = context.Response;
            try
            {
                string id = request["ID"];
                string pwd = request["PWD"];
                //DBUser user = new DBUser();
                //user.ID = Guid.NewGuid().ToString();
                //user.Account = id;
                //user.Password = pwd;
                

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