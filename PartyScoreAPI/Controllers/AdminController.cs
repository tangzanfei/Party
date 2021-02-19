using DBCommon.Model;
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
        /// 发起支部活动
        /// </summary>
        /// <param name="code"></param>
        [HttpPost]
        public BaseGetResponse<string> LanchAction(dynamic data)
        {
            var res = new BaseGetResponse<string>() { Code = -1, Msg = "没有这个打卡点", Data = null };
            DBCommon.Model.DBBranchAction action = new DBCommon.Model.DBBranchAction();
            string session = data.Session;
            var user = UserRepository.FindUser(session);
            if (user != null)
            {
                if (user.IsManager)
                {
                    action.BranchID = user.BranchID;

                }
                else
                {
                    res.Code = 2;
                    res.Msg = "只有管理员才能发起支部活动";
                    return res;
                }
            }
            else
            {
                res.Code = 1;
                res.Msg = "用户登录超时";
                return res;
            }

            action.BeginTime = data.BeginTime;
            action.EndTime = data.EndTime;
            action.Title = data.Title;
            action.PointID = data.PointID;


            var point = PointRepository.FindPointById(action.PointID);
            if (point==null)
            {
                res.Code = 3;
                res.Msg = "没有这个打卡点";
                return res;
            }

            string id = BranchActionRepository.LanuchAction(action);
            if (string.IsNullOrEmpty(id))
            {
                res.Code = 2;
                res.Msg = "数据库错误，发起活动失败";
                return res;
            }

            res.Code = 0;
            res.Msg = "发起活动成功";
            res.Data = id;

            return res;

        }

        [HttpGet]
        public BaseGetResponse<List<DBPoint>> GetPointList(string session)
        {
            BaseGetResponse<List<DBPoint>> res = new BaseGetResponse<List<DBPoint>>() { Code = -1, Msg = "未知错误" };

            var user = UserRepository.FindUser(session);
            if (user != null)
            {
                if (!user.IsManager)
                {
                    res.Code = 2;
                    res.Msg = "只有管理员才能发起支部活动";
                    return res;
                }
            }
            else
            {
                res.Code = 1;
                res.Msg = "用户登录超时";
                return res;
            }

            res.Code = 0;
            res.Msg = "获取打卡点成功";
            res.Data = PointRepository.GetPointList();
            return res;
        }
    }
}