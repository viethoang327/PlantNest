using Microsoft.AspNetCore.Identity;
using PlantNestApp.DataTransferObject.UserDTO;
using PlantNestApp.Models;

namespace PlantNestApp.Repository
{
	public interface IAccountRepository
	{
		public  Task<IdentityResult> SingUpAsync(SingUp model);
		public Task<LoginToken> SingInAsync(SingIn model);

		

		public Task<IdentityResult> SingUpAsyncss(SingUp model);
		public Task<IdentityResult> DeleteRole();

	}
}
