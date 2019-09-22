using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyEF.ViewModels
{
    public class TagViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<PerguntaViewModel> Perguntas { get; set; }
    }
}
