using System;
using System.Collections.Generic;

namespace SurveyEF.Models
{
    internal partial class Resposta
    {
        public int Id { get; set; }
        public int PerguntaId { get; set; }
        public int? AlternativaId { get; set; }
        public string Texto { get; set; }
        public string TextoCurto { get; set; }
        public decimal? Numerica { get; set; }
        public DateTime Data { get; set; }
        public string Token { get; set; }

        public Alternativa Alternativa { get; set; }
        public Pergunta Pergunta { get; set; }
    }
}
