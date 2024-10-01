using System.ComponentModel.DataAnnotations;

namespace LinkDev.IKEA3.PL.ViewModels.Identity
{
    public class SignInViewModel
    {

        public string Email { get; set; } = null!;
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
        public bool RememberMe { get; set; }


    }
}
