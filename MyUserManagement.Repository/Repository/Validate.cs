using MyUserManagement.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyUserManagement.Repository.Repository
{
   public class Validate :IValidate
    {
        public bool ValidateAge(string age)
        {
            string numAge = age;
            int uage = 0;
            bool userAge = int.TryParse(numAge, out uage);
            return userAge;

        }
        public bool ValidateGender(string gender)
        {
            bool genresult;
            if (gender == "Female" || gender == "Male" ||gender== "male" || gender == "female" || gender == "m" || gender == "f" || gender == "F" || gender == "M")
            {
                genresult = true;
            }
            else
            {
                genresult = false;
            }

            return genresult;

        }
    }
}
