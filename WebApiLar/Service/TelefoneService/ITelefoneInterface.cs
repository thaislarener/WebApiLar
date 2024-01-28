using WebApiLar.Models;

namespace WebApiLar.Service.TelefoneService
{
    public interface ITelefoneInterface
    {
        Task<ServiceResponse<List<TelefoneModel>>> GetTelefones();
        Task<ServiceResponse<List<TelefoneModel>>> CreateTelefone(string cpf, TelefoneModel novoTelefone);
        Task<ServiceResponse<TelefoneModel>> GetTelefoneByCpf(string cpf);
        Task<ServiceResponse<List<TelefoneModel>>> UpdateTelefone(TelefoneModel editaTelefone);
        Task<ServiceResponse<List<TelefoneModel>>> DeleteTelefone(int id);
    }
}
