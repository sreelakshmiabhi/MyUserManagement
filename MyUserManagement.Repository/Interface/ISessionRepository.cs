using Microsoft.AspNetCore.Http;
using MyUserManagement.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyUserManagement.Repository.Interface
{
   public interface ISessionRepository
    {
        public void SetSession(List<UserModel> model);
        public List<UserModel> GetSession();
    }
}
