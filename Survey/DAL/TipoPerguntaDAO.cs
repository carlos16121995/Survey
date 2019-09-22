using Survey.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.DAL
{
    internal class TipoPerguntaDAO : Banco
    {
        private TipoPergunta ConvertToObject(DataRow row)
        {
            TipoPergunta tp = new TipoPergunta()
            {
                Id = Convert.ToInt16(row["Id"]),
                Nome = row["Nome"].ToString()
            };
            return tp;
        }

        private List<TipoPergunta> ConvertToList(DataTable dt)
        {
            List<TipoPergunta> dados = null;
            if (dt != null && dt.Rows.Count > 0)
            {
                dados = new List<TipoPergunta>();
                foreach (DataRow dr in dt.Rows)
                    dados.Add(ConvertToObject(dr));
            }
            return dados;
        }

        internal List<TipoPergunta> Obter()
        {
            ComandoSQL.Parameters.Clear();
            ComandoSQL.CommandText = @"select * from TipoPergunta order by Nome";

            DataTable dt = ExecutaSelect();
            if (dt != null && dt.Rows.Count > 0)
                return ConvertToList(dt);
            else
                return null;
        }

        internal TipoPergunta Obter(int id)
        {
            ComandoSQL.Parameters.Clear();
            ComandoSQL.CommandText = @"select * from TipoPergunta where Id = @id";
            ComandoSQL.Parameters.AddWithValue("@id", id);

            DataTable dt = ExecutaSelect();
            if (dt != null && dt.Rows.Count > 0)
                return ConvertToObject(dt.Rows[0]);
            else
                return null;
        }

        internal int Gravar(TipoPergunta tp)
        {
            ComandoSQL.Parameters.Clear();
            if (tp.Id == 0)
            {
                ComandoSQL.CommandText = @"insert into TipoPergunta (Nome)
                        values (@nome)";
            }
            else
            {
                ComandoSQL.CommandText = @"update TipoPergunta set Nome = @nome where Id = @id";
                ComandoSQL.Parameters.AddWithValue("@id", tp.Id);
            }
            ComandoSQL.Parameters.AddWithValue("@nome", tp.Nome);
            return ExecutaComando();
        }

        internal int Excluir(int id)
        {
            ComandoSQL.Parameters.Clear();
            ComandoSQL.CommandText = @"delete from TipoPergunta where Id = @id";
            ComandoSQL.Parameters.AddWithValue("@id", id);
            return ExecutaComando();
        }
    }
}
