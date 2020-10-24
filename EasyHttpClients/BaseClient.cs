using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using EasyAppleNotes.ModuleAuthorization.BusinessLayer.EasyAppleServices;
using EasyHttpClients.Models;
using Microsoft.Net.Http.Headers;

namespace EasyHttpClients
{
    public abstract class BaseClient
    {
        protected string BaseUrl { get; set; }
        private readonly HttpClient _client;
        private readonly IAuthorizationService _authorizationService;

        protected BaseClient(IClientSetting clientSetting, IAuthorizationService authorizationService)
        {
            _client = new HttpClient();
            _authorizationService = authorizationService;
            BaseUrl = clientSetting.BaseUrl;
        }

        public async Task<T> GetAsync<T>(string path)
        {
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(BaseUrl + path),
                Method = HttpMethod.Post
            };
            ForceAddAuthorizationHeader(request.Headers);
            HttpResponseMessage response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<T>(responseBody,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                });
        }

        private void ForceAddAuthorizationHeader (HttpRequestHeaders headers)
        {
            headers.TryAddWithoutValidation(HeaderNames.Accept, "application/json");
            if (null != GetAccessToken())
            {
                headers.TryAddWithoutValidation(HeaderNames.Authorization, GetAccessToken());
            }
        }

        protected virtual string GetAccessToken()
        {
            return _authorizationService?.AccessToken;
        }
    }
}
