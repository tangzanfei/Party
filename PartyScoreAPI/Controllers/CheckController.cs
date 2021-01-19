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
    public class CheckController : ApiController
    {
        /// <summary>
        /// 前段login后，发送获得的code给后台，后台向微信服务器申请openid和sessionkey
        /// </summary>
        /// <param name="code"></param>
        //[Route("login/FFF")]
        [HttpPost]
        public BaseGetResponse<CheckResult> CheckByScanQrcode([FromUri] string code, [FromUri] string sessionkey)
        {
            var res = new BaseGetResponse<CheckResult>() { Code = -1, Msg = "没有这个打卡点", Data = null };

            //TODO:
            //1.检查是否有这个用户
            var user = UserRepository.FindUser(sessionkey);
            if (user==null)
            {
                res.Msg = "会话已过期，需要重新登录";
                res.Code = 1;
                return res;
            }
            //2.检查是否有这个二维码对应的打卡点
            //二维码以"BA_"开头的为支部活动
            if (code.StartsWith("BA_"))
            {
                var id = PointRepository.FindBranchActionID(code);
                if (id == null)
                {
                    return res;
                }
            }
            else
            {
                var point = PointRepository.FindPoint(code);
                if (point == null)
                {
                    return res;
                }
            }

            //3.打卡是否重复,不重复则写入数据库，重复则返回打卡失败
#warning 需要完善步骤

            //var resultModel = PointRepository.CheckByScanQrcode(code, sessionkey);

            return res;

        }

    }
}
