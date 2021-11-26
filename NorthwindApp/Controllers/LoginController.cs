
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Web.Mvc;
using NorthwindApp.Data;
using System.Web.Http.Cors;

namespace NorthwindApp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        public ActionResult Authorize(NorthwindApp.Models.UserDTO userModel)
        {
            using(NorthwindEntities1 db = new NorthwindEntities1())
            {
                var userDetails = db.Users.Where(x => x.UserName == userModel.UserName && x.Passowrd == userModel.Password).FirstOrDefault();
                if(userDetails == null)
                {
                    return Redirect("google.com");
                }
            }
            return View();
        }
    }
}