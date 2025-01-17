﻿using PartyConstruction.DBUtility;
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
    public class LoginHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            var request = context.Request;
            var response = context.Response;
            int i = 0;

            //String ip = request.getHeader("X-Forwarded-For");
            //if (StringUtils.isNotEmpty(ip) && !"unKnow".equalsIgnoreCase(ip))
            //{
            //    //多次反向代理后会有多个ip值，第一个ip才是真实ip
            //    String[] ipList = ip.split(",");
            //    ip = ipList[0];
            //}
            //else
            //{
            //    ip = request.getHeader("X-Real-IP");
            //    if (StringUtils.isEmpty(ip) || "unKnown".equalsIgnoreCase(ip))
            //    {
            //        ip = request.getRemoteAddr();
            //    }
            //}

            try
            {
                string id = request["ID"];
                string pwd = request["PWD"];

                if (string.IsNullOrEmpty(id))
                {
                    response.Redirect("..\\Login.html");
                }
                string msg;
                if(CheckLogin(id, pwd, out msg,out DBUser user))
                {
                    //string sessionID = "";
                    //if (request.Cookies["sessionID"] == null)
                    //{
                    //    sessionID = context.Session.SessionID;                        
                    //    request.Cookies.Add(new HttpCookie("sessionID", sessionID) { Expires = DateTime.Now.AddMinutes(30) });
                    //}
                    //sessionID = request["sessionID"];
                    //if (ServerHelper.SessionDic.ContainsKey(sessionID))
                    //{
                    //    //已经有记录
                    //    //跳转主页
                    //}
                    //else
                    //{
                    //    //没有记录
                    //    //记录再跳转主页
                    //    ServerHelper.SessionDic.Add(sessionID, context.Session);
                    //}
                    //ServerHelper.SessionDic[sessionID]["LoginedUser"] = user;
                    context.Session["LoginedUser"] = user;
                    response.Write("ok");
                }
                else
                {
                    response.Write(msg);
                }

            }
            catch (Exception e)
            {
                FileHelper.WriteLog(e);
                response.Write(e.Message);
            }
        }


       
        bool CheckLogin(string id,string pwd,out string msg,out DBUser user)
        {
            msg = "";
            user = DbHelper.UserBLL.GetModelByAccount(id);
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