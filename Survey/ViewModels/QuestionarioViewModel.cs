using System;
using System.Collections.Generic;

namespace Survey.ViewModels
{
    public class QuestionarioViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public string MsgFeedback { get; set; }
        public string Guid { get; set; }
        public int UsuarioId { get; set; }
        public UsuarioViewModel Usuario { get; set; }
        public List<PerguntaViewModel> Perguntas { get; set; }
    }
}
