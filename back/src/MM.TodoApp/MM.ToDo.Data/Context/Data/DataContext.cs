using Microsoft.EntityFrameworkCore;
using MM.Todo.Domain.Entities;
using MM.ToDo.Data.Mappings;

namespace MM.ToDo.Data.Context.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Atividade> Atividades { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AtividadeMap());
        }

    }
}
