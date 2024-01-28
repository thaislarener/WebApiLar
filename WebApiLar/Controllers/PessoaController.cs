using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiLar.Models;
using WebApiLar.Service.PessoaService;

namespace WebApiLar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaInterface _pessoaInterface;
        public PessoaController(IPessoaInterface pessoaInterface)
        {
            _pessoaInterface = pessoaInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<PessoaModel>>>> GetPessoas()
        {
            return Ok(await _pessoaInterface.GetPessoas());
        }

        [HttpGet("{cpf}")]
        public async Task<ActionResult<ServiceResponse<PessoaModel>>> GetPessoaByCpf(string cpf)
        {
            ServiceResponse<PessoaModel> serviceResponse = await _pessoaInterface.GetPessoaByCpf(cpf);

            return Ok(serviceResponse);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<PessoaModel>>>> CreatePessoa(PessoaModel novaPessoa)
        {
            return Ok(await _pessoaInterface.CreatePessoa(novaPessoa));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<PessoaModel>>>> UpdatePessoa(PessoaModel editaPessoa)
        {
            ServiceResponse<List<PessoaModel>> serviceResponse = await _pessoaInterface.UpdatePessoa(editaPessoa);

            return Ok(serviceResponse);
        }

        [HttpPut("inativaPessoa")]
        public async Task<ActionResult<ServiceResponse<List<PessoaModel>>>> InativaPessoa(string cpf)
        {
            ServiceResponse<List<PessoaModel>> serviceResponse = await _pessoaInterface.InativaPessoa(cpf);
            
            return Ok(serviceResponse);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<PessoaModel>>>> DeletePessoa(string cpf)
        {
            ServiceResponse<List<PessoaModel>> serviceResponse = await _pessoaInterface.DeletePessoa(cpf);

            return Ok(serviceResponse);
        }
    }
}
