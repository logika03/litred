using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace PL.ViewModels.User
{
    public class EditUserViewModel
    {
        public string Id { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [DataType(DataType.Text)]
        public string ImagePath { get; set; }


        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        public IFormFile Image { get; set; }

    }
}