using Microsoft.EntityFrameworkCore;
using WebApiLar.DataContext;
using WebApiLar.Models;

namespace WebApiLar.Service.PessoaService
{
    public class PessoaService : IPessoaInterface
    {
        private readonly ApplicationDbContext _context;
        public PessoaService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<PessoaModel>>> CreatePessoa(PessoaModel novaPessoa)
        {
            ServiceResponse<List<PessoaModel>> serviceResponse = new ServiceResponse<List<PessoaModel>>();

            try
            {
                if(novaPessoa == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informe os dados.";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }
                _context.Add(novaPessoa);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Pessoa.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<PessoaModel>>> DeletePessoa(string cpf)
        {
            ServiceResponse<List<PessoaModel>> serviceResponse = new ServiceResponse<List<PessoaModel>>();

            try
            {
                PessoaModel pessoa = _context.Pessoa.FirstOrDefault(x => x.Cpf == cpf);

                if (pessoa == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Pessoa não encontrada.";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }
                _context.Pessoa.Remove(pessoa);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Pessoa.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<PessoaModel>> GetPessoaByCpf(string cpf)
        {
            ServiceResponse<PessoaModel> serviceResponse = new ServiceResponse<PessoaModel>();

            try
            {
                PessoaModel pessoa = _context.Pessoa.FirstOrDefault(x => x.Cpf == cpf);

                if(pessoa == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Pessoa não encontrada.";
                    serviceResponse.Sucesso = false;
                }

                serviceResponse.Dados = pessoa;
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<PessoaModel>>> GetPessoas()
        {
            ServiceResponse<List<PessoaModel>> serviceResponse = new ServiceResponse<List<PessoaModel>>();

            try
            {
                serviceResponse.Dados = _context.Pessoa.ToList();

                if (serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Mensagem = "Nenhum dado encontrado.";
                }
            }
            catch(Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<PessoaModel>>> InativaPessoa(string cpf)
        {
            ServiceResponse<List<PessoaModel>> serviceResponse = new ServiceResponse<List<PessoaModel>>();

            try
            {
                PessoaModel pessoa = _context.Pessoa.FirstOrDefault(x => x.Cpf == cpf);

                if (pessoa == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Pessoa não encontrada.";
                    serviceResponse.Sucesso = false;
                }

                pessoa.Ativo = false;

                _context.Pessoa.Update(pessoa);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Pessoa.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<PessoaModel>>> UpdatePessoa(PessoaModel editaPessoa)
        {
            ServiceResponse<List<PessoaModel>> serviceResponse = new ServiceResponse<List<PessoaModel>>();

            try
            {
                PessoaModel pessoa = _context.Pessoa.AsNoTracking().FirstOrDefault(x => x.Cpf == editaPessoa.Cpf);

                if (pessoa == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Pessoa não encontrada.";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }
                _context.Pessoa.Update(editaPessoa);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Pessoa.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }
    }
}
