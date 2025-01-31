﻿using Infrastructure.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Identity;

internal static class Startup
{
	internal static IServiceCollection AddDbIdentity(this IServiceCollection services) =>
		services
			.AddIdentity<AppUser, IdentityRole>(options =>
			{
				options.Password.RequiredLength = 6;
				options.Password.RequireDigit = false;
				options.Password.RequireLowercase = false;
				options.Password.RequireNonAlphanumeric = false;
				options.Password.RequireUppercase = false;
				options.User.RequireUniqueEmail = true;
			})
			.AddEntityFrameworkStores<ApplicationDbContext>()
			.AddDefaultTokenProviders()
			.Services;
}
