using SistemaAgendamento.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace SistemaAgendamento.Infrastructure
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbContext(DbContextOptions options) : base(options)
        {
        }

        public DbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=DbTarefas;Trusted_Connection=true");
        }

        public DbSet<AgendamentoModel> Agendamento { get; set; }
        public DbSet<Sala> Sala { get; set; }
    }
}
