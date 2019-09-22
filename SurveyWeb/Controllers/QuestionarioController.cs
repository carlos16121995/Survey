using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Survey.ViewModels;
using SurveyWeb.Filters;
using cl = Survey.Controllers;
using iTextSharp.text;
using iTextSharp.text.pdf;
using ExemploPDF.PdfUtils;
using System.IO;
using CL = Survey.Controllers;

namespace SurveyWeb.Controllers
{
    [ValidarUsuario]
    public class QuestionarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult ObterPorUsuario()
        {
            int idUsuario = int.Parse(Request.Cookies["idUsuario"].ToString());
            var dados = new cl.QuestionarioController().ObterPorUsuario(idUsuario);
            return Json(dados);
        }
        [Route("Responder/{guid}")]
        public IActionResult Questionario(string guid)
        { 
            var Questionario = new CL.QuestionarioController().BuscarQuestionario(guid);

            ViewData["Nome"] = Questionario.Nome;
            ViewData["DataInicio"] = Questionario.Inicio;
            ViewData["msg"] = Questionario.MsgFeedback;
            return View();
        }
       


        [HttpPost]
        public JsonResult Obter(int id)
        {
            int idUsuario = int.Parse(Request.Cookies["idUsuario"].ToString());
            var dados = new cl.QuestionarioController().Obter(id, idUsuario);
            return dados == null ? Json("") : Json(dados);
        }

        [HttpPost]
        public JsonResult ObterPorPalavraChave(string palavra)
        {
            int idUsuario = int.Parse(Request.Cookies["idUsuario"].ToString());
            var dados = new cl.QuestionarioController().ObterPorPalavraChave(palavra, idUsuario);
            return dados == null ? Json("") : Json(dados);
        }

        [HttpPost]
        public JsonResult Gravar(IFormCollection form)
        {
            if (form.Keys.Count > 0)
            {
                int id = 0;
                int.TryParse(form["Id"], out id);
                string nome = form["Nome"].ToString().Trim();
                DateTime inicio = DateTime.MinValue;
                DateTime.TryParse(form["Inicio"], out inicio);
                DateTime fim = DateTime.MinValue;
                DateTime.TryParse(form["Fim"], out fim);
                string msgFeedback = form["MsgFeedBack"].ToString().Trim();
                string guid = form["Guid"].ToString().Trim();
                int idUsuario = int.Parse(Request.Cookies["idUsuario"].ToString());

                QuestionarioViewModel q = new QuestionarioViewModel();
                q.Id = id;
                q.Nome = nome;
                q.Inicio = inicio;
                q.Fim = fim;
                q.MsgFeedback = msgFeedback;
                q.Guid = guid;
                q.UsuarioId = idUsuario;

                cl.QuestionarioController ctlQuestionario = new cl.QuestionarioController();
                if (ctlQuestionario.Gravar(q) > 0)
                    return Json("");
                else
                    return Json("Erro ao gravar o questionário: " + q.Nome.ToUpper());
            }
            else
            {
                return Json("O formulário submetido não contem valores válidos.");
            }
        }

        [HttpPost]
        public JsonResult Excluir(int id)
        {
            cl.QuestionarioController ctlQuestionario = new cl.QuestionarioController();
            if (ctlQuestionario.Excluir(id) > 0)
                return Json("");
            else
                return Json("Não foi possível excluir o registro selecionado.");
        }

        public IActionResult ExportarPDF()
        {
            Document doc = new Document(PageSize.A4, 50, 50, 100, 70);
            MemoryStream stream = new MemoryStream();
            PdfWriter pdf = PdfWriter.GetInstance(doc, stream);
            pdf.CloseStream = false;

            TwoColumnHeaderFooter headerFooter = new TwoColumnHeaderFooter();
            pdf.PageEvent = headerFooter;
            headerFooter.Title = "SURVEY.NET";
            headerFooter.HeaderLeft = "Questionários";
            headerFooter.HeaderRight = Request.Cookies["nomeUsuario"].ToString();
            headerFooter.HeaderFont = FontFactory.GetFont(BaseFont.HELVETICA_BOLD, 14, BaseColor.Blue);

            doc.Open();


            var dados = new cl.QuestionarioController().ObterPorUsuario(int.Parse(Request.Cookies["idUsuario"].ToString()));
            if (dados != null && dados.Count > 0)
            {
                PdfPTable tabela = new PdfPTable(5);
                tabela.WidthPercentage = 100;

                PdfPCell cel = new PdfPCell(new Phrase("Questionários Cadastrados"));
                cel.Colspan = 5;
                cel.BackgroundColor = new BaseColor(System.Drawing.Color.Cornsilk);
                cel.MinimumHeight = 30;
                cel.HorizontalAlignment = 1; //0->Esquerda, 1->Centro, 2->Direita

                tabela.AddCell(cel);

                tabela.AddCell("ID");
                tabela.AddCell("TÍTULO");
                tabela.AddCell("INÍCIO");
                tabela.AddCell("FIM");
                tabela.AddCell("GUID");

                foreach(var q in dados)
                {
                    tabela.AddCell(q.Id.ToString());
                    tabela.AddCell(q.Nome);
                    tabela.AddCell(q.Inicio.ToShortDateString());
                    tabela.AddCell(q.Fim.ToShortDateString());
                    tabela.AddCell(q.Guid);
                }

                doc.Add(tabela);
            }
            else
            {
                Paragraph p = new Paragraph("Não há questionários a serem exportados.");
                doc.Add(p);
            }
            doc.Close();
            stream.Flush();
            stream.Position = 0;

            return File(stream, "application/pdf", "Relatorio.pdf");
        }
    }
}