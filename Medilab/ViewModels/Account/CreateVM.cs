using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Medilab.ViewModels.Account
{
    public class CreateVM
    {
        [Required,EmailAddress]
        public string Email { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [Required,DataType(DataType.Password),Display(Name = "Confirm Password"),Compare(nameof(Password),ErrorMessage ="Please be sure your passwords match.")]

        public string CheckPassword { get; set; }
    }
}
