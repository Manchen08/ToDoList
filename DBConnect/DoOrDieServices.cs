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
            using (var db = new Project1ToDoEntities())
            {
                var list = db.ToDoLists.Single(n => n.ToDoListID == listId);

                if (isChecked)
                {
                    var category = db.Categories.Single(n => n.CategoryID == catId);
                    list.Categories.Add(category);
                }
                else
                {
                    var category = list.Categories.Single(n => n.CategoryID == catId);
                    list.Categories.Remove(category);
                }

                db.SaveChanges();
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
