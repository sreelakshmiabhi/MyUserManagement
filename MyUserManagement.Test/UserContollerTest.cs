#region Namespaces

using Microsoft.AspNetCore.Hosting;
using Moq;
using MyUserManagement.Repository.Interface;
using NUnit.Framework;
using System.Collections.Generic;
using MyUserManagement.Controllers;
using Microsoft.AspNetCore.Mvc;
using MyUserManagement.Data.Model;

#endregion Namespaces

namespace MyUserManagement.Test
{
   public class UserContollerTest
    {
        #region Test Methods

        /// <summary>
        /// Redirect to Modelize action method Positive Test
        /// </summary>
        /// <return></return>
        [Theory]
        public  void IndexRedirectionPositive()
        {
            var mockIUserRepository = new Mock<IUserRepository>();
            var mockIValidate = new Mock<IValidate>();
            var mockIHostingEnvironment = new Mock<IHostingEnvironment>();
            var mockIUserFile = new Mock<IUserFile>();
            var mockISessionRepository = new Mock<ISessionRepository>();
            var userController = new UserController(mockIUserRepository.Object, mockIValidate.Object, mockIHostingEnvironment.Object, mockIUserFile.Object, mockISessionRepository.Object);
            var controllerContext = new ControllerContext();
            //Act
            var result = (RedirectToActionResult) userController.Index();

            //Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            Assert.AreEqual("User", result.ControllerName);
            Assert.AreEqual("Modelize", result.ActionName);
        }
        /// <summary>
        /// Redirect to Modelize action method Negative Test
        /// </summary>
        /// <return></return>
        [Theory]
        public void IndexRedirectionNegative()
        {
            var mockIUserRepository = new Mock<IUserRepository>();
            var mockIValidate = new Mock<IValidate>();
            var mockIHostingEnvironment = new Mock<IHostingEnvironment>();
            var mockIUserFile = new Mock<IUserFile>();
            var mockISessionRepository = new Mock<ISessionRepository>();
            var userController = new UserController(mockIUserRepository.Object, mockIValidate.Object, mockIHostingEnvironment.Object, mockIUserFile.Object, mockISessionRepository.Object);
            var controllerContext = new ControllerContext();
            //Act
            var result = (RedirectToActionResult)userController.Index();

            //Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            Assert.AreEqual("User", result.ControllerName);
            Assert.AreNotEqual("Index", result.ActionName);
        }

        /// <summary>
        ///  Modelize User for Positive Test
        /// </summary>
        /// <return></return>
        [Theory]
        public void ModelizePositiveTest()
        {
            var mockIUserRepository = new Mock<IUserRepository>();
            var mockIValidate = new Mock<IValidate>();
            var mockIHostingEnvironment = new Mock<IHostingEnvironment>();
            var mockIUserFile = new Mock<IUserFile>();
            var mockISessionRepository = new Mock<ISessionRepository>();
            var userController = new UserController(mockIUserRepository.Object, mockIValidate.Object, mockIHostingEnvironment.Object, mockIUserFile.Object, mockISessionRepository.Object);
            List<UserModel> dummylstUser =DummyUser();
            List<UserModel> lstUser = new List<UserModel>();
            var userlst = mockISessionRepository.Setup(x => x.GetSession()).Returns(dummylstUser);            
            var user=mockIUserRepository.Setup(x => x.UsermodelInitialize()).Returns(lstUser);
            mockIUserRepository.Setup(x => x.UsermodelModelize());
            var controllerContext = new ControllerContext();
            
            //Act

            var result = userController.Modelize();

            //Assert

            Assert.NotNull(result);
            if(result is ViewResult okResult)
            {
                Assert.AreEqual(dummylstUser, okResult.Model);
                //Assert.AreEqual("User", okResult.ControllerName);
                //Assert.AreNotEqual("Index", result.ActionName);
            }           
            Assert.IsAssignableFrom<ViewResult>(result);           
        }

        
        /// <summary>
        ///  Get Women having Age less than 25 PositiveTest
        /// </summary>
        /// <return></return>
        [Theory]
        public void GetWomenhavingAgelessthan25PositiveTest()
        {
            var mockIUserRepository = new Mock<IUserRepository>();
            var mockIValidate = new Mock<IValidate>();
            var mockIHostingEnvironment = new Mock<IHostingEnvironment>();
            var mockIUserFile = new Mock<IUserFile>();
            var mockISessionRepository = new Mock<ISessionRepository>();
            var userController = new UserController(mockIUserRepository.Object, mockIValidate.Object, mockIHostingEnvironment.Object, mockIUserFile.Object, mockISessionRepository.Object);
            List<UserModel> dummylstUser = DummyUserAgelessthan25();
            mockIUserRepository.Setup(x => x.GetWomenAgelessthan25()).Returns(dummylstUser);        
            var controllerContext = new ControllerContext();
           
            //Act

            var result = userController.GetWomenhavingAgelessthan25(); 

            //Assert

            Assert.NotNull(result);
            if (result is ViewResult okResult)
            {
                Assert.AreEqual(dummylstUser, okResult.Model);
                //Assert.AreEqual("User", okResult.ControllerName);
                //Assert.AreNotEqual("Index", result.ActionName);
            }
            Assert.IsAssignableFrom<ViewResult>(result);        
        }

        /// <summary>
        ///  Get Youngest Man PositiveTest
        /// </summary>
        /// <return></return>
        [Theory]
        public void GetYoungestManPositiveTest()
        {
            var mockIUserRepository = new Mock<IUserRepository>();
            var mockIValidate = new Mock<IValidate>();
            var mockIHostingEnvironment = new Mock<IHostingEnvironment>();
            var mockIUserFile = new Mock<IUserFile>();
            var mockISessionRepository = new Mock<ISessionRepository>();
            var userController = new UserController(mockIUserRepository.Object, mockIValidate.Object, mockIHostingEnvironment.Object, mockIUserFile.Object, mockISessionRepository.Object);
            List<UserModel> dummylstUser = DummyUserYoungestMan();
            mockIUserRepository.Setup(x => x.GetYoungestMen()).Returns(dummylstUser);
            var controllerContext = new ControllerContext();
            //Act
            var result = userController.GetYoungestMan();

            //Assert

            Assert.NotNull(result);
            if (result is ViewResult okResult)
            {
                Assert.AreEqual(dummylstUser, okResult.Model);
                //Assert.AreEqual("User", okResult.ControllerName);
                //Assert.AreNotEqual("Index", result.ActionName);
            }
            Assert.IsAssignableFrom<ViewResult>(result);
        }

        /// <summary>
        ///  All Managers Name Having Name starting with JO PositiveTest
        /// </summary>
        /// <return></return>
        [Theory]
        public void AllManagersNameHavingNamewithJOPositiveTest()
        {
            var mockIUserRepository = new Mock<IUserRepository>();
            var mockIValidate = new Mock<IValidate>();
            var mockIHostingEnvironment = new Mock<IHostingEnvironment>();
            var mockIUserFile = new Mock<IUserFile>();
            var mockISessionRepository = new Mock<ISessionRepository>();
            var userController = new UserController(mockIUserRepository.Object, mockIValidate.Object, mockIHostingEnvironment.Object, mockIUserFile.Object, mockISessionRepository.Object);
            List<UserModel> dummylstUser = DummyUserManagerNamewithJO();
            mockIUserRepository.Setup(x => x.GetAllManagersNameHavingNamewithJO()).Returns(dummylstUser);
            var controllerContext = new ControllerContext();
            //Act
            var result = userController.AllManagersNameHavingNamewithJO();

            //Assert

            Assert.NotNull(result);
            if (result is ViewResult okResult)
            {
                Assert.AreEqual(dummylstUser, okResult.Model);
                //Assert.AreEqual("User", okResult.ControllerName);
                //Assert.AreNotEqual("Index", result.ActionName);
            }
            Assert.IsAssignableFrom<ViewResult>(result);
        }
        /// <summary>
        ///  All Womens Role in Manager and Admin PositiveTest
        /// </summary>
        /// <return></return>
        [Theory]
        public void AllWomenRoleinManagerandAdminPositiveTest()
        {
            var mockIUserRepository = new Mock<IUserRepository>();
            var mockIValidate = new Mock<IValidate>();
            var mockIHostingEnvironment = new Mock<IHostingEnvironment>();
            var mockIUserFile = new Mock<IUserFile>();
            var mockISessionRepository = new Mock<ISessionRepository>();
            var userController = new UserController(mockIUserRepository.Object, mockIValidate.Object, mockIHostingEnvironment.Object, mockIUserFile.Object, mockISessionRepository.Object);
            List<UserModel> dummylstUser = DummyUserWomenRoleinManagerandAdmin();
            mockIUserRepository.Setup(x => x.GetAllWomenRoleinManagerandAdmin()).Returns(dummylstUser);
            var controllerContext = new ControllerContext();
            //Act
            var result = userController.AllWomenRoleinManagerandAdmin();

            //Assert

            Assert.NotNull(result);
            if (result is ViewResult okResult)
            {
                Assert.AreEqual(dummylstUser, okResult.Model);
                //Assert.AreEqual("User", okResult.ControllerName);
                //Assert.AreNotEqual("Index", result.ActionName);
            }
            Assert.IsAssignableFrom<ViewResult>(result);
        }
        /// <summary>
        ///  Men having Age grater than 40 PositiveTest
        /// </summary>
        /// <return></return>
        [Theory]
        public void MenhavingAgegraterthan40PositiveTest()
        {
            var mockIUserRepository = new Mock<IUserRepository>();
            var mockIValidate = new Mock<IValidate>();
            var mockIHostingEnvironment = new Mock<IHostingEnvironment>();
            var mockIUserFile = new Mock<IUserFile>();
            var mockISessionRepository = new Mock<ISessionRepository>();
            var userController = new UserController(mockIUserRepository.Object, mockIValidate.Object, mockIHostingEnvironment.Object, mockIUserFile.Object, mockISessionRepository.Object);
            List<UserModel> dummylstUser = DummyUserAgegreaterthan40();
            mockIUserRepository.Setup(x => x.GetMenhavingAgegraterthan40()).Returns(dummylstUser);
            var controllerContext = new ControllerContext();
            //Act
            var result = userController.MenhavingAgegraterthan40();

            //Assert

            Assert.NotNull(result);
            if (result is ViewResult okResult)
            {
                Assert.AreEqual(dummylstUser, okResult.Model);
                //Assert.AreEqual("User", okResult.ControllerName);
                //Assert.AreNotEqual("Index", result.ActionName);
            }
            Assert.IsAssignableFrom<ViewResult>(result);
        }
        /// <summary>
        ///  Write File
        /// </summary>
        /// <return></return>
        [Theory]
        public void WriteFilePositiveTest()
        {
            var mockIUserRepository = new Mock<IUserRepository>();
            var mockIValidate = new Mock<IValidate>();
            var mockIHostingEnvironment = new Mock<IHostingEnvironment>();
            var mockIUserFile = new Mock<IUserFile>();
            var mockISessionRepository = new Mock<ISessionRepository>();
            var userController = new UserController(mockIUserRepository.Object, mockIValidate.Object, mockIHostingEnvironment.Object, mockIUserFile.Object, mockISessionRepository.Object);
            List<UserModel> lstUser = DummyUserAgegreaterthan40();
            mockIUserFile.Setup(x => x.CreateFile());
            var controllerContext = new ControllerContext();
            //Act
            var result = userController.Writefile();

            //Assert

            Assert.IsAssignableFrom<ViewResult>(result);
            //Assert.AreEqual("User", result.ControllerName);
            //Assert.AreNotEqual("Index", result.ActionName);
        }
       


        #endregion

        #region Private Methods
        public static List<UserModel> DummyUser()
        {
            List<UserModel> model = new List<UserModel>()
            {
                new UserModel{ Id = 1, Firstname = "Aan",Lastname="Maria",Gender="Male", Age = 22,Roles=new List<string>{"Manager","Employee","Admin"}},
                new UserModel{ Id = 2, Firstname = "Niveda",Lastname="Abhi",Gender="Female", Age = 23,Roles=new List<string>{"Manager","Admin"}},
                new UserModel{ Id = 3, Firstname = "Aadu",Lastname="Abhi",Gender="Female", Age = 30 ,Roles=new List<string>{"Employee","Admin"}},
                new UserModel{ Id = 4, Firstname = "Vaibhav",Lastname="Ash",Gender="Male", Age = 48,Roles=new List<string>{"Admin"}},
                new UserModel{ Id = 5, Firstname = "Gokul",Lastname="Rai",Gender="Male", Age = 35 ,Roles=new List<string>{"Manager","Employee"}},
                new UserModel{ Id = 6, Firstname = "Mary",Lastname="Wayne",Gender="Female", Age = 29,Roles=new List<string>{"Manager"}},
                new UserModel{ Id = 7, Firstname = "Eric",Lastname="John",Gender="Male", Age = 30 ,Roles=new List<string>{"Employee","Admin" }},
                new UserModel{ Id = 9, Firstname = "Janifer",Lastname="Watler",Gender="Female", Age = 21,Roles=new List<string>{"Manager","Admin" }},
                new UserModel{ Id = 10, Firstname = "Joal",Lastname="Shanmuk",Gender="Male", Age = 35 ,Roles=new List<string>{"Manager","Employee","Admin" }},

            };
            return model;
        }
        public static List<UserModel> DummyUserNegative()
        {
            List<UserModel> model = new List<UserModel>()
            {
                new UserModel{ Id = 1, Firstname = "Aryan",Lastname="Maria",Gender="Male", Age = 22,Roles=new List<string>{"Manager","Employee","Admin"}},
                new UserModel{ Id = 2, Firstname = "Lovely",Lastname="Abhi",Gender="Female", Age = 23,Roles=new List<string>{"Manager","Admin"}},
                new UserModel{ Id = 3, Firstname = "Shanu",Lastname="Abhi",Gender="Female", Age = 30 ,Roles=new List<string>{"Employee","Admin"}},
                new UserModel{ Id = 4, Firstname = "Vaibhav",Lastname="Ash",Gender="Male", Age = 48,Roles=new List<string>{"Admin"}},
               

            };
            return model;
        }
        public static List<UserModel> DummyUserAgelessthan25()
        {
            List<UserModel> model = new List<UserModel>()
            {               
                new UserModel{ Id = 2, Firstname = "Niveda",Lastname="Abhi",Gender="Female", Age = 23,Roles=new List<string>{"Manager","Admin"}},                
                new UserModel{ Id = 9, Firstname = "Janifer",Lastname="Watler",Gender="Female", Age = 21,Roles=new List<string>{"Manager","Admin" }}               
            };
            return model;
        }
        public static List<UserModel> DummyUserYoungestMan()
        {
            List<UserModel> model = new List<UserModel>()
            {
                new UserModel{ Id = 1, Firstname = "Aan",Lastname="Maria",Gender="Male", Age = 22,Roles=new List<string>{"Manager","Employee","Admin"}}             

            };
            return model;
        }
        public static List<UserModel> DummyUserManagerNamewithJO()
        {
            List<UserModel> model = new List<UserModel>()
            {
               
                new UserModel{ Id = 10, Firstname = "Joal",Lastname="Shanmuk",Gender="Male", Age = 35 ,Roles=new List<string>{"Manager","Employee","Admin" }}

            };
            return model;
        }
        public static List<UserModel> DummyUserWomenRoleinManagerandAdmin()
        {
            List<UserModel> model = new List<UserModel>()
            {                
                new UserModel{ Id = 2, Firstname = "Niveda",Lastname="Abhi",Gender="Female", Age = 23,Roles=new List<string>{"Manager","Admin"}},           
                new UserModel{ Id = 9, Firstname = "Janifer",Lastname="Watler",Gender="Female", Age = 21,Roles=new List<string>{"Manager","Admin" }}
             };
            return model;
        }
        public static List<UserModel> DummyUserAgegreaterthan40()
        {
            List<UserModel> model = new List<UserModel>()
            { 
                new UserModel{ Id = 4, Firstname = "Vaibhav",Lastname="Ash",Gender="Male", Age = 48,Roles=new List<string>{"Admin"}}
            };
            return model;
        }
        #endregion Private Methods



    }
}
