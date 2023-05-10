using MM.Todo.Domain.Entities;
using MM.ToDo.Domain.Interfaces.Repositories;
using MM.ToDo.Domain.Interfaces.Services;

namespace MM.ToDo.Domain.Services
{
    public class AtividadeService : IAtividadeService
    {
        private readonly IAtividadeRepo _atividadeRepo;

        public AtividadeService(IAtividadeRepo atividadeRepo)
        {
            _atividadeRepo = atividadeRepo;
        }
        public async Task<Atividade> AdicionarAtividade(Atividade model)
        {
            if (await _atividadeRepo.ObterPorTituloAsync(model.Titulo) != null)
                throw new Exception("Já existe uma atividade com esse título");

            if (await _atividadeRepo.ObterPorIdAsync(model.Id) == null)
            {
                _atividadeRepo.Adicionar(model);
                if (await _atividadeRepo.SalvarMudancasAsync())
                    return model;
            }

            return null;
        }

        public async Task<Atividade> AtualizarAtividade(Atividade model)
        {
            if (model.DataConclusao != null)
                throw new Exception("Não se pode alterar atividade já concluída.");

            if (await _atividadeRepo.ObterPorIdAsync(model.Id) != null)
            {
                _atividadeRepo.Atualizar(model);
                if (await _atividadeRepo.SalvarMudancasAsync())
                    return model;
            }

            return null;
        }

        public async Task<bool> ConcluirAtividade(Atividade model)
        {
            if (model != null)
            {
                model.Concluir();
                _atividadeRepo.Atualizar<Atividade>(model);
                return await _atividadeRepo.SalvarMudancasAsync();
            }

            return false;
        }

        public async Task<bool> DeletarAtividade(int atividadeId)
        {
            var atividade = await _atividadeRepo.ObterPorIdAsync(atividadeId);
            if (atividade == null) throw new Exception("Atividade que tentou deletar não existe");

            _atividadeRepo.Deletar(atividade);
            return await _atividadeRepo.SalvarMudancasAsync();
        }

        public async Task<Atividade> ObterAtividadePorIdAsync(int atividadeId)
        {
            try
            {
                var atividade = await _atividadeRepo.ObterPorIdAsync(atividadeId);
                if (atividade == null) return null;

                return atividade;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Atividade[]> ObterTodasAtividadesAsync()
        {
            try
            {
                var atividades = await _atividadeRepo.ObterTodasAsync();
                if (atividades == null) return null;

                return atividades;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}