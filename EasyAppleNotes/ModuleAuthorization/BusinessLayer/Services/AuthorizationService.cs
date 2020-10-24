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

        public async Task ProcessExtractingAccessTokenAsync(string accessToken)
        {
            if (string.IsNullOrEmpty(accessToken))
            {
                UserPrincipal = null;
                return;
            }

            try
            {
                var principal = await _auhtorization.ProcessExtractingAccessTokenAsync(accessToken);

                UserPrincipal = principal;
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                UserPrincipal = null;
            }
        }
    }
}
