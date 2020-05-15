using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartyConstruction.Model
{
    public class User : ModelBase 
    {
        public string Name { get; set; }

        public bool IsBranchMaster { get; set; }
        public bool IsManager { get; set; }
        public string BranchID { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public string ServicingBranchID { get; set; }
        public string BranchName { get; set; }
        public string ServicingBranchName { get; set; }
        public int Score { get; set; }

    }
}