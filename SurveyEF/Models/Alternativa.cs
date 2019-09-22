using System;
using System.Collections.Generic;

namespace SurveyEF.Models
{
    internal partial class Alternativa
    {
        public Alternativa()
        {
            Resposta = new HashSet<Resposta>();
        }

        public int Id { get; set; }
        public string Opcao { get; set; }
        public short Ordem { get; set; }
        public int PerguntaId { get; set; }

        public Pergunta Pergunta { get; set; }
        public ICollection<Resposta> Resposta { get; set; }
    }
}
