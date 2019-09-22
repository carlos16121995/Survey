using SurveyEF.Models;
using SurveyEF.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SurveyEF.Controllers
{
    public class PerguntaController
    {
        public int Gravar(PerguntaViewModel pergunta)
        {
            int retorno = 0;

            Pergunta p = new Pergunta()
            {
                Id = pergunta.Id,
                Titulo = pergunta.Titulo,
                Descricao = pergunta.Descricao,
                Dica = pergunta.Dica,
                Ordem = pergunta.Ordem,
                Obrigatoria = pergunta.Obrigatoria,
                TipoId = pergunta.TipoId,
                QuestionarioId = pergunta.QuestionarioId
            };

            List<PerguntaTag> tags = null;
            if (pergunta.Tags != null && pergunta.Tags.Count > 0)
            {
                tags = new List<PerguntaTag>();
                foreach(TagViewModel t in pergunta.Tags)
                {
                    PerguntaTag pt = new PerguntaTag();
                    pt.IdPerguntaNavigation = p;
                    pt.IdTagNavigation = new Tag() { Id = t.Id, Nome = t.Nome };

                    tags.Add(pt);
                }
            }

            p.PerguntaTag = tags;

            return p.Gravar();
        }
        public int Excluir(PerguntaViewModel p)
        {
            List<PerguntaTag> pt = new List<PerguntaTag>();
            foreach (PerguntaTagViewModel t in p.PerguntaTag)
            {
                PerguntaTag perguntaTag = new PerguntaTag()
                {
                    IdPergunta = t.IdPergunta,
                    IdTag = t.IdTag,
                };
                pt.Add(perguntaTag);
            }
            Pergunta per = new Pergunta()
            {
                Id= p.Id,
                Titulo = p.Titulo,
                Descricao = p.Descricao,
                Dica = p.Dica,
                Obrigatoria = p.Obrigatoria,
                Ordem = p.Ordem,
                TipoId = p.TipoId,
                QuestionarioId = p.QuestionarioId,
                PerguntaTag = pt,
            };
                       return per.Excluir();
        }

    }
}
