using System.Collections.Generic;

namespace Survey.ViewModels
{
    public class TipoPerguntaViewModel
    {
        public short Id { get; set; }
        public string Nome { get; set; }
        public List<PerguntaViewModel> Perguntas { get; set; }
    }
}
