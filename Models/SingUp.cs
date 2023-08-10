using System.ComponentModel.DataAnnotations;

namespace PlantNestApp.Models
{
	public class SingUp
	{
		public string? FullName { get; set; }
		[Required]
		public string? Email { get; set; }
		[Required]
		public string? Password { get; set; }
		[Required]
		public string? ConfirmPassword { get; set; }

	}
}
