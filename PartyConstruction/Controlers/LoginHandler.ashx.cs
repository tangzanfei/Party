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

                string msg;
                if(CheckLogin(id, pwd, out msg))
                {

                }
                else
                {
                    response.Write(msg);
                }

            }
            catch (Exception e)
            {
                FileHelper.WriteLog(e);
                response.Write(e);
            }
        }


       
        bool CheckLogin(string id,string pwd,out string msg)
        {
            msg = "";
            var user = DbHelper.UserBLL.GetModelByAccount(id);
            if (user==null)
            {
                msg = "用户不存在";
                return false;
            }
            if (user.Password==pwd)
            {
                ServerHelper.LoginedAccount = user;

                return true;
            }
            else
            {
                msg = "密码错误";
                return false;

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