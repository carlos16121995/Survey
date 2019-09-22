using System.Collections.Generic;

namespace Survey.ViewModels
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
        public List<RespostaViewModel> Respostas { get; set; }
    }
}
