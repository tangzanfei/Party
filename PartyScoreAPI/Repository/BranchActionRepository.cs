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
       
    }
}