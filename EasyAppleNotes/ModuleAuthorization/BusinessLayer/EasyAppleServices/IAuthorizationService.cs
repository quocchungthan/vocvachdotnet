using System;
using System.Threading.Tasks;

namespace EasyAppleNotes.ModuleAuthorization.BusinessLayer.EasyAppleServices
{
    public interface IAuthorizationService
    {
        string UserPrincipal { get; }
        string AccessToken { get; }

        Task ProcessExtractingAccessTokenAsync(string accessToken);
    }
}
