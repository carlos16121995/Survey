using Survey.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Models
{
    internal class TipoPergunta
    {
        private short _id;
        private string _nome;
        private List<Pergunta> _perguntas;

        internal short Id
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

        internal List<Pergunta> Perguntas
        {
            get
            {
                return _perguntas;
            }

            set
            {
                _perguntas = value;
            }
        }

        internal List<TipoPergunta> Obter()
        {
            return new TipoPerguntaDAO().Obter();
        }

        internal TipoPergunta Obter(int id)
        {
            if (id > 0)
                return new TipoPerguntaDAO().Obter(id);
            else
                return null;
        }

        internal int Gravar()
        {
            if (this.Id >= 0 && this.Nome.Trim().Length > 0)
                return new TipoPerguntaDAO().Gravar(this);
            else
                return -10;
        }

        internal int Excluir(int id)
        {
            if (id > 0)
                return new TipoPerguntaDAO().Excluir(id);
            else
                return -10;
        }

    }
}
