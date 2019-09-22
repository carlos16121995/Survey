using System;

namespace Survey.ViewModels
{
    public class RespostaViewModel
    {
        public int Id { get; set; }
        public int PerguntaId { get; set; }
        public int AlternativaId { get; set; }
        public string Texto { get; set; }
        public string TextoCurto { get; set; }
        public double Numerica { get; set; }
        public DateTime Data { get; set; }
        public string Token { get; set; }
        public AlternativaViewModel Alternativa { get; set; }
        public PerguntaViewModel Pergunta { get; set; }
    }
}
