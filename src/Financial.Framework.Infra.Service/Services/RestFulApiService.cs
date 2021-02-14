using Financial.Framework.Domain.Interfaces;
using Financial.Framework.Domain.Responses;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Financial.Framework.Infra.Service.Services
{
    public class RestFulApiService : IRestFulApiService
    {
        [Obsolete("Method depreciated, in next version deleted")]
        public async Task<TResponse> ConsumeApiRestAsync<TResponse>(HttpMethod method, string url) where TResponse : ResponseBase, new()
        {
            try
            {
                var request = new HttpRequestMessage(method, url);

                using var client = new HttpClient { Timeout = TimeSpan.FromSeconds(5) };
                using var response = await client.SendAsync(request, HttpCompletionOption.ResponseContentRead);
                
                return response.IsSuccessStatusCode
                    ? await JsonSerializer.DeserializeAsync<TResponse>(await response.Content.ReadAsStreamAsync())
                    : new TResponse { Success = false, Message = response.ReasonPhrase };
            }
            catch (Exception ex)
            {
                return new TResponse { Success = false, Message = ex.Message };
            }
        }
    }
}