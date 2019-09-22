using Survey.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.DAL
{
    internal class PerguntaDAO : Banco
    {
        private List<Pergunta> TableToList(DataTable dt)
        {
            List<Pergunta> dados = null;
            if (dt != null && dt.Rows.Count > 0)
                dados = (from DataRow row in dt.Rows
                         select new Pergunta()
                         {
                             Id = Convert.ToInt32(row["Id"]),
                             Titulo = row["Titulo"].ToString(),
                             Dica = row["Dica"].ToString(),
                             Descricao = row["Descricao"].ToString(),
                             Obrigatoria = Convert.ToChar(row["Obrigatoria"]),
                             Ordem = Convert.ToInt32(row["Ordem"]),
                             TipoId = Convert.ToInt16(row["TipoId"]),
                             QuestionarioId = Convert.ToInt32(row["QuestionarioId"]),
                         }).ToList();
            return dados;
        }
        internal Pergunta BuscarPergunta(string guid)
        {
            ComandoSQL.Parameters.Clear();
            ComandoSQL.CommandText = @"select * 
                                        from Pergunta 
                                        where Guid = @guid";
            ComandoSQL.Parameters.AddWithValue("@guid", guid);
            DataTable dt = ExecutaSelect();
            var dados = TableToList(dt);
            return dados == null ? null : dados.FirstOrDefault();
        }

    }
}
