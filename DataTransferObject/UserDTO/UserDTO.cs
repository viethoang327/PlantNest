using Microsoft.AspNetCore.Identity;

namespace PlantNestApp.DataTransferObject.UserDTO
{
	public class UserDTO : IdentityUser
	{
		public int UserId { get; set; }
	}
}
