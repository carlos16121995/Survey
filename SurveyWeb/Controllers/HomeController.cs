using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Survey.ViewModels;
using SurveyWeb.Filters;
using cl = Survey.Controllers;

namespace SurveyWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private string EnviarEmail(string emailFrom, string nomeFrom, List<string> emailPara, string assunto, string texto)
        {
            //Gerando o objeto da mensagem
            MailMessage msg = new MailMessage();
            //Remetente
            msg.From = new MailAddress(emailFrom, nomeFrom);
            //Destinatários
            foreach (string email in emailPara)
                msg.To.Add(email);
            //Assunto
            msg.Subject = assunto;
            //Texto a ser enviado
            msg.Body = texto;
            msg.IsBodyHtml = true;

            //Gerando o objeto para envio da mensagem (Exemplo pelo Gmail)
            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = true;
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new NetworkCredential(emailFrom, "SuaSenhaAqui");
            try
            {
                client.Send(msg);
                return "OK";
            }
            catch (Exception ex)
            {
                return "Falha: " + ex.Message;
            }
            finally
            {
                msg.Dispose();
            }
        }

        [HttpPost]
        public IActionResult Validar(string Email, string Senha)
        {
            if (Email != "" && Senha != "")
            {
                cl.UsuarioController ctlUsuario = new cl.UsuarioController();
                var usuario = ctlUsuario.Autenticar(Email, Senha);
                if (usuario != null)
                {
                    //CookieOptions ck = new CookieOptions();
                    //ck.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Append("idUsuario", usuario.Id.ToString());
                    if (usuario.Nome.Length > 15)
                        usuario.Nome = usuario.Nome.Substring(0, 15);
                    Response.Cookies.Append("nomeUsuario", usuario.Nome);
                    Response.Cookies.Append("emailUsuario", usuario.Email);

                    return Json("");
                }
                else
                {
                    return Json("O usuário e/ou a senha informados não conferem.");
                }
            }
            else
            {
                return Json("Por favor, informe um usuário e uma senha para acesso.");
            }
        }

        [HttpPost]
        public IActionResult Gravar(string Email, string Nome, string Senha, int Id = 0, bool Excluir = false)
        {
            if (Email != "" && Nome.Length > 2 && Senha.Length > 0)
            {
                cl.UsuarioController ctlUsuario = new cl.UsuarioController();
                UsuarioViewModel usuario = new UsuarioViewModel()
                {
                    Id = Id,
                    Nome = Nome,
                    Senha = Senha,
                    Email = Email,
                    DataCadastro = DateTime.Now,
                    DataFim = null
                };
                if (Excluir)
                    usuario.DataFim = DateTime.Now;

                if (ctlUsuario.Gravar(usuario) > 0)
                    return Json("");
                else
                    return Json("Erro ao gravar o novo usuário.");
            }
            else
            {
                return Json("Por favor, informe todos os dados para criar um novo usuário.");
            }
        }

        public IActionResult Logout()
        {
            Response.Cookies.Delete("idUsuario");
            Response.Cookies.Delete("nomeUsuario");
            Response.Cookies.Delete("emailUsuario");

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public JsonResult RecuperarSenha(string Email)
        {
            UsuarioViewModel u = new cl.UsuarioController().Obter(Email);
            if (u != null)
            {
                string msg = string.Format(@"Olá <b>{0}</b>, confira abaixo seu usuário e senha para acesso.<br /><br />
                        <b>Usuário:</b> {1}<br /><b>Senha:</b> {2}<br/><br/>
                        Atenciosamente,<br/>Administração Survey.Net", u.Nome, u.Email, u.Senha);
                string sucesso = EnviarEmail("email@gmail.com", "Nome do remetente", new List<string>() { u.Email }, "SURVEY.NET - Recuperação de Senha de Acesso", msg);
                if (sucesso == "OK")
                    return Json("");
                else
                    return Json(sucesso);
            }
            else
            {
                return Json("O e-mail informado não foi encontrado.");
            }
        }

        [ValidarUsuario]
        public JsonResult ObterUsuario()
        {
            return Json(new cl.UsuarioController().Obter(Request.Cookies["emailUsuario"].ToString()));
        }

        [ValidarUsuario]
        public IActionResult AlterarUsuario()
        {
            return View();
        }

    }
}