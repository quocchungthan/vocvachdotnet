using System;
using EasyAppleNotes.ModuleAuthorization.BusinessLayer.EasyAppleServices;
using EasyHttpClients.Models;

namespace EasyHttpClients.Auth0Client
{
    public abstract class BaseAuth0Client: BaseClient
    {
        public BaseAuth0Client(IAuth0ClientSetting setting, IAuthorizationService authorizationService):base(setting, authorizationService)
        {
        }
    }
}
