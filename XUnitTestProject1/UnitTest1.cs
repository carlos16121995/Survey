using System;
using System.Collections.Generic;
using Xunit;
using SurveyEF.Controllers;
using SurveyEF.ViewModels;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

            List<PerguntaTagViewModel> t = new List<PerguntaTagViewModel>();
            t.Add(new PerguntaTagViewModel()
            {
                IdTag = 44,
                IdPergunta = 42,
            });
            t.Add(new PerguntaTagViewModel()
            {
                IdTag = 45,
                IdPergunta = 42,
            });
            t.Add(new PerguntaTagViewModel()
            {
                IdTag = 46,
                IdPergunta = 42,
            });
            t.Add(new PerguntaTagViewModel()
            {
                IdTag = 47,
                IdPergunta = 42,
            });
            PerguntaViewModel p = new PerguntaViewModel()
            {
                Id = 42,
                Titulo = "asdf",
                Descricao = "qualuqer merda",
                Dica = "acerta ai",
                Obrigatoria = "s",
                Ordem = 1,
                TipoId = 1,
                QuestionarioId = 1,
                PerguntaTag = t,
            };
            Assert.InRange(new PerguntaController().Excluir(p), 1, 1000);

        }
        [Fact]
        public void Test2()
        {
            List<TagViewModel> t = new List<TagViewModel>();
            t.Add(new TagViewModel()
            {
                Nome = "1",
            });
            t.Add(new TagViewModel()
            {
                Nome = "2",
            });
            t.Add(new TagViewModel()
            {
                Nome = "3",
            });
            t.Add(new TagViewModel()
            {
                Nome = "4",
            });
            PerguntaViewModel p = new PerguntaViewModel()
            {
                Titulo = "asdf",
                Descricao = "qualuqer merda",
                Dica = "acerta ai",
                Obrigatoria = "s",
                Ordem = 1,
                TipoId = 1,
                QuestionarioId = 1,
                Tags = t,
            };
 
            Assert.InRange(new PerguntaController().Gravar(p), 1, 1000);
        }
    }
}
