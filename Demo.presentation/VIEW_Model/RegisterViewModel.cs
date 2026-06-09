using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Demo.presentation.VIEW_Model
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "required!!")]
        [MaxLength(50)]
        public string UserName { get; set; }



        [Required(ErrorMessage = "required!!")]
        [MaxLength(50)]
        public string FirstName { get; set; }



        [Required(ErrorMessage = "required!!")]
        [MaxLength(50)]
        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Password)]

        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

         public      bool IsAgreed { get; set; }
    }
    }
