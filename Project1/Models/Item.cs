using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    class Item
    {
        public int ItemID { get; set; }
        public string Name { get; set; }
        public int ToDoListID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime CompletedDate { get; set; }
        public bool IsComplete { get; set; }

    }
}
