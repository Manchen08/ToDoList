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
            //see if checkbox is checked

            //return lists with these CategoryID's checked
            IEnumerable<DBConnect.Category> categories = db.getAllCategories();
            //return final view of these lists
            return View(categories);

        }


        /*private IList<SelectListItem> SearchByCategories()
        {
            return new List<SelectListItem>
            {

                new SelectListItem {Text = i, Value = i},
            };
            return new List<SelectListItem>
            {
                new SelectListItem {Text = "Apple", Value = "Apple"},
                new SelectListItem {Text = "Pear", Value = "Pear"},
                new SelectListItem {Text = "Banana", Value = "Banana"},
                new SelectListItem {Text = "Orange", Value = "Orange"},
            };
        }*/

    }
}