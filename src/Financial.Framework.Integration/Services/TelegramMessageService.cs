using Financial.Framework.Domain.Interfaces;
using Financial.Framework.Integration.AppModels;
using Financial.Framework.Integration.Entities;
using Financial.Framework.Integration.Interfaces;
using Financial.Framework.Integration.Responses;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Threading.Tasks;

namespace Financial.Framework.Integration.Services
{
    public class TelegramMessageService : IAppMessageService
    {
        private readonly IRestFulApiService _restFulApiService;
        private readonly string _url;

        public TelegramMessageService(IRestFulApiService restFulApiService, IOptions<AppMessageSettings> messageSettings)
        {
            _restFulApiService = restFulApiService;
            _url = messageSettings.Value.ApiUrl;
        }

        public async Task<AppMessageResponseBase<MessageContext>> GetUpdatesAsync()
        {
            return await _restFulApiService.ConsumeApiRestAsync<AppMessageResponseBase<MessageContext>>(HttpMethod.Get, $"{_url}/getUpdates");
        }

        public async Task<AppMessageResponseBase<Message>> SendMessageAsync(string chatId, string text)
        {
            return await _restFulApiService.ConsumeApiRestAsync<AppMessageResponseBase<Message>>(HttpMethod.Post, $"{_url}/sendMessage?chat_id={chatId}&text={text}");
        }
    }
}
