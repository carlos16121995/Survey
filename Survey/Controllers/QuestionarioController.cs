using Survey.Models;
using Survey.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Controllers
{
    public class QuestionarioController
    {
        public List<QuestionarioViewModel> ObterPorUsuario(int id)
        {
            var dados = new Questionario().ObterPorUsuario(id);
            if (dados != null && dados.Count > 0)
                return (from d in dados
                        select new QuestionarioViewModel()
                        {
                            Id = d.Id,
                            Nome = d.Nome,
                            Inicio = d.Inicio,
                            Fim = d.Fim,
                            MsgFeedback = d.MsgFeedback,
                            Guid = d.Guid,
                            UsuarioId = d.UsuarioId,
                            Perguntas = null,
                            Usuario = null
                        }).ToList();
            else
                return null;
        }

        public QuestionarioViewModel BuscarQuestionario(string guid)
        {
            Questionario d = new Questionario().BuscarQuestionario(guid);
            QuestionarioViewModel q = new QuestionarioViewModel()
            {
                Id = d.Id,
                Nome = d.Nome,
                Inicio = d.Inicio,
                Fim = d.Fim,
                MsgFeedback = d.MsgFeedback,
                Guid = d.Guid,
                UsuarioId = d.UsuarioId,
                Perguntas = null,
                Usuario = null
            };

            return q;
        }
        public List<QuestionarioViewModel> ObterPorPalavraChave(string palavra, int idUsuario)
        {
            var dados = new Questionario().ObterPorPalavraChave(palavra, idUsuario);
            if (dados != null && dados.Count > 0)
                return (from d in dados
                        select new QuestionarioViewModel()
                        {
                            Id = d.Id,
                            Nome = d.Nome,
                            Inicio = d.Inicio,
                            Fim = d.Fim,
                            MsgFeedback = d.MsgFeedback,
                            Guid = d.Guid,
                            UsuarioId = d.UsuarioId,
                            Perguntas = null,
                            Usuario = null
                        }).ToList();
            else
                return null;
        }

        public QuestionarioViewModel Obter(int id, int idUsuario)
        {
            var dados = new Questionario().Obter(id, idUsuario);
            if (dados != null)
                return new QuestionarioViewModel()
                {
                    Id = dados.Id,
                    Nome = dados.Nome,
                    Inicio = dados.Inicio,
                    Fim = dados.Fim,
                    MsgFeedback = dados.MsgFeedback,
                    Guid = dados.Guid,
                    UsuarioId = dados.UsuarioId,
                    Perguntas = null,
                    Usuario = null
                };
            else
                return null;
        }

        public int Gravar(QuestionarioViewModel questionario)
        {
            Questionario q = new Questionario();
            q.Id = questionario.Id;
            q.Nome = questionario.Nome;
            q.Inicio = questionario.Inicio;
            q.Fim = questionario.Fim;
            q.MsgFeedback = questionario.MsgFeedback;
            q.Guid = questionario.Guid;
            q.UsuarioId = questionario.UsuarioId;

            return q.Gravar();
        }

        public int Excluir(int id)
        {
            Questionario q = new Questionario();
            return q.Excluir(id);
        }

    }
}
