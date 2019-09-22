using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyEF.ViewModels
{
    public class PerguntaViewModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Dica { get; set; }
        public string Obrigatoria { get; set; }
        public decimal Ordem { get; set; }
        public short TipoId { get; set; }
        public int QuestionarioId { get; set; }

        public ICollection<TagViewModel> Tags { get; set; }
        public ICollection<PerguntaTagViewModel> PerguntaTag { get; set; }
    }
}
