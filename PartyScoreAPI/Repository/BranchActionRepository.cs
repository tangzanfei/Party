using DBCommon.DBUtility;
using DBCommon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartyScoreAPI.Repository
{
    public static class BranchActionRepository
    {
        public static List<DBBranchAction> ActionList = new List<DBBranchAction>();

        public static void Init()
        {

        }


        public static string LanuchAction(DBBranchAction action)
        {
            bool success = false;
            action.ID = Guid.NewGuid().ToString();
            success = DbHelper.BranchActionBLL.Add(action);
            if (success)
            {
                var userList = DbHelper.UserBLL.GetModelList("BranchID='" + action.BranchID + "'");
                foreach (var user in userList)
                {
                    bool s = DbHelper.UserBranchActionDataBLL.Add(new DBUserBranchActionData()
                    {
                        ID = Guid.NewGuid().ToString(),
                        ActionID = action.ID,
                        Checked = false,
                        CheckTime = null,
                        UserID=user.OpenID,
                    });
                    if (!s)
                    {
                        success = false;
                    }
                }
                if (success)
                {
                    return action.ID;
                }
            }
            return null;
        }

        public static List<DBBranchAction> GetUnsiginBA_DataByUserID(string userid)
        {
            //1.找出用户打卡状态为否的打卡数据
            var datalist =DbHelper.UserBranchActionDataBLL.GetModelList("UserID='" + userid + "'");
            datalist = datalist.Where(x => x.Checked == false).ToList();
            //2.根据打卡数据的活动id找到对应的活动
            List<DBBranchAction> resultdata = new List<DBBranchAction>();
            foreach (var data in datalist)
            {
                var action = DbHelper.BranchActionBLL.GetModel(data.ActionID);
                resultdata.Add(action);
            }
            var now = DateTime.Now;
            resultdata = resultdata.Where(x => x.BeginTime.Month == now.Month && x.BeginTime.Year == now.Year).ToList();
            //3.返回活动列表

            return resultdata;
        }
       
    }
}