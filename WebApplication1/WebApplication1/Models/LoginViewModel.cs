using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Username is Required.")]
        public string Username { get; set; }
        [Required(ErrorMessage ="Password is Required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name ="Remember Me")]
        public bool RememberMeSet { get; set; }
    }
}
