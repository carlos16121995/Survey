using Survey.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.DAL
{
    internal class QuestionarioDAO : Banco
    {
        private List<Questionario> TableToList(DataTable dt)
        {
            List<Questionario> dados = null;
            if (dt != null && dt.Rows.Count > 0)
                dados = (from DataRow row in dt.Rows
                         select new Questionario()
                         {
                             Id = Convert.ToInt32(row["Id"]),
                             Nome = row["Nome"].ToString(),
                             MsgFeedback = row["MsgFeedback"].ToString(),
                             Guid = row["Guid"].ToString(),
                             Inicio = Convert.ToDateTime(row["Inicio"]),
                             Fim = Convert.ToDateTime(row["Fim"]),
                             UsuarioId = Convert.ToInt32(row["UsuarioId"]),
                             Imagem = row["Imagem"].ToString(),
                             Perguntas = null,
                             Usuario = null
                         }).ToList();
            return dados;
        }
        internal Questionario BuscarQuestionario(string guid)
        {
            ComandoSQL.Parameters.Clear();
            ComandoSQL.CommandText = @"select * 
                                        from Questionario 
                                        where Id = @guid = @guid";
            ComandoSQL.Parameters.AddWithValue("@guid", guid);
            DataTable dt = ExecutaSelect();
            var dados = TableToList(dt);
            return dados == null ? null : dados.FirstOrDefault();
        }
        internal List<Questionario> ObterPorUsuario(int id)
        {
            ComandoSQL.Parameters.Clear();
            ComandoSQL.CommandText = @"select Id, Nome, Inicio, Fim, MsgFeedback, Guid, Imagem, UsuarioId 
                                        from Questionario 
                                        where UsuarioId = @id
                                        order by Inicio desc";
            ComandoSQL.Parameters.AddWithValue("@id", id);
            DataTable dt = ExecutaSelect();
            return TableToList(dt);
        }

        internal List<Questionario> ObterPorPalavraChave(string palavra, int idUsuario)
        {
            ComandoSQL.Parameters.Clear();
            ComandoSQL.CommandText = @"select Id, Nome, Inicio, Fim, MsgFeedback, Guid, Imagem, UsuarioId 
                                        from Questionario 
                                        where Nome like @palavra and UsuarioId = @idUsuario
                                        order by Nome, Inicio";
            ComandoSQL.Parameters.AddWithValue("@palavra", "%" + palavra + "%");
            ComandoSQL.Parameters.AddWithValue("@idUsuario", idUsuario);
            DataTable dt = ExecutaSelect();
            return TableToList(dt);
        }

        internal Questionario Obter(int id, int idUsuario)
        {
            ComandoSQL.Parameters.Clear();
            ComandoSQL.CommandText = @"select Id, Nome, Inicio, Fim, MsgFeedback, Guid, Imagem, UsuarioId 
                                        from Questionario 
                                        where Id = @id and UsuarioId = @idUsuario";
            ComandoSQL.Parameters.AddWithValue("@id", id);
            ComandoSQL.Parameters.AddWithValue("@idUsuario", idUsuario);
            DataTable dt = ExecutaSelect();
            var dados = TableToList(dt);
            return dados == null ? null : dados.FirstOrDefault();
        }

        internal int Gravar(Questionario q)
        {
            ComandoSQL.Parameters.Clear();
            if (q.Id == 0)
                ComandoSQL.CommandText = @"insert into Questionario (Nome, Inicio, Fim, MsgFeedback, Guid, UsuarioId) 
                                    values (@nome, @inicio, @fim, @msgFeedback, @guid, @usuarioId)";
            else
            {
                ComandoSQL.CommandText = @"update Questionario set Nome = @nome, Inicio = @inicio, Fim = @fim, 
                                    MsgFeedback = @msgFeedback, Guid = @guid, UsuarioId = @usuarioId 
                                    where Id = @id";
                ComandoSQL.Parameters.AddWithValue("@id", q.Id);
            }
            ComandoSQL.Parameters.AddWithValue("@nome", q.Nome);
            ComandoSQL.Parameters.AddWithValue("@inicio", q.Inicio);
            ComandoSQL.Parameters.AddWithValue("@fim", q.Fim);
            ComandoSQL.Parameters.AddWithValue("@msgFeedback", q.MsgFeedback);
            ComandoSQL.Parameters.AddWithValue("@guid", q.Guid);
            ComandoSQL.Parameters.AddWithValue("@usuarioId", q.UsuarioId);
            return ExecutaComando();
        }

        internal int Excluir(int id)
        {
            ComandoSQL.Parameters.Clear();
            ComandoSQL.CommandText = @"delete from Questionario where id = @id";
            ComandoSQL.Parameters.AddWithValue("@id", id);
            return ExecutaComando();
        }
    }
}
