


using System.ComponentModel.DataAnnotations;

namespace Demo.presentation.VIEW_Model
{
    public class ForgetViewModel
    {
        [Required(ErrorMessage ="required!!")]
        [EmailAddress]
      public string Email { get; set; }
    }
}
