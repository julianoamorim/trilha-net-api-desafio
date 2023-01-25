using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using trilha_net_api_desafio.Models;

namespace trilha_net_api_desafio.Context
{
    public class TarefaContext : DbContext
    {
        public TarefaContext(DbContextOptions<TarefaContext> options) : base(options){}
        	public DbSet<Tarefa> Tarefas {get; set;}   
    }
}