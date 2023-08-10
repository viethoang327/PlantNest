using System.ComponentModel.DataAnnotations;

namespace PlantNestApp.Models
{
	public class SingIn
	{
		[Required]
		public string? Email { get; set; }
		[Required]
		public string? Password { get; set;}
	}
}
