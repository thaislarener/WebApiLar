using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiLar.Models;
using WebApiLar.Service.PessoaService;
using WebApiLar.Service.TelefoneService;

namespace WebApiLar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelefoneController : ControllerBase
    {
        private readonly ITelefoneInterface _telefoneInterface;

        public TelefoneController(ITelefoneInterface telefoneInterface)
        {
            _telefoneInterface = telefoneInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<TelefoneModel>>>> GetTelefones()
        {
            return Ok(await _telefoneInterface.GetTelefones());
        }

        [HttpGet("{cpf}")]
        public async Task<ActionResult<ServiceResponse<List<TelefoneModel>>>> GetTelefoneByCpf(string cpf)
        {
            ServiceResponse<List<TelefoneModel>> serviceResponse = await _telefoneInterface.GetTelefoneByCpf(cpf);

            return Ok(serviceResponse);
        }

        [HttpPost("{cpf}")]
        public async Task<ActionResult<ServiceResponse<List<TelefoneModel>>>> CreateTelefone(string cpf, TelefoneModel novoTelefone)
        {
            return Ok(await _telefoneInterface.CreateTelefone(cpf, novoTelefone));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<TelefoneModel>>>> UpdateTelefone(TelefoneModel editaTelefone)
        {
            ServiceResponse<List<TelefoneModel>> serviceResponse = await _telefoneInterface.UpdateTelefone(editaTelefone);

            return Ok(serviceResponse);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<TelefoneModel>>>> DeleteTelefone(int id)
        {
            ServiceResponse<List<TelefoneModel>> serviceResponse = await _telefoneInterface.DeleteTelefone(id);

            return Ok(serviceResponse);
        }
    }
}
