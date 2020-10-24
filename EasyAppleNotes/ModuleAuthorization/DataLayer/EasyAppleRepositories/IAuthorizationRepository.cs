using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyAppleNotes.ModuleAuthorization.DataLayer.EasyAppleRepositories
{
    public interface IAuthorizationRepository
    {
        Task<string> ProcessExtractingAccessTokenAsync(string accessToken);
        Task<IEnumerable<string>> GetPermissionsAsync(string accessToken);
    }
}
