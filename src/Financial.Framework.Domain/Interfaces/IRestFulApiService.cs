using Financial.Framework.Domain.Responses;
using System.Net.Http;
using System.Threading.Tasks;

namespace Financial.Framework.Domain.Interfaces
{
    public interface IRestFulApiService
    {
        Task<TResponse> ConsumeApiRestAsync<TResponse>(HttpMethod method, string url) where TResponse : ResponseBase, new();
    }
}
