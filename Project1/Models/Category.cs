using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public class Category
    {
        int CategoryID { get; set;}
        string Name { get; set; }
        List<ToDoList> Lists { get; set; }
    }
}