using Survey.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.DAL
{
    internal class UsuarioDAO : Banco
    {
        private List<Usuario> TableToList(DataTable dt)
        {
            List<Usuario> dados = null;
            if (dt != null && dt.Rows.Count > 0)
                dados = (from DataRow row in dt.Rows
                         select new Usuario()
                         {
                             Id = Convert.ToInt32(row["Id"]),
                             Nome = row["Nome"].ToString(),
                             Email = row["Email"].ToString(),
                             Senha = row["Senha"].ToString(),
                             DataCadastro = Convert.ToDateTime(row["DataCadastro"]),
                             DataFim = row["DataFim"] is DBNull ? (DateTime?)null : Convert.ToDateTime(row["DataFim"]),
                             Questionarios = null
                         }).ToList();
            return dados;
        }

        internal Usuario Autenticar(string email, string senha)
        {
            ComandoSQL.Parameters.Clear();
            ComandoSQL.CommandText = @"select * from Usuario
                                        where Email = @email and 
                                            Senha = @senha and
                                            DataFim is null";
            ComandoSQL.Parameters.AddWithValue("@email", email);
            ComandoSQL.Parameters.AddWithValue("@senha", senha);

            DataTable dt = ExecutaSelect();
            var dados = TableToList(dt);
            return dados == null ? null : dados.FirstOrDefault();
        }

        internal Usuario Obter(string email)
        {
            ComandoSQL.Parameters.Clear();
            ComandoSQL.CommandText = @"select * from Usuario
                                        where Email = @email and 
                                            DataFim is null";
            ComandoSQL.Parameters.AddWithValue("@email", email);

            DataTable dt = ExecutaSelect();
            var dados = TableToList(dt);
            return dados == null ? null : dados.FirstOrDefault();
        }

        internal int Gravar(Usuario u)
        {
            ComandoSQL.Parameters.Clear();
            if (u.Id == 0)
            ComandoSQL.CommandText = @"insert into Usuario (Nome, Email, Senha, DataCadastro) 
                    values (@nome, @email, @senha, @datacadastro)";
            else
            {
                ComandoSQL.CommandText = @"update Usuario set Nome = @nome, Senha = @senha, DataCadastro = @dataCadastro ";
                if (u.DataFim != null)
                    ComandoSQL.CommandText += ", DataFim = @dataFim ";
                ComandoSQL.CommandText += " where Id = @id";

                ComandoSQL.Parameters.AddWithValue("@id", u.Id);
                if (u.DataFim != null)
                    ComandoSQL.Parameters.AddWithValue("@dataFim", u.DataFim);
            }
            ComandoSQL.Parameters.AddWithValue("@nome", u.Nome);
            ComandoSQL.Parameters.AddWithValue("@email", u.Email);
            ComandoSQL.Parameters.AddWithValue("@senha", u.Senha);
            ComandoSQL.Parameters.AddWithValue("@datacadastro", u.DataCadastro);

            return ExecutaComando();
        }
    }
}
