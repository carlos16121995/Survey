using System;
using System.Collections.Generic;

namespace SurveyEF.Models
{
    internal partial class Questionario
    {
        public Questionario()
        {
            Pergunta = new HashSet<Pergunta>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime? Fim { get; set; }
        public string MsgFeedback { get; set; }
        public string Guid { get; set; }
        public string Imagem { get; set; }
        public int UsuarioId { get; set; }
        public string Imagem64 { get; set; }

        public Usuario Usuario { get; set; }
        public ICollection<Pergunta> Pergunta { get; set; }
    }
}
