using System;
using System.Collections.Generic;

namespace SurveyEF.Models
{
    internal partial class TipoPergunta
    {
        public TipoPergunta()
        {
            Pergunta = new HashSet<Pergunta>();
        }

        public short Id { get; set; }
        public string Nome { get; set; }

        public ICollection<Pergunta> Pergunta { get; set; }
    }
}
