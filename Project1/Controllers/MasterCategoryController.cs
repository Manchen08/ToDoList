using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBConnect;

namespace Project1.Controllers
{
    public class MasterCategoryController : Controller
    {
        // GET: MasterCategory
        public ActionResult Index()
        {
            //see if checkbox is checked

            //return lists with these CategoryID's checked

            //return final view of these lists
            return View("MasterCategory");
        }
    }
}