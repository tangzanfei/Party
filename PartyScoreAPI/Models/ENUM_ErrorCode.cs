using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartyScoreAPI.Models
{
    /// <summary>
    /// 错误识别码
    /// </summary>
    public enum ENUM_ErrorCode
    {
        /// <summary>
        /// 成功
        /// </summary>
        Sucess=0,
        SessionFail=100001,
    }
}