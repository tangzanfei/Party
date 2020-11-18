using DBCommon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCommon.DBUtility
{
    /// <summary>
    /// 提供数据库类型和业务实际类型的转化
    /// </summary>
    public static class ModelConvertHelper
    {
        //public static User DBToModel(DBUser db)
        //{
        //    User user = new User();
        //    user.ID = db.ID; ;
        //    user.Name = db.Name;
        //    user.Account = db.Account;
        //    user.IsManager = db.IsManager;
        //    user.Password = db.Password;
        //    user.Score = db.Score;
        //    user.ServicingBranchID = db.ServicingBranchID;
        //    user.BranchID = db.BranchID;
        //    user.IsBranchMaster = db.IsBranchMaster;
        //    var mybranch = DbHelper.BranchBLL.GetModel(user.BranchID);
        //    var myservieBranch = DbHelper.BranchBLL.GetModel(user.ServicingBranchID);
        //    if (mybranch!=null)
        //    {
        //        user.BranchName = mybranch.Name;
        //    }
        //    if (myservieBranch != null)
        //    {
        //        user.ServicingBranchName = myservieBranch.Name;
        //    }
        //    return user;
        //}

        //public static DBUser ModelToDB(User user)
        //{
        //    DBUser db = new DBUser();
        //    db.ID = user.ID; 
        //    db.Name = user.Name;
        //    db.Account = user.Account;
        //    db.IsManager = user.IsManager;
        //    db.Password = user.Password;
        //    db.Score = user.Score;
        //    db.IsBranchMaster = user.IsBranchMaster;
        //    db.ServicingBranchID = user.ServicingBranchID;
        //    db.BranchID =user.BranchID;


        //    return db;
        //}
    }
}
