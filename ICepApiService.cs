using Refit;
using System.Threading.Tasks;

namespace GetCep
{
    interface ICepApiService
    {
        [Get("/ws/{cep}/json")]
        Task<CepResponse> GetAddressAsync(string cep);
    }
}
