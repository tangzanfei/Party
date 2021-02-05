using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartyScoreAPI.Models
{
    /// <summary>
    /// API后台向微信后台服务器传入参数
    /// </summary>
    public class WeXinLoginInModel
    {
        /// <summary>
        /// 小程序appid
        /// </summary>
        public string AppId { get; set; }
        /// <summary>
        /// 小程序appSecret
        /// </summary>
        public string AppSecret { get; set; }
        /// <summary>
        /// 小程序code
        /// </summary>
        public string Code { get; set; }
    }

    /// <summary>
    /// 微信后台服务器需返回给API后台的参数
    /// </summary>
    public class WeXinLoginResultModel
    {
        /// <summary>
        /// 用户唯一标识
        /// </summary>
        public string OpenId { get; set; }
        /// <summary>
        /// 会话密钥
        /// </summary>
        public string Session_Key { get; set; }
        /// <summary>
        /// 用户在开放平台的唯一标识符，在满足 UnionID 下发条件的情况下会返回，详见UnionID 机制说明。
        /// </summary>
        public string Unionid { get; set; }
        /// <summary>
        /// 错误码
        /// </summary>
        public int ErrCode { get; set; }
        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrMsg { get; set; }
        /// <summary>
        /// Redis里面OpenId值所对应的键OpenIdKey
        /// </summary>
        public string OpenIdKey { get; set; }
        /// <summary>
        /// Redis里面Session_Key值所对应的键SessionKey
        /// </summary>
        public string SessionKey { get; set; }
    }


    public class LoginResult
    {
        public string OpenIdKey { get; set; }

        public string SessionKey { get; set; }

        public bool IsAdmin { get; set; }
    }
}