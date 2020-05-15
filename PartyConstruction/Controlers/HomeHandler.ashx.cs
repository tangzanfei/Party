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
                Dictionary<string, object> responseData = new Dictionary<string, object>();
                string strjson;
                if (context.Session["LoginedUser"] == null)
                {
                    responseData.Add("result", false);
                    responseData.Add("msg", "Unlogin");
                    strjson = JsonHelper.ObjectToJSON(responseData);
                    response.Write(strjson);
                    return;
                }
                DBUser user = context.Session["LoginedUser"] as DBUser;
                DBBranch myBranch = null, myservingBranch = null;

                var myUser = ModelConvertHelper.DBToModel(user);
                //User user2 = (User)myUser.Copy();
                //if (!string.IsNullOrEmpty(user.BranchID))
                //{
                //    myBranch = DbHelper.BranchBLL.GetModel(user.BranchID);
                //}
                //if (!string.IsNullOrEmpty(user.ServicingBranchID))
                //{
                //    myservingBranch = DbHelper.BranchBLL.GetModel(user.ServicingBranchID);
                //}

                switch (cmd)
                {
                    case "GetUser":
                        responseData.Add("result", true);
                        responseData.Add("user", myUser);
                        strjson= JsonHelper.ObjectToJSON(responseData);
                        response.Write(strjson);
                        break;
                    case "GetScoreTop":
                        if (!string.IsNullOrEmpty(user.BranchID))
                        {
                            //myBranch = DbHelper.BranchBLL.GetModel(user.BranchID);
                        }
                        var strSql = string.Format("BranchID=\"{0}\"", user.BranchID);
                        var userlist = DbHelper.UserBLL.GetModelList(strSql);

                        responseData.Add("result", true);
                        responseData.Add("userlist", userlist.OrderByDescending(u=>u.Score));

                        strjson = JsonHelper.ObjectToJSON(responseData);
                        response.Write(strjson);
                        break;
                    default:
                        responseData.Add("result", false);
                        responseData.Add("msg", "UnknowCMD");
                        strjson = JsonHelper.ObjectToJSON(responseData);
                        response.Write(strjson);

                        break;
                }
            }
            catch (Exception e)
            {
                FileHelper.WriteLog(e);
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