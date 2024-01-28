using WebApiLar.Models;

namespace WebApiLar.Service.PessoaService
{
    public interface IPessoaInterface
    {
        Task<ServiceResponse<List<PessoaModel>>> GetPessoas();
        Task<ServiceResponse<List<PessoaModel>>> CreatePessoa(PessoaModel novaPessoa);
        Task<ServiceResponse<PessoaModel>> GetPessoaByCpf(string cpf);
        Task<ServiceResponse<List<PessoaModel>>> UpdatePessoa(PessoaModel editaPessoa);
        Task<ServiceResponse<List<PessoaModel>>> DeletePessoa(string cpf);
        Task<ServiceResponse<List<PessoaModel>>> InativaPessoa(string cpf);
    }
}
