using DBConnect;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project1.Controllers
{
    public class ToDoListController : Controller
    {
        static DataTable dt = new DataTable();
        DoOrDieServices db = new DoOrDieServices();

        // GET: ToDoList
        //ex URL localhost:XXXXX/ToDoList or //localhost:XXXXX/ToDoList/Index
        public ActionResult Index()
        {
            Debug.WriteLine("Entering Index");
            IEnumerable<DBConnect.ToDoList> lists = db.getLists();
            return View(lists);
        }


        public ActionResult Create()
        {
            Debug.WriteLine("Entering Create");
            db.createList("New List");
            return RedirectToAction("Index");
        }


        // GET: ToDoList/Edit/5
        public ActionResult Edit(int id)
        {
            Debug.WriteLine("Entering GET edit");
            var list = db.getListById(id);
            Project1.Models.ToDoListEditViewModel editModel = new Models.ToDoListEditViewModel();
            editModel.list = db.getListById(id);
            editModel.Categories = db.getAllCategories().ToList();

            return View(editModel);

        }

        // POST: ToDoList/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            Debug.WriteLine("Entering Edit Post");
            Debug.WriteLine(collection.Get("list.Name"));
            Debug.WriteLine(collection.GetValues("list.categories"));
            var list = db.getListById(id);

            int catCount = db.getAllCategories().Count();
            for (int i = 1; i <= catCount; i++)
            {

                DBConnect.Category cat = db.getCategoryById(i);
                bool isChecked = collection.Get(i.ToString()).Contains("true");
                db.updateListCategoriesById(id, i, isChecked);
            }

            db.updateListById(id, collection.Get("list.Name"));
            return RedirectToAction("Index");
            
        }

        // GET: ToDoList/Delete/5
        public ActionResult Delete(int id)
        {
            Debug.WriteLine("Entering GET Delete");
            db.deleteListById(id);
            return RedirectToAction("Index");
        }

        // POST: ToDoList/Delete/5
        //NOT IMPLEMENTED
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
