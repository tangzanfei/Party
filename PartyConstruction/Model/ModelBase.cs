using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartyConstruction.Model
{
    public class ModelBase
    {
        public string ID { get; set; }
        public ModelBase()
        {
            ID = Guid.NewGuid().ToString();
        }
        public ModelBase Copy()
        {
            return (ModelBase)this.MemberwiseClone();
        }

    }
}