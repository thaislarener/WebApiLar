using Microsoft.EntityFrameworkCore;
using WebApiLar.DataContext;
using WebApiLar.Models;

namespace WebApiLar.Service.TelefoneService
{
    public class TelefoneService : ITelefoneInterface
    {
        private readonly ApplicationDbContext _context;
        public TelefoneService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<TelefoneModel>>> CreateTelefone(string cpf, TelefoneModel novoTelefone)
        {
            ServiceResponse<List<TelefoneModel>> serviceResponse = new ServiceResponse<List<TelefoneModel>>();

            try
            {
                if (cpf == null || novoTelefone == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informe os dados.";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                novoTelefone.CpfPessoa = cpf;
                _context.Add(novoTelefone);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Telefone.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<TelefoneModel>>> DeleteTelefone(int id)
        {
            ServiceResponse<List<TelefoneModel>> serviceResponse = new ServiceResponse<List<TelefoneModel>>();

            try
            {
                TelefoneModel telefone = _context.Telefone.FirstOrDefault(x => x.Id == id);

                if (telefone == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Telefone não encontrado.";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }
                _context.Telefone.Remove(telefone);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Telefone.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<TelefoneModel>>> GetTelefoneByCpf(string cpf)
        {
            ServiceResponse<List<TelefoneModel>> serviceResponse = new ServiceResponse<List<TelefoneModel>>();

            try
            {
                TelefoneModel telefone = _context.Telefone.FirstOrDefault(x => x.CpfPessoa == cpf);

                if (telefone == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Telefone não encontrado para este CPF.";
                    serviceResponse.Sucesso = false;
                }

                serviceResponse.Dados = telefone;
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<TelefoneModel>>> GetTelefones()
        {
            ServiceResponse<List<TelefoneModel>> serviceResponse = new ServiceResponse<List<TelefoneModel>>();

            try
            {
                serviceResponse.Dados = _context.Telefone.ToList();

                if(serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Mensagem = "Nenhum telefone registrado.";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<TelefoneModel>>> UpdateTelefone(TelefoneModel editaTelefone)
        {
            ServiceResponse<List<TelefoneModel>> serviceResponse = new ServiceResponse<List<TelefoneModel>>();

            try
            {
                TelefoneModel telefone = _context.Telefone.AsNoTracking().FirstOrDefault(x => x.Id == editaTelefone.Id);

                if (telefone == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Telefone não encontrado.";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }
                _context.Telefone.Update(editaTelefone);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Telefone.ToList();
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
