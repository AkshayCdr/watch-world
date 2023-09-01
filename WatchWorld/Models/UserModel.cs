using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WatchWorld.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is required")]
        [Display(Name ="User name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage ="Enter valid email")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Age is required")]
        [Display(Name = "Age")]
        [Range(18, 70, ErrorMessage = "Must be between 18 and 70")]
        public int Age { get; set; }
    }
}