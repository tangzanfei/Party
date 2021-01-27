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
    public class ScoreController : ApiController
    {
        public BaseGetResponse<List<CheckResult>> GetThisMounthSignData(string   sessionkey)
        {
            var res = new BaseGetResponse<List<CheckResult>>() { Code = -1, Msg = "未知错误", Data = null };

            //TODO:
            //1.检查是否有这个用户
            var user = UserRepository.FindUser(sessionkey);
            if (user == null)
            {
                res.Msg = "会话已过期，需要重新登录";
                res.Code = 1;
                return res;
            }

            var datalist = ScoreRepository.GetThisMounthSignData(user.OpenID);
            if (datalist == null || datalist.Count == 0)
            {
                res.Msg = "本月无打卡记录";
                res.Code = 2;
                return res;
            }

            res.Data = datalist;
            return res;
        }

    }
}
