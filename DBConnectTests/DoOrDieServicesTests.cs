using Microsoft.VisualStudio.TestTools.UnitTesting;
using DBConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnect.Tests
{
    [TestClass()]
    public class DoOrDieServicesTests
    {
        [TestMethod()]
        public void get()
        {
            DoOrDieServices test = new DoOrDieServices();
            IEnumerable<ToDoList> tList = test.getLists();

            Assert.IsNotNull(tList);
        }

        [TestMethod()]
        public void getByIdTest()
        {
            DoOrDieServices test = new DoOrDieServices();
            ToDoList tList = test.getListById(3);

            Assert.IsNotNull(tList);
        }
    }
}