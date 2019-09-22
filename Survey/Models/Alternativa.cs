using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Models
{
    internal class Alternativa
    {
        private int _id;
        private string _opcao;
        private short _ordem;
        private int _perguntaId;
        private TipoPergunta _tipoPergunta;
        private List<Resposta> _respostas;
        private Pergunta _pergunta;

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

        internal string Opcao
        {
            get
            {
                return _opcao;
            }

            set
            {
                _opcao = value;
            }
        }

        internal short Ordem
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

        internal int PerguntaId
        {
            get
            {
                return _perguntaId;
            }

            set
            {
                _perguntaId = value;
            }
        }

        internal TipoPergunta TipoPergunta
        {
            get
            {
                return _tipoPergunta;
            }

            set
            {
                _tipoPergunta = value;
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

        internal Pergunta Pergunta
        {
            get
            {
                return _pergunta;
            }

            set
            {
                _pergunta = value;
            }
        }
    }
}
