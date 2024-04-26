using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models.Authentification {
    public class UserLogin {

        [EmailAddress]
        public required string Username { get; set; }

        [StringLength(100, MinimumLength = 6)]
        public required string Password { get; set; }

    }
}