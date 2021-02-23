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

        [HttpGet]
        public BaseGetResponse<List<CheckResult>> GetThisMounthSignData(string   sessionkey)
        {
            var res = new BaseGetResponse<List<CheckResult>>() { Code = -1, Msg = "未知错误", Data = null };

            if (string.IsNullOrEmpty(sessionkey))
            {
                res.Msg = "会话已过期，需要重新登录";
                res.Code = 1;
                return res;

            }
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
            res.Msg = "OK";
            res.Code = 0;
            res.Data = datalist;
            return res;
        }


        [HttpGet]
        public BaseGetResponse<List<CheckResult>> UnSignBA_Data(string sessionkey)
        {
            var res = new BaseGetResponse<List<CheckResult>>() { Code = -1, Msg = "未知错误", Data = null };

            //1.检查是否有这个用户
            var user = UserRepository.FindUser(sessionkey);
            if (user == null)
            {
                res.Msg = "会话已过期，需要重新登录";
                res.Code = 1;
                return res;
            }


            var BA_list = BranchActionRepository.GetUnsiginBA_DataByUserID(user.OpenID);
            if (BA_list==null || BA_list.Count==0)
            {
                res.Code = 2;
                res.Msg = "本月无未打卡支部活动";
                return res;
            }
            List<CheckResult> list = new List<CheckResult>();
            foreach (var item in BA_list)
            {
                list.Add(new CheckResult() { CheckPoint = item.Title, CheckTime = item.BeginTime });
            }
            //List<CheckResult> list = BA_list.Select(x => x.Title).ToList();
            res.Code = 0;
            res.Msg = "找到以下未打卡支部活动";
            res.Data = list;
            return res;

        }
    }
}
