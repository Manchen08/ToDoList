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
        public ActionResult Index(int id)
        {
            Debug.WriteLine("Entering Index");
            IEnumerable<DBConnect.Item> lists = db.getItemByListId(id);
            return View(lists);
        }

        // get: item/create
        public ActionResult Create(int id)
        {
            string name = "New Item";
            Debug.WriteLine("Entering Create");
            db.createItem(id, name);
            return Redirect(@Request.UrlReferrer.ToString());
            //IEnumerable<DBConnect.Item> lists = db.getItemByListId(id);
            //return View(lists);
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

        public ActionResult View(int id)
        {
            Debug.WriteLine("Entering Index");
            var itemsView = new Models.ToDoListItemsViewModel();
            itemsView.list = db.getListById(id);
            itemsView.items = db.getItemByListId(id);
            return View(itemsView);
        }
        
        // GET: Item/Edit/5
        public ActionResult Edit(int id, int listId)
        {
            Debug.WriteLine("Entering GET edit");
            var editView = new Models.EditItemViewModel();
            editView.item = db.getItemById(id);
            editView.list = db.getListById(listId);
            return View(editView);
        }

        // POST: Item/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            Debug.WriteLine("Entering GET post edit");
            db.updateItemByItemId(id, collection.Get("item.Name"));
            string listID = collection.Get("list.ToDoListID");
            return RedirectToAction(listID, "Item/View");
        }

        // GET: Item/Delete/5
        public ActionResult Delete(int id)
        {
            Debug.WriteLine("Entering GET Delete");
            db.deleteItemByItemId(id);
            return Redirect(@Request.UrlReferrer.ToString());
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
