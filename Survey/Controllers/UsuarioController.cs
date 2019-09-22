using Survey.Models;
using Survey.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Controllers
{
    public class UsuarioController
    {
        public UsuarioViewModel Autenticar(string email, string senha)
        {
            Usuario u = new Usuario().Autenticar(email, senha);
            if (u != null)
                return new UsuarioViewModel()
                {
                    Id = u.Id,
                    Nome = u.Nome,
                    Email = u.Email,
                    DataCadastro = u.DataCadastro,
                    DataFim = u.DataFim,
                    Questionarios = null
                };
            else
                return null;
        }

        public UsuarioViewModel Obter(string email)
        {
            Usuario u = new Usuario().Obter(email);
            if (u != null)
                return new UsuarioViewModel()
                {
                    Id = u.Id,
                    Nome = u.Nome,
                    Email = u.Email,
                    DataCadastro = u.DataCadastro,
                    DataFim = u.DataFim,
                    Senha = u.Senha,
                    Questionarios = null
                };
            else
                return null;
        }

        public int Gravar(UsuarioViewModel u)
        {
            Usuario usuario = new Usuario();
            usuario.Id = u.Id;
            usuario.Nome = u.Nome;
            usuario.Email = u.Email;
            usuario.Senha = u.Senha;
            usuario.DataCadastro = u.DataCadastro;
            usuario.DataFim = u.DataFim;
            usuario.Questionarios = null;
            return usuario.Gravar();
        }
    }
}
