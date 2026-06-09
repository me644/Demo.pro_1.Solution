using System.ComponentModel.DataAnnotations;

namespace Demo.presentation.VIEW_Model
{
    public class LoginViewModel
    {

        [Required(ErrorMessage = "required!!")]
        [MaxLength(50)]
     //   public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Password)]

        public string Password { get; set; }

        public bool RememberMe { get; set; }


    }
}
