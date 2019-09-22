using System;
using System.Collections.Generic;

namespace SurveyEF.Models
{
    internal partial class PerguntaTag
    {
        public int IdPergunta { get; set; }
        public int IdTag { get; set; }

        public Pergunta IdPerguntaNavigation { get; set; }
        public Tag IdTagNavigation { get; set; }
    }
}
