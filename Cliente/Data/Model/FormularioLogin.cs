using System.ComponentModel.DataAnnotations;

namespace CLiente.Data.Model
{
    public class FormularioLogin
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = "";
    }

    public class AuthTokenResponse
    {
        public int Status { get; set; } 
        public string Mensaje { get; set; }
        public string TokenType { get; set; } = string.Empty; 
        public string AccessToken { get; set; } = string.Empty;
        public int ExpiresIn { get; set; } 
        public string RefreshToken { get; set; } = string.Empty; 
    }

    public class ValidationErrorResponse
    {
        public string Type { get; set; } = string.Empty; 
        public string Title { get; set; } = string.Empty; 
        public int Status { get; set; } 
        public Dictionary<string, List<string>> Errors { get; set; } = new();
    }

    public class FormularioRegister
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; } = "";

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; } = "";

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; } = "";
    }
}
