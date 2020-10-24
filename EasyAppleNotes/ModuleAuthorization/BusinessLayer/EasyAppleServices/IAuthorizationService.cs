using System;
using System.Threading.Tasks;

namespace EasyAppleNotes.ModuleAuthorization.BusinessLayer.EasyAppleServices
{
    public interface IAuthorizationService
    {
        string UserPrincipal { get; }

        Task ProcessExtractingAccessTokenAsync(string accessToken);
    }
}
