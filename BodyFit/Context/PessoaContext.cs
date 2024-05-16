using BodyFit.Entities;
using Microsoft.EntityFrameworkCore;

namespace BodyFit.Context
{
    public class PessoaContext : DbContext
    {
        public PessoaContext(DbContextOptions<PessoaContext> options) : base(options) 
            {

            }

        public DbSet<Pessoa> Pessoas { get; set; }
    }
}
