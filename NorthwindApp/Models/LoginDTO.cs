using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace NorthwindApp.Models
{
    [DataContract(Name = "Login")]
    [Serializable]
    public class LoginDTO
    {
        [DataMember]
        public int PKID { get; set; }

        [DataMember]
        public int UserName { get; set; }

        [DataMember]
        public int Password { get; set; }
    }
}