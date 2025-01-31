﻿using Infrastructure.Caching;
using Infrastructure.Common;
using Infrastructure.Context;
using Infrastructure.Identity;
using Infrastructure.Localization;
using Infrastructure.Middleware;
using Infrastructure.Security;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class Startup
{
	public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
	{
		return services
			.AddPersistance(config)
			.AddCaching(config)
			.AddAuth(config)
			.AddDbIdentity()
			.AddRequestLogging(config)
			.AddExceptionMiddleware()
			.AddLocalization(config)
			.AddServices()
			.AddCors(opt => opt.AddPolicy("CorsPolicy", policy => policy.AllowAnyHeader()
																.AllowAnyMethod()
																.AllowCredentials()));
	}

	public static async Task UseInfrastructure(this IApplicationBuilder app, IConfiguration config)
	{
		await app.InitDatabaseAsync<ApplicationDbContext>();
		app.UseLocalization(config);
		app.UseExceptionMiddleware();
		app.UseRouting();
		app.UseCors("CorsPolicy");
		app.UseAuthentication();
		app.UseCurrentUser();
		app.UseAuthorization();
		app.UseRequestLogging(config);
	}
}
