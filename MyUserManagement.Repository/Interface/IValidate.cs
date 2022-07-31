using System;
using System.Collections.Generic;
using System.Text;

namespace MyUserManagement.Repository.Interface
{
   public interface IValidate
    {
        public bool ValidateAge(string age);
        public bool ValidateGender(string gender);
    }
}
