using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Models
{
    internal class Resposta
    {
        private int _id;
        private int _perguntaId;
        private int _alternativaId;
        private string _texto;
        private string _textoCurto;
        private decimal _numerica;
        private DateTime _data;
        private string _token;
        private Alternativa _alternativa;
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

        internal int AlternativaId
        {
            get
            {
                return _alternativaId;
            }

            set
            {
                _alternativaId = value;
            }
        }

        internal string Texto
        {
            get
            {
                return _texto;
            }

            set
            {
                _texto = value;
            }
        }

        internal string TextoCurto
        {
            get
            {
                return _textoCurto;
            }

            set
            {
                _textoCurto = value;
            }
        }

        internal decimal Numerica
        {
            get
            {
                return _numerica;
            }

            set
            {
                _numerica = value;
            }
        }

        internal DateTime Data
        {
            get
            {
                return _data;
            }

            set
            {
                _data = value;
            }
        }

        internal string Token
        {
            get
            {
                return _token;
            }

            set
            {
                _token = value;
            }
        }

        internal Alternativa Alternativa
        {
            get
            {
                return _alternativa;
            }

            set
            {
                _alternativa = value;
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
