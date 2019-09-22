using Survey.Models;
using Survey.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Controllers
{
    public class TipoPerguntaController
    {
        public List<TipoPerguntaViewModel> Obter()
        {
            List<TipoPergunta> dados = new TipoPergunta().Obter();
            if (dados != null && dados.Count > 0)
                return (from tp in dados
                        select new TipoPerguntaViewModel()
                        {
                            Id = tp.Id,
                            Nome = tp.Nome,
                            Perguntas = null
                        }).ToList();
            else
                return null;
        }

        public TipoPerguntaViewModel Obter(int id)
        {
            TipoPergunta tp = new TipoPergunta().Obter(id);
            if (tp != null)
                return new TipoPerguntaViewModel()
                {
                    Id = tp.Id,
                    Nome = tp.Nome,
                    Perguntas = null
                };
            else
                return null;
        }

        public int Gravar(TipoPerguntaViewModel tp)
        {
            if (tp != null)
            {
                TipoPergunta tipoPergunta = new TipoPergunta()
                {
                    Id = tp.Id,
                    Nome = tp.Nome,
                    Perguntas = null
                };
                return tipoPergunta.Gravar();
            }
            else
                return -1;
        }

        public int Excluir(int id)
        {
            return new TipoPergunta().Excluir(id);
        }

    }
}
