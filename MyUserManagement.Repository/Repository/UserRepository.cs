using MyUserManagement.Data.Model;
using MyUserManagement.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyUserManagement.Repository.Repository
{
    public class UserRepository:IUserRepository
    {
        private ISessionRepository sessionRepository;
       
        public UserRepository(ISessionRepository _sessionRepository)
        {
            sessionRepository = _sessionRepository;          
        }
        public List<UserModel> GetAllManagersNameHavingNamewithJO()
        {
            List<UserModel> lstUserModel = GetdataListSession(); 

            lstUserModel = lstUserModel.Where(x => x.Roles.Contains("Manager") && x.Firstname.StartsWith("Jo")).ToList();
            return lstUserModel;
        }

        public List<UserModel> GetAllWomenRoleinManagerandAdmin()
        {
            List<UserModel> lstUserModel =  GetdataListSession();
            lstUserModel = lstUserModel.Where(x => x.Gender.Contains("Female") && x.Roles.Contains("Manager") && x.Roles.Contains("Admin")).ToList();
            return lstUserModel;
        }

        public List<UserModel> GetMenhavingAgegraterthan40()
        {
            List<UserModel> lstUserModel = GetdataListSession();
            lstUserModel = lstUserModel.Where(x => x.Age > (40) && x.Gender.Contains("Male")).ToList();
            return lstUserModel;
        }

        public List<UserModel> GetWomenAgelessthan25()
        {
            List<UserModel> lstUserModel = GetdataListSession();
            lstUserModel = lstUserModel.Where(x => x.Age < (25) && x.Gender.Contains("Female")).ToList();
            return lstUserModel;
        }

        public List<UserModel> GetYoungestMen()
        {
            List<UserModel> lstUserModel = GetdataListSession();
            lstUserModel = lstUserModel.Where(x => x.Gender.Contains("Male")).OrderBy(x => x.Age).Skip(0).Take(1).ToList();
            return lstUserModel;
        }

        public string RolesById(int Id)
        {
            var lstUserRoles = "";
            List<UserModel> lstUserModel = GetdataListSession();

            lstUserModel = lstUserModel.Where(x => x.Id.Equals(Id)).ToList();                      

            foreach (UserModel lst in lstUserModel)
            {
                foreach (string lstrole in lst.Roles)
                {                  
                    lstUserRoles = (lstUserRoles == " ") ? " " : lstUserRoles + ", " + lstrole;
                    lstUserRoles = lstUserRoles.TrimStart(',');
                }
            }
            return lstUserRoles;
        }

        /// <summary>
        /// Intialize User
        /// </summary>
        /// <param></param>
        /// <returns>List of users</returns>
        public List<UserModel> UsermodelInitialize()
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
        /// <summary>
        /// Modelize User
        /// </summary>
        /// <param></param>
        /// <returns>List of users</returns>
        public void UsermodelModelize()
        {
            List<UserModel> usermodel = UsermodelInitialize();
            sessionRepository.SetSession(usermodel);            
        }       
        public List<UserModel> GetdataListSession()
        {
            var lstuser = sessionRepository.GetSession();                      
            return lstuser.ToList();
        }    
        
    }
}
