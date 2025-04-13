
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using Talabat.APIs.Errors;
using Talabat.APIs.Extensions;
using Talabat.APIs.Helpers;
using Talabat.APIs.Middlewares;
using Talabat.Core.Entities.Identity;
using Talabat.Core.Repositories;
using Talabat.Reository;
using Talabat.Reository.Data;
using Talabat.Repository.Identity;

namespace Talabat.APIs
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

		
			#region Configure Services Add services to the container.

			builder.Services.AddControllers();
            builder.Services.AddOpenApi();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(); 
            builder.Services.AddDbContext<StoreContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

			builder.Services.AddDbContext<AppIdentityDbcontext>( 
				options =>
			options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection")));


			builder.Services.AddSingleton<IConnectionMultiplexer>(
				Options =>
				{
					var Connection = builder.Configuration.GetConnectionString("RedisConnection");
					return ConnectionMultiplexer.Connect(Connection);
				}
				);


			builder.Services.AddApplicationServices();


			builder.Services.AddIdentityServices();

			builder.Services.AddCors(Options =>
			{
				Options.AddPolicy("MyPolicy", options =>
				{
					options.AllowAnyHeader();
					options.AllowAnyMethod();
					options.WithOrigins("http://localhost:4200");
					options.AllowCredentials();
				});
			});




			#endregion

			var app = builder.Build();


			#region Update-Database
			using var scope = app.Services.CreateScope();
			var services = scope.ServiceProvider;
            var LoggerFactory = services.GetRequiredService<ILoggerFactory>();
			try
            {
				
				var dbContext = services.GetRequiredService<StoreContext>();
				await dbContext.Database.MigrateAsync();

				var identityDbContext = services.GetRequiredService<AppIdentityDbcontext>();
				await identityDbContext.Database.MigrateAsync();


				#region Data Seeding
				await StoreContextSeed.SeedAsync(dbContext);

				var UserManager = services.GetRequiredService<UserManager<AppUser>>();
				await AppIdentityDbContextSeed.SeedUserAsync(UserManager);
				#endregion


			}
			catch (Exception ex)
			{
				var logger = LoggerFactory.CreateLogger<Program>();
				logger.LogError(ex, "An error occurred during migration");
			}

            #endregion



           
			#region Configure - Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
            {
				app.UseMiddleware<ExceptionMiddleware>();
				app.MapOpenApi();
                app.UseSwagger();
                app.UseSwaggerUI();
			}
			app.UseStaticFiles();

			app.UseStatusCodePagesWithReExecute("/errors/{0}");



			app.UseHttpsRedirection();

			app.UseCors("MyPolicy");

			app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers(); 
            #endregion


            app.Run();
        }
    }
}
