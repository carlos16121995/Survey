using System;
using System.Collections.Generic;

namespace SurveyEF.Models
{
    internal partial class Tag
    {
        public Tag()
        {
            PerguntaTag = new HashSet<PerguntaTag>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<PerguntaTag> PerguntaTag { get; set; }
    }
}
