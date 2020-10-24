using System;
using System.Linq;
using System.Threading.Tasks;
using EasyAppleNotes.ModuleAuthorization.BusinessLayer.EasyAppleServices;
using EasyAppleNotes.ModuleAuthorization.BusinessLayer.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;

namespace EasyAppleNotes.ModuleAuthorization.BusinessLayer
{
    public static class ServicesCollection
    {
        // extension method for IServiceCollection objects
        public static void AddAuthServiceDependency(this IServiceCollection services)
        {
            // authorization service cannot be singleton, cause it's requiring one instance of Authorization per user request.
            services.AddScoped<IAuthorizationService, AuthorizationService>();
        }

        public static void UseAuthorizationMiddleware(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<AuthMiddleWare>();
        }
    }

    public class AuthMiddleWare
    {
        private readonly RequestDelegate _next;

        public AuthMiddleWare(
            RequestDelegate next
        )
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IAuthorizationService authorizationService)
        {
            context.Request.Headers.TryGetValue(HeaderNames.Authorization, out var authorizations);
            await authorizationService.ProcessExtractingAccessTokenAsync(authorizations.FirstOrDefault());
            await _next(context);
            return;
        }
    }
}
