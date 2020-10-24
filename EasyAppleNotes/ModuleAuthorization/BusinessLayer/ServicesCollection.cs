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
            services.AddSingleton<IAuthorizationService, AuthorizationService>();
        }

        public static void UseAuthorizationMiddleware(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<AuthMiddleWare>();
        }
    }

    public class AuthMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly IAuthorizationService _authorizationService;

        public AuthMiddleWare(
            RequestDelegate next,
            IAuthorizationService authorizationService
        )
        {
            _next = next;
            _authorizationService = authorizationService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.Request.Headers.TryGetValue(HeaderNames.Authorization, out var authorizations);
            await _authorizationService.ProcessExtractingAccessTokenAsync(authorizations.FirstOrDefault());
            await _next(context);
            return;
        }
    }
}
