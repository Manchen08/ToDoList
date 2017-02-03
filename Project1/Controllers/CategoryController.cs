using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBConnect;
using Microsoft.Ajax.Utilities;

namespace Project1.Controllers
{
    public class CategoryController : Controller
    {
        static DataTable dt = new DataTable();
        DoOrDieServices db = new DoOrDieServices();

        // GET: Category
        public ActionResult Index()
        {
            Debug.WriteLine("Entering Index");
            IEnumerable<DBConnect.Category> categories = db.getAllCategories();
            return View(categories);
        }

        public ActionResult Create()
        {
            string name = "New Category";
            Debug.WriteLine("Entering Create");
            db.createCategory(name);
            return RedirectToAction("Index");
        }


        // GET: ToDoList/Edit/5
        public ActionResult Edit(int id)
        {
            //if (id.ToString().Equals(""))
            //    id = 1;
            Debug.WriteLine("Entering GET edit");
            var category = db.getCategoryById(id);
            return View(category);

        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            Debug.WriteLine("Entering GET post edit");
            db.updateCategoryById(id, collection.Get("Name"));
            return RedirectToAction("Index");
        }

        // GET: ToDoList/Delete/5
        public ActionResult Delete(int id)
        {
            Debug.WriteLine("Entering GET Delete");
            db.deleteCategoryByCategoryId(id);
            return RedirectToAction("Index");
        }
    }
}