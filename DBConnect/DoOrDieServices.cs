using DBConnect;
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
        public void createItem(int listID, string name)
        {
            using (var entities = new Project1ToDoEntities())
            {
                Item newItem = new Item();
                DateTime createdDate = DateTime.Now;

                newItem.Name = name;
                newItem.ToDoListID = listID;
                newItem.IsComplete = false;
                newItem.CreatedDate = createdDate;

                entities.Items.Add(newItem);
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
            IEnumerable<ToDoList> lists = from ToDoList in entities.ToDoLists select ToDoList;
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

        public void updateListById(int id, string name, int?[] categories)
        {
            using (var entities = new Project1ToDoEntities())
            {
                ToDoList list = entities.ToDoLists.Where(x => x.ToDoListID == id).FirstOrDefault();
                list.Name = name;
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

        #endregion Items

        #region Categories
        public IEnumerable<Category> getAllCategories()
        {
            using (var entities = new Project1ToDoEntities())
            {
                return (entities.Categories).ToList();
            }
        }

        #endregion
    }
}
