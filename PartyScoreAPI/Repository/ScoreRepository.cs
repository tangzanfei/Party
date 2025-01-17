﻿using DBCommon.DBUtility;
using DBCommon.Model;
using PartyScoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartyScoreAPI.Repository
{
    /// <summary>
    /// 分数数据仓库
    /// </summary>
    public static class ScoreRepository
    {
        //本月日常活动打卡记录
        static List<DBUsuryActionData> signinList = new List<DBUsuryActionData>();

        //本月支部活动打卡记录
        static List<DBUserBranchActionData> signinBAList = new List<DBUserBranchActionData>();

        //本月加分项打卡记录
        static List<DBBonus> bonusList = new List<DBBonus>();

        static bool isInited = false;

        public static void Init()
        {
            signinList.Clear();

            var list = DbHelper.UsuryActionDataBLL.GetModelList("");
            DateTime fristdate = DateTime.Now.AddDays(1 - DateTime.Now.Day).Date;
            var data = list.FindAll(o => o.CheckTime > fristdate);
            signinList.AddRange(data);

#warning 支部活动打卡的初始化，加分项的初始化

            isInited = true;
        }

        /// <summary>
        /// 检查是否重复志愿打卡，如果找到则返回ID
        /// </summary>
        /// <returns>重复数据的ID</returns>
        public static string IsSignined(string pointId, string userid)
        {
            if (!isInited)
            {
                Init();
            }

            var list = signinList.Where(x => x.PointID == pointId && x.UserID == userid && x.CheckTime.Date == DateTime.Today);
            if (list == null || list.Count() == 0)
            {
                return null;
            }
            else
            {
                return list.FirstOrDefault().ID;
            }
        }

        /// <summary>
        /// 志愿打卡
        /// </summary>
        /// <param name="pointId">打卡点的ID</param>
        /// <param name="userid">用户ID</param>
        public static CheckResult Signin(string pointId, string userid)
        {
            if (String.IsNullOrEmpty(pointId) || String.IsNullOrEmpty(userid))
            {
                return null;
            }
            DateTime checktime = DateTime.Now;
            var data = new DBUsuryActionData()
            {
                ID = Guid.NewGuid().ToString(),
                PointID = pointId,
                UserID = userid,
                CheckTime = checktime
            };
            DbHelper.UsuryActionDataBLL.Add(data);
            signinList.Add(data);
            var point = DbHelper.PointBLL.GetModel(pointId);
            var result = new CheckResult() { CheckTime = checktime, CheckPoint = "" };
            if (point!=null)
            {
                result.CheckPoint = point.Name;
            }
            return result;
        }


        /// <summary>
        /// 获取本月志愿打卡数据
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public static List<CheckResult> GetThisMounthSignData(string userid)
        {
            if (!isInited)
            {
                Init();
            }
            var list = signinList.Where(x => x.UserID.Equals(userid));
            List<CheckResult> crlist = new List<CheckResult>();
            foreach (var item in list)
            {
                crlist.Add(new CheckResult() { CheckTime = item.CheckTime, CheckPoint = PointRepository.FindPointById(item.PointID).Name });
            }
            return crlist;
        }


        /// <summary>
        /// 支部活动打卡
        /// </summary>
        /// <param name="actionid">支部活动id</param>
        /// <param name="userid">用户id</param>
        /// <returns></returns>
        public static CheckResult BA_Signin(string actionid,string userid)
        {
            CheckResult result = new CheckResult();
            var datalist = DbHelper.UserBranchActionDataBLL.GetModelList("UserID='" + userid + "'");
            var action = DbHelper.BranchActionBLL.GetModel(actionid);
            if (datalist!=null && datalist.Count>0)
            {
                var list = datalist.Where(x => x.ActionID.Equals(actionid)).ToList();
                if (list.Count()>0)
                {
                    if (list[0].Checked)
                    {
                        return null;
                    }
                    list[0].CheckTime = result.CheckTime = DateTime.Now;
                    list[0].Checked = true;
                    DbHelper.UserBranchActionDataBLL.Update(list[0]);
                    result.CheckPoint = action.Title;
                    return result;
                }
            }
            return null;
        }



        /// <summary>
        /// 获取本月支部打卡数据
        /// </summary>
        /// <param name="userid"></param>
        public static void GetThismounthBA_SignData(string userid) { }
    }
}