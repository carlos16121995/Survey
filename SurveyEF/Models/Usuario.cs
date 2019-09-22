using System;
using System.Collections.Generic;

namespace SurveyEF.Models
{
    internal partial class Usuario
    {
        public Usuario()
        {
            Questionario = new HashSet<Questionario>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataFim { get; set; }

        public ICollection<Questionario> Questionario { get; set; }
    }
}
