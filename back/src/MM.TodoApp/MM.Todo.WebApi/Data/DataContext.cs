using Microsoft.EntityFrameworkCore;
using MM.Todo.WebApi.Models;

namespace MM.Todo.WebApi.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Atividade> Atividades { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}
