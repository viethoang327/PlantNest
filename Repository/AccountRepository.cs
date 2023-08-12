using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using PlantNestApp.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PlantNestApp.Repository
{
	public class AccountRepository : IAccountRepository
	{
		
        private UserManager<CustomerUser> userManager;
		private SignInManager<CustomerUser> signInManager;
		private RoleManager<IdentityRole> roleManager;


		private IConfiguration Configuartion;

		public AccountRepository(
			UserManager<CustomerUser> _userManager , 
			SignInManager<CustomerUser> _SingInManager,
			IConfiguration _Configuartion,
			RoleManager<IdentityRole> _roleManager)  
		{
			this.userManager = _userManager;
			this.signInManager = _SingInManager;
			this.Configuartion = _Configuartion;
			this.roleManager = _roleManager;
		}

		

		public async Task<IdentityResult> DeleteRole()
		{
			var User = new CustomerUser();
			
			
			List<string> roles = new List<string> { "Admin", "User" };
			foreach (var r in roles)
			{
				// Kiểm tra xem vai trò đã tồn tại chưa

				var checker = await roleManager.RoleExistsAsync(r);
				
			}
			var result = await userManager.FindByIdAsync(User.Id);
			if (result != null)
			{
				var res = await userManager.RemoveFromRolesAsync(User, roles);
				if (res.Succeeded)
				{
					Console.WriteLine("Quyền đã được xóa thành công cho người dùng.");
					return res;
				}
				else
				{
					Console.WriteLine("Có lỗi xảy ra khi xóa quyền cho người dùng.");
				}
			}
			else
			{
				Console.WriteLine("Không tìm thấy người dùng.");
			}
			return null;
			
		}
			
		

		public  async Task<string> SingInAsync(SingIn model)
		{
			var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
			if (!result.Succeeded )
			{
				return string.Empty;
			}
			var authClaims = new List<Claim>
			{
				new Claim(ClaimTypes.Email,model.Email),
				new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
				
			};
			var authenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuartion["JWT:Secret"]));
			var token = new JwtSecurityToken(
			  issuer: Configuartion["JWT:ValidIssuer"],
			  audience: Configuartion["JWT:ValidAudience"],
			  expires: DateTime.Now.AddMinutes(20),
			  claims: authClaims,
			  signingCredentials: new SigningCredentials(authenKey, SecurityAlgorithms.HmacSha512Signature)
		  );
			return new JwtSecurityTokenHandler().WriteToken(token);
		}

		

		public async Task<IdentityResult> SingUpAsync(SingUp model)
		{
			var User = new CustomerUser
			{
				FullName = model.FullName,
				Email = model.Email,
				UserName = model.Email,

			};
			var result = await userManager.CreateAsync(User, model.Password);
			if (result.Succeeded)
			{
				// Kiểm tra xem vai trò đã tồn tại chưa

				var checker = await roleManager.RoleExistsAsync("User");
				if (!checker)
				{
					// Tạo vai trò mới
					var role = new IdentityRole("User");
					await roleManager.CreateAsync(role);
				}
				//Add quyen
				await userManager.AddToRoleAsync(User, "User");
			//	await userManager.AddToRoleAsync(User, "Admin");
			}

			return result;
		}

		public async Task<IdentityResult> SingUpAsyncss(SingUp model)
		{
			var User = new CustomerUser
			{
				FullName = model.FullName,
				Email = model.Email,
				UserName = model.Email,

			};
			var result = await userManager.CreateAsync(User, model.Password);
			List<string> roles = new List<string> { "Admin", "User" };
			foreach (var r in roles)
			{
				// Kiểm tra xem vai trò đã tồn tại chưa

				var checker = await roleManager.RoleExistsAsync(r);
				if (!checker)
				{
					// Tạo vai trò mới
					var role = new IdentityRole(r);
					await roleManager.CreateAsync(role);
				}
			}
			var user = await userManager.FindByIdAsync(User.Id);
			if (user != null)
			{
				var res = await userManager.AddToRolesAsync(user, roles);
				if (res.Succeeded)
				{
					Console.WriteLine("Quyền đã được thiết lập thành công cho người dùng.");
				}
				else
				{
					Console.WriteLine("Có lỗi xảy ra khi thiết lập quyền cho người dùng.");

				}

			}
			return result;
		}
	}
}
