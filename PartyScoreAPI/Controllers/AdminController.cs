using PartyScoreAPI.Models;
using PartyScoreAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PartyScoreAPI.Controllers
{
    public class AdminController : ApiController
    {
        /// <summary>
        /// 前段login后，发送获得的code给后台，后台向微信服务器申请openid和sessionkey
        /// </summary>
        /// <param name="code"></param>
        [HttpPost]
        public BaseGetResponse<CheckResult> LanchAction([FromUri] string sessionkey)
        {
            var res = new BaseGetResponse<CheckResult>() { Code = -1, Msg = "没有这个打卡点", Data = null };


            return res;

        }

    }
}