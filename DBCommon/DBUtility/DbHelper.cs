using Maticsoft.Common.Mail;
using DBCommon.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBCommon.DBUtility
{
	/// <summary>
	/// 数据访问处理类
	/// </summary>
    public static class DbHelper
    {
        //private static BonusBLL mActionBLL = new ActionBLL();

        //public static ActionBLL ActionBLL
        //{
        //    get { return mActionBLL; }
        //}
        private static BonusBLL mBonusBLL = new BonusBLL();

        public static BonusBLL BonusBLL
        {
            get { return mBonusBLL; }
        }

        private static PointBLL mPointBLL = new PointBLL();

        public static PointBLL PointBLL
        {
            get { return mPointBLL; }
        }

        //private static BranchBLL mBranchBLL = new BranchBLL();

        //public static BranchBLL BranchBLL
        //{
        //	get { return mBranchBLL; }
        //}

        //private static ScoreBLL mScoreBLL = new ScoreBLL();

        //public static ScoreBLL ScoreBLL
        //{
        //	get { return mScoreBLL;; }
        //}


        //private static UserActionDataBLL mUserActionDataBLL = new UserActionDataBLL();

        //private static UserBLL mUserBLL = new UserBLL();
        //public static UserActionDataBLL UserActionDataBLL { get => mUserActionDataBLL;  }
        //public static UserBLL UserBLL { get => mUserBLL;  }


    }
}