using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartyScoreAPI.Models
{
    public class CheckResult
    {
        /// <summary>
        /// 打卡时间
        /// </summary>
        public DateTime CheckTime { get; set; }

        /// <summary>
        /// 打卡地点名称
        /// </summary>
        public string CheckPoint { get; set; }
    }
}