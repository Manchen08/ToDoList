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
        DoOrDieServices db = new DoOrDieServices();
        // GET: MasterCategory
        public ActionResult Index()
        {
            IEnumerable<DBConnect.Category> cats = db.getAllCategories();
            //return final view of these lists
            return View(cats);

        }

    }
}