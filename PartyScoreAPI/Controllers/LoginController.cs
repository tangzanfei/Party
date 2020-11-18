using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PartyScoreAPI.Models;
using PartyScoreAPI.Repository;

namespace PartyScoreAPI.Controllers
{
    public class LoginController : ApiController
    {
        static LoginRepository repository = new LoginRepository();

        /// <summary>
        /// 前段login后，发送获得的code给后台，后台向微信服务器申请openid和sessionkey
        /// </summary>
        /// <param name="code"></param>
        //[Route("login/FFF")]
        [HttpPost]
        public BaseGetResponse<WeXinLoginResultModel> PostCode([FromUri] string code)
        {
            var resultModel = repository.PostCode(code);
            switch (resultModel.ErrCode)
            {
                case -1:
                    //系统繁忙，此时请开发者稍候再试
                    break;
                case 0:
                    //成功
                    return new BaseGetResponse<WeXinLoginResultModel>() { Code=0,Msg="成功",Data=resultModel};
                case 40029:
                    //code无效
                    return new BaseGetResponse<WeXinLoginResultModel>() { Code = 40029, Msg = "code无效", Data = null };
                case 45011:
                    //频率限制，每个用户每分钟100次
                    break;
                    
                default:
                    break;
            }

            return new BaseGetResponse<WeXinLoginResultModel>() { Code = -1, Msg = "失败", Data = null };

        }
    }
}
//{
//    "Code": 0,
//	"Msg": "成功",
//	"Data": {
//        "OpenId": "oTGnP4vJ7KHu8NfPfi7ewMvkiybA",
//		"Session_Key": "El9Y0xbZ9O4/+Zc0cVFT6Q==",
//		"Unionid": null,
//		"ErrCode": 0,
//		"ErrMsg": null,
//		"OpenIdKey": "openIdKey_b6d118eb-b8af-4b26-ba71-e8358cc8fe0d",
//		"SessionKey": "sessionKey_79a30f80-c8b4-4755-8704-1bf87adc44c4"

//    }
//}