using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    interface IToDoList
    {
        int ToDoListID { get; set; }
        string Name { get; set; }
        int CategoryID { get; set; }
        bool IsComplete { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime CompletedDate { get; set; }
        List<Item> Items { get; set; }
    }
}
