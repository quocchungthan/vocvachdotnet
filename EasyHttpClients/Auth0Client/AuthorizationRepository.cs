using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyAppleNotes.ModuleAuthorization.DataLayer.EasyAppleRepositories;

namespace EasyHttpClients.Auth0Client
{
    public class AuthorizationRepository: BaseAuth0Client, IAuthorizationRepository
    {
        public AuthorizationRepository(): base()
        {
        }

        public Task<IEnumerable<string>> GetPermissionsAsync(string accessToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> ProcessExtractingAccessTokenAsync(string accessToken)
        {
            throw new NotImplementedException();
        }
    }
}
