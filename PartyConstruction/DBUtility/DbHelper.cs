using Maticsoft.Common.Mail;
using PartyConstruction.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartyConstruction.DBUtility
{
	/// <summary>
	/// 数据访问处理类
	/// </summary>
    public static class DbHelper
    {
		private static ActionBLL mActionBLL = new ActionBLL();

		public static ActionBLL ActionBLL
		{
			get { return mActionBLL; }
		}

		private static BranchBLL mBranchBLL = new BranchBLL();

		public static BranchBLL BranchBLL
		{
			get { return mBranchBLL; }
		}

		private static ScoreBLL mScoreBLL = new ScoreBLL();

		public static ScoreBLL ScoreBLL
		{
			get { return mScoreBLL;; }
		}


		private static UserActionDataBLL mUserActionDataBLL = new UserActionDataBLL();

		private static UserBLL mUserBLL = new UserBLL();
		public static UserActionDataBLL UserActionDataBLL { get => mUserActionDataBLL;  }
		public static UserBLL UserBLL { get => mUserBLL;  }


	}
}