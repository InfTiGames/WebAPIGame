using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models.Authentification {
    public class UserRegister {

        [EmailAddress]
        public required string Email { get; set; }

        [StringLength(100, MinimumLength = 6)]
        public required string Password { get; set; }

        [Compare("Password", ErrorMessage = "The passwords do not match")]
        public string ConfirmPassword { get; set; } = default!;
    }
}