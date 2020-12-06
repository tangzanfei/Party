using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartyScoreAPI.Models
{
    public class User
    {
        public string Name { get; set; }
        private string OpenID { get; set; }
        private string Nickname { get; set; }
        private bool Ismanager { get; set; }
        private string Branchid { get; set; }
        private string Servicingbranchid { get; set; }
        private string Session { get; set; }
        private DateTime? Lastlogintime { get; set; }
    }
}