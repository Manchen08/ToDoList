using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    class IEnumerable<ToDoList>
    {
        public int ToDoListID { get; set; }
        public string Name { get; set; }
        public int CategoryID { get; set; }
        public bool IsComplete { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime CompletedDate { get; set; }
        public List<Item> Items { get; set; }

    }
}
