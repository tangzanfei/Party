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
        #region  BLL实例
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

        private static BranchActionBLL mBranchActionBLL = new BranchActionBLL();

        public static BranchActionBLL BranchActionBLL
        {
            get { return mBranchActionBLL; }
        }


        private static BranchBLL mBranchBLL = new BranchBLL();

        public static BranchBLL BranchBLL
        {
            get { return mBranchBLL; }
        }

        private static UserBLL mUserBLL = new UserBLL();

        public static UserBLL UserBLL
        {
            get { return mUserBLL; }
        }

        private static UserBranchActionDataBLL mUserBranchActionDataBLL = new UserBranchActionDataBLL();

        public static UserBranchActionDataBLL UserBranchActionDataBLL
        {
            get { return mUserBranchActionDataBLL; }
        }

        private static UsuryActionDataBLL mUsuryActionDataBLL = new UsuryActionDataBLL();

        public static UsuryActionDataBLL UsuryActionDataBLL
        {
            get { return mUsuryActionDataBLL; }
        }

        #endregion

        #region 公共方法

        public static bool IsInited = false;

        public static void InitDB()
        {
            if (IsInited)
            {
                return;
            }
            UserBLL.Add(new Model.DBUser() { OpenID="0001",BranchID="001",Name="唐赞飞",NickName="飞",IsManager=true});
            UserBLL.Add(new Model.DBUser() { OpenID="0002",BranchID="001",Name="唐观文",NickName="唐观文",IsManager=true});
            UserBLL.Add(new Model.DBUser() { OpenID="0003",BranchID="001",Name="欧阳石光",NickName="时光",IsManager=false});

            BranchBLL.Add(new Model.DBBranch() { ID = "001", MasterID = "0002", Name = "县委组织部第一支部" });

            PointBLL.Add(new Model.DBPoint() { ID = "001", Name = "县委组织部会议室", QrCode = "XWZZBHYS", WifiName = "556", WifiMac = "FF-FF-FF-FF" });
            PointBLL.Add(new Model.DBPoint() { ID = "002", Name = "翡翠湾社区", QrCode = "FCWSQ", WifiName = "TPLink368E", WifiMac = "FF-FF-FF-FF" });
            PointBLL.Add(new Model.DBPoint() { ID = "003", Name = "凯旋城", QrCode = "KXC", WifiName = "TPLink368E", WifiMac = "FF-FF-FF-FF" });
            IsInited = true;
        }

        #endregion
    }
}