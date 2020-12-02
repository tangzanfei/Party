using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using PartyScoreAPI.Models;

namespace PartyScoreAPI.Controllers
{
    public class UserController : ApiController
    {

        List<User> Users = new List<User>()
        {
            new User() { Name = "张飞", Age = 39 } ,
            new User(){Name="吕布",Age=29}
        };

        // GET: api/User
        public IEnumerable<User> GetAllUsers()
        
        {
            var result = DBCommon.DBUtility.DbHelper.PointBLL.Add(new DBCommon.Model.DBPoint() 
            { 
                ID = "00001", 
                Name = "组织部支部会议室打卡点",
                QrCode = "ZBHYSDKD",
                WifiName = "0556",
                WifiMac = "F9-E1-98-00-FA" 
            });
            return Users;
        }

        // GET: api/User/5
        public IHttpActionResult GetUserByName(string name)
        {
            var user = Users.FirstOrDefault((p) => p.Name == name);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST: api/User
        public void PostUser([FromBody]User value)
        {
            Users.Add(value);
        }

        // PUT: api/User/5
        public IHttpActionResult PutUser(string  name, [FromBody]User value)
        {
            var user = Users.FirstOrDefault((p) => p.Name == name);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }


        //[HttpGet("~/api/WeiXinLogin", Name = "WeiXinLogin")]
        //public async Task<IActionResult> WeiXinLogin(string js_code)
        //{
        //    WeXinLoginInModel weixin = new WeXinLoginInModel();
        //    weixin.AppId = "wx30a387595dafb442";    //固定值，请参照小程序参数说明
        //    weixin.AppSecret = "4e24cab02422082b11a406595dacee76";///固定值，请参照小程序参数说明
        //    weixin.Code = js_code; //不固定

        //    string param = $"?appid={weixin.AppId}&secret={weixin.AppSecret}&js_code={weixin.Code}&grant_type=authorization_code";
        //    ; string url = "https://api.weixin.qq.com/sns/jscode2session" + param;

        //    var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
        //    using (var http = new HttpClient(handler))
        //    {
        //        //await异步等待回应
        //        var response = await http.GetAsync(url);
        //        //确保HTTP成功状态值
        //        response.EnsureSuccessStatusCode();
        //        var a = response.StatusCode;

        //        //await异步读取最后的JSON（注意此时gzip已经被自动解压缩了，因为上面的AutomaticDecompression = DecompressionMethods.GZip）
        //        string responseContent = await response.Content.ReadAsStringAsync();
        //        var resultModel = JsonConvert.DeserializeObject<WeXinLoginResultModel>(responseContent);
        //        if (!string.IsNullOrEmpty(resultModel.OpenId) && !string.IsNullOrEmpty(resultModel.Session_Key))
        //        {
        //            //将openid，session_key存入到Redis缓存中；              
        //            string openIdKey = "openIdKey_" + Guid.NewGuid().ToString();
        //            string sessionKey = "sessionKey_" + Guid.NewGuid().ToString();
        //            _redisCacheManager.Set(openIdKey, resultModel.OpenId, TimeSpan.FromDays(1));
        //            _redisCacheManager.Set(sessionKey, resultModel.Session_Key, TimeSpan.FromDays(1));
        //            resultModel.OpenIdKey = openIdKey;
        //            resultModel.SessionKey = sessionKey;
        //        }

        //        //返回结果
        //        return Ok(resultModel);
        //    }
        //}
    }
}
