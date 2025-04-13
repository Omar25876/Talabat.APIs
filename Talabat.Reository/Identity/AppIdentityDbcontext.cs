using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Talabat.Core.Entities.Identity;

namespace Talabat.Repository.Identity
{
	public class AppIdentityDbcontext : IdentityDbContext<AppUser>
	{
		public AppIdentityDbcontext(DbContextOptions<AppIdentityDbcontext> options) : base(options)
		{

		}
	}
}
