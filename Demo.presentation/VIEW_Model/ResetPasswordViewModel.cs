using System.ComponentModel.DataAnnotations;

namespace Demo.presentation.VIEW_Model
{
    public class ResetPasswordViewModel
    {

        [DataType(DataType.Password)]
        public string Password {  get; set; }


        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
