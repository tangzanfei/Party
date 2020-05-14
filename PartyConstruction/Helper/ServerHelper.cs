using PartyConstruction.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace PartyConstruction.Helper
{
    public static class ServerHelper
    {
        public static DBUser LoginedAccount { get; set; }

        private static Dictionary<string, DBUser> sessionUserDic = new Dictionary<string, DBUser>();
        public static Dictionary<string, DBUser> SessionUserDic { get => sessionUserDic; }

        private static Dictionary<string, HttpSessionState> sessionDic = new Dictionary<string, HttpSessionState>();

        public static Dictionary<string, HttpSessionState> SessionDic
        {
            get { return sessionDic; }
        }


    }
}