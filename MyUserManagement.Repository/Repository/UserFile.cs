using Microsoft.AspNetCore.Hosting;
using MyUserManagement.Data.Model;
using MyUserManagement.Repository.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MyUserManagement.Repository.Repository
{
    public class UserFile : IUserFile
    {
        private IUserRepository userRepository;
        private IHostingEnvironment env;
       
        public UserFile(IUserRepository _userRepository, IHostingEnvironment _env)
        {
            userRepository = _userRepository;           
            env = _env;
            

        }
        public void CreateFile()
        {
            var gender = "";
            var path = Path.Combine(env.ContentRootPath, @"TxtFile\" + "UsertextFile.txt");

            using (FileStream fs = System.IO.File.Create(path))
            {
                List<UserModel> lstUserModel = userRepository.GetdataListSession();

                foreach (UserModel lst in lstUserModel)
                {
                    var strRole = "";
                    gender = "";
                    gender = (lst.Gender == "Male" ? "Man" : "Women");
                    strRole = userRepository.RolesById(lst.Id);
                    byte[] content = new UTF8Encoding(true).GetBytes(lst.Firstname + "  " + lst.Lastname + " is " + lst.Age + " old. It is a " + gender + ". He has the following roles " + strRole + "\r\n" + "\r\n");

                    fs.Write(content, 0, content.Length);
                    
                }


            }
        }
    }
}
