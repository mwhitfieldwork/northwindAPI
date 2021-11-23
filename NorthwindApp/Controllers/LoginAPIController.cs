using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
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
                string jsonmodel = JsonConvert.SerializeObject(new
                {
                    results = new List<JSONResult>()
                    {
                        new JSONResult { match = false, error = "the credentials entered, don't match" },
                    }
                });
                return Json(jsonmodel);
            }
            else
            {
                string jsonmodel = JsonConvert.SerializeObject(new
                {
                    results = new List<JSONResult>()
                    {
                        new JSONResult { match = true, error = "" },
                    }
                });
                return Json(jsonmodel);
            }
        }
    }
    public class JSONResult
    {
        public bool match { get; set; }
        public string error { get; set; }
    }
}

