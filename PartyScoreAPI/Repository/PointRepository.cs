using DBCommon.Model;
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
        static Dictionary<string, DBPoint> DicCodePoint = new Dictionary<string, DBPoint>();
    }
}