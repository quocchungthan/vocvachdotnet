using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyAppleNotes.ModuleAuthorization.DataLayer.EasyAppleRepositories;
using EasyAppleNotes.ModuleNotes.DataLayer;
using EasyHttpClients.Models;

namespace EasyHttpClients.Auth0Client
{
    public class AuthorizationRepository: BaseAuth0Client, IAuthorizationRepository
    {
        public AuthorizationRepository(IAuth0ClientSetting setting): base(setting, null)
        {
        }

        public string _accessToken { get; private set; }

        public Task<IEnumerable<string>> GetPermissionsAsync(string accessToken)
        {
            throw new NotImplementedException();
        }

        public async Task<string> ProcessExtractingAccessTokenAsync(string accessToken)
        {
            _accessToken = accessToken;
            var ui = await GetAsync<UserInfo>(path: "/userInfo");

            return ui.Sub;
        }

        protected override string GetAccessToken()
        {
            return _accessToken;
        }
    }
}
