using DBCommon.DBUtility;
using DBCommon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartyScoreAPI.Repository
{
    /// <summary>
    /// 分数数据仓库
    /// </summary>
    public class ScoreRepository
    {
        //本月日常活动打卡记录
        static List<DBUsuryActionData> signinList = new List<DBUsuryActionData>();

        //本月支部活动打卡记录
        static List<DBUserBranchActionData> signinBAList = new List<DBUserBranchActionData>();

        //本月加分项打卡记录
        static List<DBBonus> bonusList = new List<DBBonus>();


        public void Init()
        {
            signinList.Clear();

            var list = DbHelper.UsuryActionDataBLL.GetModelList("");
            DateTime fristdate = DateTime.Now.AddDays(1 - DateTime.Now.Day).Date;
            var data = list.FindAll(o => o.CheckTime > fristdate);
            signinList.AddRange(data);


#warning 支部活动打卡的初始化，加分项的初始化
        }

        
    }
}