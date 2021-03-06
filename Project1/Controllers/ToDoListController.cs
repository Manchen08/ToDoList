﻿using DBConnect;
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

            var categories = db.getAllCategories();
            foreach (var cat in categories)
            {
                bool isChecked = collection.Get(cat.CategoryID.ToString()).Contains("true");
                db.updateListCategoriesById(id, cat.CategoryID, isChecked);
            }

            db.updateListById(id, collection.Get("list.Name"));
            return RedirectToAction("Index");
            
        }

        public ActionResult Search(int id)
        {
            Debug.WriteLine("Entering Search id={0}", id);
            var lists = db.getListByCategory(id);
            return View(lists);
        }

        // GET: ToDoList/Delete/5
        public ActionResult Delete(int id)
        {
            Debug.WriteLine("Entering GET Delete");
            db.deleteListById(id);
            return RedirectToAction("Index");
        }


    }
}
