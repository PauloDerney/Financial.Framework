using Financial.Framework.Integration.Entities;
using Financial.Framework.Integration.Responses;
using System.Threading.Tasks;

namespace Financial.Framework.Integration.Interfaces
{
    public interface IAppMessageService
    {
        Task<AppMessageResponseBase<MessageContext>> GetUpdatesAsync();

        Task<AppMessageResponseBase<Message>> SendMessageAsync(string chatId, string text);
    }
}
