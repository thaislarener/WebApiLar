using Microsoft.EntityFrameworkCore;
using WebApiLar.Models;

namespace WebApiLar.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
           
        }

        public DbSet<PessoaModel> Pessoa { get; set; }
        public DbSet<TelefoneModel> Telefone { get; set; }
    }
}
