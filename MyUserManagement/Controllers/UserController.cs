
#region Namespaces

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyUserManagement.Data.Model;
using MyUserManagement.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

#endregion Namespaces


namespace MyUserManagement.Controllers
{
    public class UserController : Controller
    {
        
            #region Private variables  
            
            private IUserRepository userRepository;
            private IValidate validate;
            private IHostingEnvironment env;
            private IUserFile userFile;
            private ISessionRepository sessionRepository;

        #endregion Private variables

        #region Constructor
        /// <summary>
        /// The Constructor for User Controller
        /// </summary>        
        /// <param name="_userRepository"></param>
        /// <param name="_validate"></param>
        /// <param name="_env"></param>
        /// <param name="_userFile"></param>        
        /// <param name="_sessionRepository"></param>
        public UserController(IUserRepository _userRepository,IValidate _validate, IHostingEnvironment _env, IUserFile _userFile,ISessionRepository _sessionRepository)
            {
                userRepository = _userRepository;
                validate = _validate;
                env = _env;
                userFile = _userFile;
                sessionRepository = _sessionRepository; 

            }
        #endregion Constructor

        /// <summary>
        /// Redirect to modelize action method 
        /// </summary>        
        /// <param></param>      
        public ActionResult Index()
            {
                try 
                {
                    return RedirectToAction("Modelize", "User");
                }
           
                catch (Exception ex)
                {
                    return View("Error");
                }       
                
            }
            /// <summary>
            /// To get the Modelized User Details and set session
            /// </summary>
            /// <param></param>        
            public ActionResult Modelize()
            {
                
                userRepository.UsermodelModelize();
                var lstuser=sessionRepository.GetSession();
                if(lstuser==null)
                {
                 lstuser = userRepository.UsermodelInitialize();
                }
                return View(lstuser.ToList());
            }
            /// <summary>
            /// To get the Details of all users having gender Females and age<25
            /// </summary>
            /// <param></param>        
            public ActionResult GetWomenhavingAgelessthan25()
            {
                List<UserModel> lstUserModel = userRepository.GetWomenAgelessthan25();
                return View("Modelize", lstUserModel);
            }
            /// <summary>
            /// To get the Youngest Man
            /// </summary>
            /// <param></param>        
            public ActionResult GetYoungestMan()
            {
                List<UserModel> lstUserModel = userRepository.GetYoungestMen();
                return View("Modelize", lstUserModel);
            }

            /// <summary>
            /// To get the Manager Name having JO
            /// </summary>
            /// <param></param>        
            public ActionResult AllManagersNameHavingNamewithJO()
            {
                List<UserModel> lstUserModel = userRepository.GetAllManagersNameHavingNamewithJO();
                return View("Modelize", lstUserModel);
            }
            /// <summary>
            /// To get the all women role in admin and manager
            /// </summary>
            /// <param></param>        
            public ActionResult AllWomenRoleinManagerandAdmin()
            {
                List<UserModel> lstUserModel = userRepository.GetAllWomenRoleinManagerandAdmin();
                return View("Modelize", lstUserModel);
            }
            /// <summary>
            /// To get the men having age >48
            /// </summary>
            /// <param></param>        
            public ActionResult MenhavingAgegraterthan40()
            {
                List<UserModel> lstUserModel = userRepository.GetMenhavingAgegraterthan40();
                return View("Modelize", lstUserModel);
            }

            /// <summary>
            /// To validate Age
            /// </summary>
            /// <param></param>    
            public IActionResult ValidateAge(string age)
                {
                    bool userAges = validate.ValidateAge(age);
                    if (userAges == false)
                    {
                        return Json($"Please enter numerical value for Age.");
                    }
                    return Json(true);
                }
            /// <summary>
            /// To validate gender
            /// </summary>
            /// <param></param>    
            public IActionResult ValidateGender(string gender)
                {
                    bool userAges = validate.ValidateGender(gender);
                    if (userAges == false)
                    {
                        return Json($"Please enter gender as Female or Male");
                    }
                    return Json(true);
                }
            /// <summary>
            /// To create a file and write user details into It
            /// </summary>
            /// <param></param>    
            public ActionResult Writefile()
                {
                    userFile.CreateFile();
                    return View();
                }
            /// <summary>
            /// To create User
            /// 
            /// </summary>
            /// <param></param> 
            public ActionResult Create()
                {
                return View();
                }


    }
}
