using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartyScoreAPI.Models
{
    /// <summary>
    /// 请求结果返回类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseGetResponse<T>
    {
        public int Code { get; set; }
        public string Msg { get; set; }

        public T Data { get; set; }
    }

}