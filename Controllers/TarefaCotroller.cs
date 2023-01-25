using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using trilha_net_api_desafio.Context;
using trilha_net_api_desafio.Models;

namespace trilha_net_api_desafio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly TarefaContext _context;

        public TarefaController(TarefaContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var tarefa = _context.Tarefas.Find(id);
            if(tarefa == null)
                return NotFound();
            return Ok(tarefa);
        }

        [HttpGet("ObterTodos")]
        public IActionResult ObterTodos()
        {
            var tarefas = _context.Tarefas.ToList();
            return Ok(tarefas);
        }

        [HttpGet("ObterPorTitulo")]
        public IActionResult ObterPorTitulo(string titulo)
        {
            var tarefa = _context.Tarefas.Where(x => x.Titulo.Contains(titulo));
            if(tarefa == null)
                return NotFound();
            return Ok(tarefa);
        }

        [HttpGet("ObterPorData")]
        public IActionResult ObterPorData(DateTime data)
        {
            var tarefa = _context.Tarefas.Where(x => x.Data.Date == data.Date);
            return Ok(tarefa);
        }

        [HttpGet("ObterPorStatus")]
        public IActionResult ObterPorStatus(EnumStatusTarefa status)
        {
            var tarefa = _context.Tarefas.Where(x => x.Status == status);
            return Ok(tarefa);
        }

        [HttpPost("Criar")]
        public IActionResult Criar(Tarefa tarefa)
        {
            if (tarefa.Data == DateTime.MinValue){
                return BadRequest(new { Erro = "A data da tarefa não pode ser vazia" });
            }
            _context.Tarefas.Add(tarefa);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ObterPorId), new { id = tarefa.Id }, tarefa);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Tarefa novaTarefa)
        {
            var tarefaBanco = _context.Tarefas.Find(id);

            if (tarefaBanco == null)
                return NotFound();

            if (novaTarefa.Data == DateTime.MinValue)
                return BadRequest(new { Erro = "A data da tarefa não pode ser vazia" });

            tarefaBanco.Titulo = novaTarefa.Titulo;
            tarefaBanco.Descricao = novaTarefa.Descricao;
            tarefaBanco.Status = novaTarefa.Status;
            tarefaBanco.Data = tarefaBanco.Data;
            _context.SaveChanges();
            return Ok(tarefaBanco);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var tarefaBanco = _context.Tarefas.Find(id);

            if (tarefaBanco == null)
                return NotFound();
            _context.Remove(tarefaBanco);
            _context.SaveChanges();
            return NoContent();
        }
    }
}