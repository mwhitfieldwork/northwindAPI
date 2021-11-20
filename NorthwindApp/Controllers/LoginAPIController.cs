using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NorthwindApp.Data;

namespace NorthwindApp.Controllers
{
    public class LoginAPIController : ApiController
    {
        NorthwindContainer db = new NorthwindContainer();

        [Route("Login")]
        [HttpPost]
        public IHttpActionResult Login (NorthwindApp.Models.UserDTO userModel)
        {
            var userDetails = db.Users.Where(x => x.UserName == userModel.UserName && x.Passowrd == userModel.Password).FirstOrDefault();
            if (userDetails == null)
            {
                return Redirect("http://www.google.com");
            }
            else
            {
                return Redirect("http://www.google.com");
            }
        }
    }
}

