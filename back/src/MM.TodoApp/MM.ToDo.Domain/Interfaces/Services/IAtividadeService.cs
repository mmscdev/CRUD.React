using MM.Todo.Domain.Entities;

namespace MM.ToDo.Domain.Interfaces.Services
{
    public interface IAtividadeService
    {
        Task<Atividade> AdicionarAtividade(Atividade model);
        Task<Atividade> AtualizarAtividade(Atividade model);

        Task<bool> DeletarAtividade(int atividadeId);
        Task<bool> ConcluirAtividade(Atividade model);

        Task<Atividade[]> ObterTodasAtividadesAsync();
        Task<Atividade> ObterAtividadePorIdAsync(int atividadeId);
    }
}