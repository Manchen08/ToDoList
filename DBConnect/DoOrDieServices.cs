﻿using DBConnect;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace DBConnect
{
    public class DoOrDieServices
    {
        #region ToDoLists
        //
        public void createList(string name)
        {
            using (var entities = new Project1ToDoEntities())
            {
                ToDoList newList = new ToDoList();
                DateTime createdDate = DateTime.Now;

                newList.Name = name;
                newList.IsComplete = false;
                newList.CreatedDate = createdDate;

                entities.ToDoLists.Add(newList);
                entities.SaveChanges();

            }

        }

        public IEnumerable<ToDoList> getLists()
        {
            using (var entities = new Project1ToDoEntities())
            {
                IEnumerable<ToDoList> lists = from ToDoList in entities.ToDoLists select ToDoList;
                return (lists);
            }

        }

        public ToDoList getListById(int id)
        {
            using (var entities = new Project1ToDoEntities())
            {
                return (entities.ToDoLists.Where(x => x.ToDoListID == id).FirstOrDefault());
            }

        }
        public void deleteListById(int id)
        {
            using (var entities = new Project1ToDoEntities())
            {

                ToDoList list = entities.ToDoLists.Where(x => x.ToDoListID == id).FirstOrDefault();
                entities.ToDoLists.Remove(list);
                entities.SaveChanges();
            }

        }
        #endregion ToDoLists

        #region Items
        public IEnumerable<Item> getItemByListId(int id)
        {
            using (var entities = new Project1ToDoEntities())
            {
                return (entities.Items.Where(x => x.ToDoListID == id)).ToList();
            }
        }

        public void deleteItemByItemId(int id)
        {
            using (var entities = new Project1ToDoEntities())
            {
                entities.Items.Remove(entities.Items.Where(x => x.ItemID == id).First());

                entities.SaveChanges();
            }
            
        }

        #endregion Items
    }
}