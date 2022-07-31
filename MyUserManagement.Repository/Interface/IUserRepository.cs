using MyUserManagement.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyUserManagement.Repository.Interface
{
    public interface IUserRepository
    {     
            public void UsermodelModelize();
            public List<UserModel> GetWomenAgelessthan25();
            public List<UserModel> GetYoungestMen();
            public List<UserModel> GetMenhavingAgegraterthan40();
            public List<UserModel> GetAllWomenRoleinManagerandAdmin();
            public List<UserModel> GetAllManagersNameHavingNamewithJO();
            public string RolesById(int Id);
            public List<UserModel> GetdataListSession();
            public List<UserModel> UsermodelInitialize(); 
    }
}
