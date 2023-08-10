using Microsoft.AspNetCore.Identity;

namespace PlantNestApp.Models
{
	public class CustomerUser : IdentityUser
	{
		public string? FullName { get; set; }

	}
}
