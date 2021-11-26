using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Security;
using Newtonsoft.Json;
using NorthwindApp.Data;

namespace NorthwindApp.Controllers
{
    public class LoginAPIController : ApiController
    {
        NorthwindEntities1 db = new NorthwindEntities1();

        [Route("Login")]
        [HttpPost]
        [AllowAnonymous]
        public IHttpActionResult Login (NorthwindApp.Models.UserDTO userModel)
        {
            var userDetails = db.Users.Where(x => x.UserName == userModel.UserName && x.Passowrd == userModel.Password).FirstOrDefault();
            if (userDetails == null)
            {
                string jsonmodel = JsonConvert.SerializeObject(new
                {
                    results = new List<JSONResult>()
                    {
                        new JSONResult { match = false, error = "the credentials entered, don't match" , logout = false},
                    }
                });
                return Json(jsonmodel);
            }
            else
            {
                FormsAuthentication.SetAuthCookie(userModel.UserName, false);
                string jsonmodel = JsonConvert.SerializeObject(new
                {
                    results = new List<JSONResult>()
                    {
                        new JSONResult {match = true, error = "", logout = false},
                    }
                });
                return Json(jsonmodel);
            }
        }

        [AllowAnonymous]
        public IHttpActionResult Logout()
        {
            FormsAuthentication.SignOut();

            string jsonmodel = JsonConvert.SerializeObject(new
            {
                results = new List<JSONResult>()
                    {
                        new JSONResult {match = true, error = "", logout = true},
                    }
            });
            return Json(jsonmodel);
        }
    }
    public class JSONResult
    {
        public bool match { get; set; }
        public string error { get; set; }

        public bool logout { get; set; }
    }
}

