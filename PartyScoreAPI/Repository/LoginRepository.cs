using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using PartyScoreAPI.Models;
using DBCommon.Model;
using DBCommon.DBUtility;

namespace PartyScoreAPI.Repository
{
    public static class LoginRepository
    {
        static Dictionary<string, string> DicOpenid = new Dictionary<string, string>();
        static Dictionary<string, string> DicSessionKey = new Dictionary<string, string>();
        static Dictionary<string, DBUser> DicUser = new Dictionary<string, DBUser>();

        public static WeXinLoginResultModel PostCode(string code)
        {
            WeXinLoginInModel weixin = new WeXinLoginInModel();
            weixin.AppId = "wxb75da29c7a0ab9bb";    //固定值，请参照小程序参数说明

            weixin.AppSecret = "7a170d592ee57dd3690d28cd71d57777";///固定值，请参照小程序参数说明
            //code = "043Mhh0w3M6pcV2G2V1w3bKqH04Mhh0G";
            weixin.Code = code; //不固定
            string param = $"?appid={weixin.AppId}&secret={weixin.AppSecret}&js_code={weixin.Code}&grant_type=authorization_code";
            ; string url = "https://api.weixin.qq.com/sns/jscode2session" + param;

            var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
            using (var http = new HttpClient(handler))
            {
                //await异步等待回应
                var response = http.GetAsync(url).Result;
                //确保HTTP成功状态值
                response.EnsureSuccessStatusCode();
                var a = response.StatusCode;

                //await异步读取最后的JSON（注意此时gzip已经被自动解压缩了，因为上面的AutomaticDecompression = DecompressionMethods.GZip）
                string responseContent = response.Content.ReadAsStringAsync().Result;
                var resultModel = JsonConvert.DeserializeObject<WeXinLoginResultModel>(responseContent);
                if (!string.IsNullOrEmpty(resultModel.OpenId) && !string.IsNullOrEmpty(resultModel.Session_Key))
                {
                    //将openid，session_key存入到Redis缓存中；              
                    string openIdKey = "openIdKey_" + Guid.NewGuid().ToString();
                    string sessionKey = "sessionKey_" + Guid.NewGuid().ToString();
                    //_redisCacheManager.Set(openIdKey, resultModel.OpenId, TimeSpan.FromDays(1));
                    //_redisCacheManager.Set(sessionKey, resultModel.Session_Key, TimeSpan.FromDays(1));

                    //如果数据库中有OPENID,则更新缓存，否则新增到数据库并添加到缓存。
                    if (DbHelper.UserBLL.Exists(resultModel.OpenId))
                    {
                        var dbuser = DbHelper.UserBLL.GetModel(resultModel.OpenId);
                        dbuser.LastLoginTime = DateTime.Now;
                        DicUser.Add(sessionKey, dbuser);
                    }
                    else
                    {
                        DBUser user = new DBUser();
                        user.OpenID = resultModel.OpenId;
                        user.BranchID = "001";
                        user.Session = resultModel.Session_Key;
                        user.LastLoginTime = DateTime.Now;
                        DbHelper.UserBLL.Add(user);
                        DicUser.Add(sessionKey, user);
                    }

                    DicOpenid.Add(openIdKey, resultModel.OpenId);
                    DicSessionKey.Add(sessionKey, resultModel.SessionKey);
                    resultModel.OpenIdKey = openIdKey;
                    resultModel.SessionKey = sessionKey;
                    return resultModel;

                }
                else
                {
                    return resultModel;
                }

                //返回结果
                //return Ok(resultModel);
            }

        }
    }
}