using DBCommon.DBUtility;
using DBCommon.Model;
using PartyScoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartyScoreAPI.Repository
{
    /// <summary>
    /// 打卡点仓库
    /// </summary>
    public static class PointRepository
    {
        static bool IsInited = false;
        static List<DBPoint> ListPoint = new List<DBPoint>();

        //打卡点二维码字典
        static Dictionary<string, DBPoint> DicCodePoint = new Dictionary<string, DBPoint>();
        //支部活动二维码字典
        static Dictionary<string, DBBranchAction> DicCodeBranchAction = new Dictionary<string, DBBranchAction>();

        public static void Init()
        {
            ListPoint.Clear();
            ListPoint = DbHelper.PointBLL.GetModelList("");
            IsInited = true;
        }


        public static DBPoint FindPointById(string id)
        {
            if (!IsInited)
            {
                Init();
            }
            return ListPoint.Find(x => x.ID.Equals(id));
        }


        public static DBPoint FindPoint(string qrcode)
        {
            if (DicCodePoint.Count==0)
            {
                var list = DbHelper.PointBLL.GetModelList("");
                foreach (var item in list)
                {
                    DicCodePoint.Add(item.QrCode, item);
                }
            }
            if (DicCodePoint.ContainsKey(qrcode))
                return DicCodePoint[qrcode];
            else
                return null;
        }

        /// <summary>
        /// 查找是否有对应二维码的支部活动
        /// </summary>
        /// <param name="qrcode">二维码</param>
        /// <returns>对应活动的ID，如果无则返回空</returns>
        public static string FindBranchActionID(string qrcode)
        {
            DBBranchAction ba = null;
            var list = DbHelper.BranchActionBLL.GetModelList("QrCode='" + qrcode + "'");
            foreach (var item in list)
            {
                if (item.BeginTime<DateTime.Now && item.EndTime>DateTime.Now)
                {
                    ba = item;
                }
            }
            return ba == null ? null : ba.ID;

        }

        /// <summary>
        /// 查找是否有在进行的对应打卡点的所有支部活动
        /// </summary>
        /// <param name="pointid">打卡点ID</param>
        /// <returns>所有符合的支部活动列表，如果无则返回空</returns>
        public static List<DBBranchAction> FindBranchActionByPointID(string pointid)
        {
            List<DBBranchAction> listBA = new List<DBBranchAction>();
            var list = DbHelper.BranchActionBLL.GetModelList("PointID='" + pointid + "'");
            DateTime now = DateTime.Now;
            foreach (var item in list)
            {
                if (item.BeginTime < now && item.EndTime > now)
                {
                    listBA.Add(item);
                }
            }
            return listBA;

        }


        //        public static BaseGetResponse<CheckResult> CheckByScanQrcode(string qrcode, string sessionkey)
        //        {
        //            var res = new BaseGetResponse<CheckResult>() { Code = -1, Msg = "没有这个打卡点", Data = null };
        //            DBUser user = DicUser[sessionkey];
        //            var pointlist = DbHelper.PointBLL.GetModelList("QrCode='" + qrcode + "'");
        //            if (pointlist != null && pointlist.Count > 0)
        //            {
        //                res.Code = 0;
        //                res.Msg = "打卡成功";
        //                res.Data = new CheckResult() { CheckTime = DateTime.Now, CheckPoint = pointlist[0].Name };
        //#warning 需要补充写入志愿打卡表数据。
        //                return res;
        //            }
        //            else
        //            {
        //                return res;
        //            }
        //            return res;
        //        }

    }
}