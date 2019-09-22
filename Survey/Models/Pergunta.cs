using Survey.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Models
{
    internal class Pergunta
    {
        private int _id;
        private string _titulo;
        private string _descricao;
        private string _dica;
        private char _obrigatoria;
        private decimal _ordem;
        private short _tipoId;
        private int _questionarioId;
        private List<Resposta> _respostas; 

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

        internal string Titulo
        {
            get
            {
                return _titulo;
            }

            set
            {
                _titulo = value;
            }
        }

        internal string Descricao
        {
            get
            {
                return _descricao;
            }

            set
            {
                _descricao = value;
            }
        }

        internal string Dica
        {
            get
            {
                return _dica;
            }

            set
            {
                _dica = value;
            }
        }

        internal char Obrigatoria
        {
            get
            {
                return _obrigatoria;
            }

            set
            {
                _obrigatoria = value;
            }
        }

        internal decimal Ordem
        {
            get
            {
                return _ordem;
            }

            set
            {
                _ordem = value;
            }
        }

        internal short TipoId
        {
            get
            {
                return _tipoId;
            }

            set
            {
                _tipoId = value;
            }
        }

        internal int QuestionarioId
        {
            get
            {
                return _questionarioId;
            }

            set
            {
                _questionarioId = value;
            }
        }

        internal List<Resposta> Respostas
        {
            get
            {
                return _respostas;
            }

            set
            {
                _respostas = value;
            }
        }

        internal Pergunta BuscarPergunta(string guid)
        {
            return new PerguntaDAO().BuscarPergunta(guid);
        }
    }
}
