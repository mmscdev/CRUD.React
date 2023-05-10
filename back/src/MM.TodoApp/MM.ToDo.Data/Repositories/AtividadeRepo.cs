using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MM.Todo.Domain.Entities;
using MM.ToDo.Data.Context;
using MM.ToDo.Data.Context.Data;
using MM.ToDo.Domain.Interfaces.Repositories;
using MM.ToDoData.Repositories;

namespace MM.ToDo.Data.Repositories
{
    public class AtividadeRepo : GeralRepo, IAtividadeRepo
    {
        private readonly DataContext _context;
        public AtividadeRepo(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Atividade> ObterPorIdAsync(int id)
        {
            IQueryable<Atividade> query = _context.Atividades;

            query = query.AsNoTracking()
                         .OrderBy(ativ => ativ.Id)
                         .Where(a => a.Id == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Atividade> ObterPorTituloAsync(string titulo)
        {
            IQueryable<Atividade> query = _context.Atividades;

            query = query.AsNoTracking()
                         .OrderBy(ativ => ativ.Id);

            return await query.FirstOrDefaultAsync(a => a.Titulo == titulo);
        }

        public async Task<Atividade[]> ObterTodasAsync()
        {
            IQueryable<Atividade> query = _context.Atividades;

            query = query.AsNoTracking()
                         .OrderBy(ativ => ativ.Id);

            return await query.ToArrayAsync();
        }
    }
}