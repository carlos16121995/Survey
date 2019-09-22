using Survey.Models;
using Survey.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Controllers
{
    public class PerguntaController
    {
        public PerguntaViewModel BuscarPergunta(string guid)
        {
            Pergunta p = new Pergunta().BuscarPergunta(guid);
            PerguntaViewModel pvw = new PerguntaViewModel()
            {
                Titulo = p.Titulo,
                Descricao = p.Descricao,
                Dica = p.Descricao,
            };

            return pvw;
        }
    }
}
