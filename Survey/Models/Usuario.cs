using Survey.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Models
{
    internal class Usuario
    {
        private int _id;
        private string _nome;
        private string _email;
        private string _senha;
        private DateTime _dataCadastro;
        private DateTime? _dataFim;
        private List<Questionario> _questionarios;

        internal int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        internal string Nome
        {
            get
            {
                return _nome;
            }

            set
            {
                _nome = value;
            }
        }

        internal string Email
        {
            get
            {
                return _email;
            }

            set
            {
                _email = value;
            }
        }

        internal string Senha
        {
            get
            {
                return _senha;
            }

            set
            {
                _senha = value;
            }
        }

        internal DateTime DataCadastro
        {
            get
            {
                return _dataCadastro;
            }

            set
            {
                _dataCadastro = value;
            }
        }

        internal DateTime? DataFim
        {
            get
            {
                return _dataFim;
            }

            set
            {
                _dataFim = value;
            }
        }

        internal List<Questionario> Questionarios
        {
            get
            {
                return _questionarios;
            }

            set
            {
                _questionarios = value;
            }
        }

        internal Usuario Autenticar(string email, string senha)
        {
            if (email.Contains("@") && email.Length > 3 && senha.Length > 0)
                return new UsuarioDAO().Autenticar(email, senha);
            else
                return null;
        }

        internal Usuario Obter(string email)
        {
            if (email.Contains("@") && email.Length > 3)
                return new UsuarioDAO().Obter(email);
            else
                return null;
        }

        internal int Gravar()
        {
            if (this.Id >= 0 && this.Nome.Length > 2 && this.Senha != "")
                return new UsuarioDAO().Gravar(this);
            else
                return -10;
        }
    }
}
