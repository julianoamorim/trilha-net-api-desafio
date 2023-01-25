using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Collections.Generic;
//Instalar pacote Newtonsoft.json p transformar o enum no JSON

namespace trilha_net_api_desafio.Models
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public EnumStatusTarefa Status{ get; set; }
        
    }
}