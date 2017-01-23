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

        // GET: ToDoList/Details/5
        // NOT IMPLEMENTED 
        public ActionResult Details(int id)
        {
           
            return View();
        }


        public ActionResult Create()
        {
            Debug.WriteLine("Entering Create");
            db.createList("New List");
            return RedirectToAction("Index");
        }


        // GET: ToDoList/Edit/5
        //NOT IMPLEMENTED
        public ActionResult Edit(int id)
        {
            Project1ToDoEntities entities = new Project1ToDoEntities();
            Debug.WriteLine("Entering edit");
            //IEnumerable<DBConnect.ToDoList> list = db.getListById(id);
            return RedirectToAction("Index");
            
        }

        // POST: ToDoList/Edit/5
        //NOT IMPLEMENTED
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            Project1ToDoEntities entities = new Project1ToDoEntities();
            Debug.WriteLine("Entering Edit Post");
            //IEnumerable<DBConnect.ToDoList> list = db.getListById(id);
            

            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ToDoList/Delete/5
        //NOT IMPLEMENTED
        public ActionResult Delete(int id)
        {
            return View();
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
