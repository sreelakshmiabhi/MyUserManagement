using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace MyUserManagement.Data.Model
{
    public class UserModel
    {

        [Required()]
        //[Range(0, int.MaxValue, ErrorMessage = "Please enter a numeric Value.")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Please enter Numeric Value Only.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is Required")]
        [DisplayName("First Name")]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Last Name is Required")]
        [DisplayName("Last Name")]        
        public string Lastname { get; set; }
        [Required(ErrorMessage = "Gender is Required")]
        [Remote("ValidateGender", "User")]
        [RegularExpression("(^([mM][aA][lL][eE]|[fF][eE][mM][aA][lL][eE])$)", ErrorMessage = "Please enter Male/Female/male/female Only.")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Age is Required")]       
        //[Range(0, int.MaxValue, ErrorMessage = "Please enter a numeric Value.")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Please enter Numeric Value Only.")]
        //[Remote("ValidateAge", "User")]
        [DisplayName("Age")]
        [MaxLength(3)]      
        public int Age { get; set; }
        public string Role { get; set; }

        public List<string> Roles { get; set; }
    }
}