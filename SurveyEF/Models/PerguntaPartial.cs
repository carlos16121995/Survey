using SurveyEF.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyEF.Models
{
    internal partial class Pergunta
    {
        internal int Gravar()
        {
            //Validações...
            if (this.Id >= 0 && this.Titulo.Length >= 3)
                return new PerguntaDAO().Gravar(this);
            else
                return -10;
        }
        internal int Excluir()
        {
           
                return new PerguntaDAO().Excluir(this);
           
        }
    }
}
