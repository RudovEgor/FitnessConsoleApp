using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fitness.BL.Contoller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Contoller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        

        [TestMethod()]
        public void SetNewUserDataTest()
        {
            var userName = Guid.NewGuid().ToString();//рандомное имя
            var birthDate = DateTime.Now.AddYears(-18);
            var weigth = 90;
            var heigth = 90;
            var gender = "man";
            var controller = new UserController(userName);
            controller.SetNewUserData(gender, birthDate, weigth, heigth);
            var controller2 = new UserController(userName);
            
            Assert.AreEqual(userName, controller2.CurrentUser.Name);

        }

        [TestMethod()]
        public void SaveTest()
        {
            var userName = Guid.NewGuid().ToString();
            var controller = new UserController(userName);
            Assert.AreEqual(userName, controller.CurrentUser.Name);
            
        }
    }
}