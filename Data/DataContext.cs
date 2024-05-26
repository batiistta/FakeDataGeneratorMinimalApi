using FakeDataGeneratorMinimalApi.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FakeDataGeneratorMinimalApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<PessoaFisica> PessoaFisica => Set<PessoaFisica>();
        public DbSet<PessoaJuridica> PessoaJuridica => Set<PessoaJuridica>();

    }
}
