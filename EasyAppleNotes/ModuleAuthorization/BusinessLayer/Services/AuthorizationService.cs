using System;
using System.Threading.Tasks;
using EasyAppleNotes.ModuleAuthorization.BusinessLayer.EasyAppleServices;
using EasyAppleNotes.ModuleAuthorization.DataLayer.EasyAppleRepositories;

namespace EasyAppleNotes.ModuleAuthorization.BusinessLayer.Services
{
    public class AuthorizationService: IAuthorizationService
    {
        private readonly IAuthorizationRepository _auhtorization;

        public AuthorizationService(IAuthorizationRepository authorization)
        {
            _auhtorization = authorization;
        }

        public string UserPrincipal { get; private set; }

        public string AccessToken { get; private set; }

        public async Task ProcessExtractingAccessTokenAsync(string accessToken)
        {
            UserPrincipal = null;
            AccessToken = null;

            try
            {
                var principal = await _auhtorization.ProcessExtractingAccessTokenAsync(accessToken);

                UserPrincipal = principal;
                AccessToken = accessToken;
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
