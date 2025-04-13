using System.ComponentModel.DataAnnotations;

namespace Talabat.APIs.DTOs
{
	public class LoginDto
	{

		[Required]
		[EmailAddress]
		public string Email { get; set; }
		 
		[Required]
		[RegularExpression("(?=.*[A-Z])(?=.*[a-z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}",
		ErrorMessage = "Password must be at least 8 characters long, contain an uppercase letter, a lowercase letter, a number, and a special character.")]
		public string Password { get; set; }
	}
}
