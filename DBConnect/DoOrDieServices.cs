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

                entities.ToDoLists.Add(newList);
                entities.SaveChanges();

            }

        }

        public IEnumerable<ToDoList> getLists()
        {
            //using (var entities = new Project1ToDoEntities())
            //{
            //    IEnumerable<ToDoList> lists = from ToDoList in entities.ToDoLists select ToDoList;
            //    return (lists.ToList());
            //}

            Project1ToDoEntities entities = new Project1ToDoEntities();
            IEnumerable<ToDoList> lists = entities.ToDoLists.ToList();
            return (lists);
        }

        public ToDoList getListById(int id)
        {
            //using (var entities = new Project1ToDoEntities())
            //{
            //    return (entities.ToDoLists.Where(x => x.ToDoListID == id).ToList());
            //}

            var entities = new Project1ToDoEntities();
            ToDoList list = entities.ToDoLists.Where(x => x.ToDoListID == id).FirstOrDefault();
            return list;
        }

        public void updateListById(int id, string name)
        {
            using (var entities = new Project1ToDoEntities())
            {
                ToDoList list = entities.ToDoLists.Where(x => x.ToDoListID == id).FirstOrDefault();
                list.Name = name;
                entities.SaveChanges();
            }
        }
        public void updateListCategoriesById(int listId, int catId, bool isChecked)
        {
            using (var entities = new Project1ToDoEntities())
            {
                ToDoListCategory testListCat = null;

                try
                {
                    testListCat = entities.ToDoListCategories.Where(x => x.Category_Id == catId && x.ToDoList_Id == listId).First();
                }
                catch (Exception)
                {

                    Debug.WriteLine("Not Found, ignore.");
                }

                if (isChecked && testListCat == null)
                {
                    ToDoListCategory newListCat = new ToDoListCategory();
                    newListCat.Category_Id = catId;
                    newListCat.ToDoList_Id = listId;
                    entities.ToDoListCategories.Add(newListCat);
                }
                else
                {
                    if (testListCat != null)
                    {
                        entities.ToDoListCategories.Remove(testListCat);
                    }
                }
                    

                entities.SaveChanges();
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
        public void createItem(int listID, string name)
        {
            using (var entities = new Project1ToDoEntities())
            {
                Item newItem = new Item();
                DateTime createdDate = DateTime.Now;

                newItem.Name = name;
                newItem.ToDoListID = listID;
                newItem.IsComplete = false;

                entities.Items.Add(newItem);
                entities.SaveChanges();
            }

        }

        #endregion Items

        #region Categories
        public IEnumerable<Category> getAllCategories()
        {
            using (var entities = new Project1ToDoEntities())
            {
                return (entities.Categories).ToList();
            }
        }

        public Category getCategoryById(int id)
        {
            using (var entities = new Project1ToDoEntities())
            {
                return (entities.Categories.Where(x => x.CategoryID == id).FirstOrDefault());
            }
        }

        #endregion
    }
}
