using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApiLar.Enums;

namespace WebApiLar.Models
{
    public class TelefoneModel
    {
        [Key]
        public int Id { get; set; }
        public TipoEnum Tipo { get; set; }
        public string Numero { get; set; }
        public string CpfPessoa { get; set; }
        
    }
}
