using System.ComponentModel.DataAnnotations;

namespace WebApiLar.Models
{
    public class PessoaModel
    {
        [Key]
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public bool Ativo { get; set; }
    }
}
