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
    public class ItemController : Controller
    {
        static DataTable dt = new DataTable();
        DoOrDieServices db = new DoOrDieServices();

        // GET: Item
        //ex URL localhost:XXXXX/Item or //localhost:XXXXX/Item/Index
        public ActionResult Index()
        {
            Debug.WriteLine("Entering Index");
            int listId = 1;
            IEnumerable<DBConnect.Item> lists = db.getItemByListId(listId);
            return View(lists);
        }

        //// get: item/details/5
        //  public actionresult details(int id)
        //  {
        //      return view();
        //  }
  

       // get: item/create
        public ActionResult Create(int id)
        {
            Debug.WriteLine("Entering Create");
            IEnumerable<DBConnect.Item> view = db.getItemByListId(id);
            return View(view);
        }
       
        
        // GET: Item/Edit/5
        public ActionResult Edit(int id)
        {
            Debug.WriteLine("Entering GET edit");
            var list = db.getItemByListId(id);
            return View(list);
        }

        // POST: Item/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        // POST: Item/Edit/5
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

        // GET: Item/Delete/5
        public ActionResult Delete(int id)
        {
            Debug.WriteLine("Entering GET Delete");
            db.deleteItemByItemId(id);
            return RedirectToAction("Index");
        }

        // POST: Item/Delete/5
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
