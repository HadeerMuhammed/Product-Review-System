using Product_Review_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string searching)
        {
            productreviewDBEntities5 db = new productreviewDBEntities5();
            return View(db.products.Where(x => x.name.Contains(searching) || searching == null).ToList());
        }

        
    }
}