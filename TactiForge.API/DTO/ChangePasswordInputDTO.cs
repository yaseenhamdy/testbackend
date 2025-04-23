using System.ComponentModel.DataAnnotations;

namespace TactiForge.API.DTO
{
    public class ChangePasswordInputDTO
    {
        public string Email { get; set; }




        public String OldPassword { get; set; }




        [Required(ErrorMessage = "New password is required")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$",
        ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one digit, and one special character")]
        public string NewPassword { get; set; }
    }


}
