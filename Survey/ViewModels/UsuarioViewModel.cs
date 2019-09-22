using System;
using System.Collections.Generic;

namespace Survey.ViewModels
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataFim { get; set; }
        public List<QuestionarioViewModel> Questionarios { get; set; }
    }
}
