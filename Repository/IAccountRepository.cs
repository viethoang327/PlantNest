using Microsoft.AspNetCore.Identity;
using PlantNestApp.Models;

namespace PlantNestApp.Repository
{
	public interface IAccountRepository
	{
		public  Task<IdentityResult> SingUpAsync(SingUp model);
		public Task<string> SingInAsync(SingIn model);

		

		public Task<IdentityResult> SingUpAsyncss(SingUp model);
		public Task<IdentityResult> DeleteRole();

	}
}
