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

        // GET: ToDoList
        //ex URL localhost:XXXXX/ToDoList or //localhost:XXXXX/ToDoList/Index
        public ActionResult Index()
        {
            Project1ToDoEntities entities = new Project1ToDoEntities();
            Debug.WriteLine("Entering Index");
            return View(from ToDoList in entities.ToDoLists.Take(10) select ToDoList);
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
            ToDoList newList = new ToDoList();
            Project1ToDoEntities entities = new Project1ToDoEntities();
            newList.Name = "NewList";
            newList.CategoryID = 2;
            newList.IsComplete = false;
            entities.ToDoLists.Add(newList);
            entities.SaveChanges();
            return RedirectToAction("Index");
        }


        // GET: ToDoList/Edit/5
        //NOT IMPLEMENTED
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ToDoList/Edit/5
        //NOT IMPLEMENTED
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
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
