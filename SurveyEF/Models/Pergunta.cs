using System;
using System.Collections.Generic;

namespace SurveyEF.Models
{
    internal partial class Pergunta
    {
        public Pergunta()
        {
            Alternativa = new HashSet<Alternativa>();
            PerguntaTag = new HashSet<PerguntaTag>();
            Resposta = new HashSet<Resposta>();
        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Dica { get; set; }
        public string Obrigatoria { get; set; }
        public decimal Ordem { get; set; }
        public short TipoId { get; set; }
        public int QuestionarioId { get; set; }

        public Questionario Questionario { get; set; }
        public TipoPergunta Tipo { get; set; }
        public ICollection<Alternativa> Alternativa { get; set; }
        public ICollection<PerguntaTag> PerguntaTag { get; set; }
        public ICollection<Resposta> Resposta { get; set; }
    }
}
