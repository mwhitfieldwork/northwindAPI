
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Web.Mvc;
using NorthwindApp.Data;


namespace NorthwindApp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Authorize(NorthwindApp.Models.UserDTO userModel)
        {
            using(NorthwindContainer db = new NorthwindContainer())
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