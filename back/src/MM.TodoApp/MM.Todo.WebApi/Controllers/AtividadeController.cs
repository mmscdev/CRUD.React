using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using MM.Todo.WebApi.Data;
using MM.Todo.WebApi.Models;
using System.Collections;

namespace MM.Todo.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AtividadeController : ControllerBase
    {
        private readonly DataContext _context;

        public AtividadeController(DataContext context)
        {
            _context = context;
        }
        //private readonly IAtividadeService _atividadeService;
        //public AtividadeController(IAtividadeService atividadeService)
        //{
        //    _atividadeService = atividadeService;
        //}

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var atividades = _context.Atividades.ToList();
                    //await _atividadeService.PegarTodasAtividadesAsync();
                //if (atividades == null)
               // return NoContent();

               return Ok(atividades);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar Atividades. Erro: {ex.Message}");
            }
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(int id)
        //{
        //    try
        //    {
        //        var atividade = await _atividadeService.PegarAtividadePorIdAsync(id);
        //        if (atividade == null) return NoContent();

        //        return Ok(atividade);
        //    }
        //    catch (System.Exception ex)
        //    {
        //        return this.StatusCode(StatusCodes.Status500InternalServerError,
        //            $"Erro ao tentar recuperar Atividade com id: ${id}. Erro: {ex.Message}");
        //    }
        //}

        [HttpPost]
        public  IEnumerable<Atividade> Post(Atividade model)
        {
                _context.Atividades.Add(model);
                if(_context.SaveChanges() > 0)
                {
                    return _context.Atividades;

                }
                else
                {
                    throw new Exception("Você não conseguiu adicionar uma atvidade");
                }
                //var atividade = 
                    //await _atividadeService.AdicionarAtividade(model);
                //if (atividade == null) return NoContent();

        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> Put(int id, Atividade model)
        //{
        //    try
        //    {
        //        if (model.Id != id)
        //            this.StatusCode(StatusCodes.Status409Conflict,
        //                "Você está tentando atualizar a atividade errada");

        //        var atividade = await _atividadeService.AtualizarAtividade(model);
        //        if (atividade == null) return NoContent();

        //        return Ok(atividade);
        //    }
        //    catch (System.Exception ex)
        //    {
        //        return this.StatusCode(StatusCodes.Status500InternalServerError,
        //            $"Erro ao tentar Atualizar Atividade com id: ${id}. Erro: {ex.Message}");
        //    }
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    try
        //    {
        //        var atividade = await _atividadeService.PegarAtividadePorIdAsync(id);
        //        if (atividade == null)
        //            this.StatusCode(StatusCodes.Status409Conflict,
        //                "Você está tentando deletar a atividade que não existe");

        //        if (await _atividadeService.DeletarAtividade(id))
        //        {
        //            return Ok(new { message = "Deletado" });
        //        }
        //        else
        //        {
        //            return BadRequest("Ocorreu um problema não específico ao tentar deletar a atividade.");
        //        }
        //    }
        //    catch (System.Exception ex)
        //    {
        //        return this.StatusCode(StatusCodes.Status500InternalServerError,
        //            $"Erro ao tentar deletar Atividade com id: ${id}. Erro: {ex.Message}");
        //    }
        //}
    }
}