using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjectA.Models.Models
{
    public class ChangePasswordModel
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Подтверждение пароля")]
        [Compare("Password", ErrorMessage = "Пароль и подтверждение пароля не совпадают")]
        public string ConfirmationPassword { get; set; }
    }
}
