using MM.Todo.Domain.Entities;

namespace MM.ToDo.Domain.Interfaces.Repositories
{
    public interface IAtividadeRepo : IGeralRepo
    {
        Task<Atividade[]> ObterTodasAsync();
        Task<Atividade> ObterPorIdAsync(int id);
        Task<Atividade> ObterPorTituloAsync(string titulo);
    }
}