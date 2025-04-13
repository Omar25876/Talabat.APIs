using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities.Identity;

namespace Talabat.Repository.Identity
{
	public class AppIdentityDbContextSeed
	{
		public static async Task SeedUserAsync(UserManager<AppUser> userManager)
		{
			if (!userManager.Users.Any()) 
			{ 
				var User = new AppUser()
				{
					DisplayName = "Omar Mohamed",
					Email = "ooo111@gmail.com",
					PhoneNumber = "0105555555",
					UserName = "ooo111"
				};

				await userManager.CreateAsync(User, "Omar@2222");

			}


		}
	}
}
