using System;
using System.Data.SqlClient;
using System.Data;

namespace Survey.DAL
{
    /// <summary>
    /// Classe responsável pela conexão com o banco de dados e execução de comandos de SQL
    /// </summary>
    internal class Banco
    {
        /// <summary>
        /// Campo responsável pela definição da string de conexão
        /// </summary>
        private string _strConexao;
        /// <summary>
        /// Campo responsável pelo comando de SQL a ser executado
        /// </summary>
        private SqlCommand _comandoSQL;
        /// <summary>
        /// Propriedade que expõe o campo para definição do comando de SQL a ser executado
        /// </summary>
        protected SqlCommand ComandoSQL
        {
            get { return _comandoSQL; }
            set { _comandoSQL = value; }
        }
        /// <summary>
        /// Campo que define o objeto de conexão
        /// </summary>
        private SqlConnection _conn;
        /// <summary>
        /// Campo que define o objeto de transação
        /// </summary>
        private SqlTransaction _transacao;
        /// <summary>
        /// Construtor que define uma string de conexão fixa e cria os objetos de conexão e 
        /// comando
        /// </summary>
        protected Banco()
        {
            _strConexao = @"Data Source=den1.mssql3.gear.host;Initial Catalog=surveyprof;Persist Security Info=True;User ID=surveyprof;Password=Cb1Wnx~Jr0a!";
            _conn = new SqlConnection(_strConexao);
            _comandoSQL = new SqlCommand();
            _comandoSQL.Connection = _conn;
        }
        /// <summary>
        /// Construtor que recebe por parametro a string de conexão a ser utilizada e cria
        /// os objetos de comando e conexão
        /// </summary>
        /// <param name="stringConexao">String de conexão a ser utilizada</param>
        protected Banco(string stringConexao)
        {
            _strConexao = stringConexao;
            _conn = new SqlConnection(_strConexao);
            _comandoSQL = new SqlCommand();
            _comandoSQL.Connection = _conn;
        }
        /// <summary>
        /// Método para abrir a conexão com o banco de dados
        /// </summary>
        /// <param name="transacao">true -> Com transação | false -> Sem transação</param>
        /// <returns></returns>
        protected bool AbreConexao(bool transacao)
        {
            try
            {
                _conn.Open();
                if (transacao)
                {
                    _transacao = _conn.BeginTransaction();
                    _comandoSQL.Transaction = _transacao;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Métodos para fechar a conexão com o banco de dados
        /// </summary>
        /// <returns>Retorna um booleano para indicar o resultado da operação</returns>
        protected bool FechaConexao()
        {
            try
            {
                if (_conn.State == ConnectionState.Open)
                    _conn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Finaliza uma transação
        /// </summary>
        /// <param name="commit">true -> Executa o commit | false -. Executa o rollback</param>
        protected void FinalizaTransacao(bool commit)
        {
            if (commit)
                _transacao.Commit();
            else
                _transacao.Rollback();
            FechaConexao();
        }
        /// <summary>
        /// Destrutor que fecha a conexão com o banco de dados
        /// </summary>
        ~Banco()
        {
            FechaConexao();
        }
        /// <summary>
        /// Método responsável pela execução dos comandos de Insert, Update e Delete
        /// </summary>
        /// <returns>Retorna um número inteiro que indica a quantidade de linhas afetadas</returns>
        protected int ExecutaComando(bool transacao = false)
        {
            if (_comandoSQL.CommandText.Trim() == string.Empty)
                throw new Exception("Não há instrução SQL a ser executada.");

            int retorno;
            AbreConexao(transacao);
            try
            {
                retorno = _comandoSQL.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                retorno = -1;
                throw new Exception("Erro ao executar o comando SQL:", ex);
            }
            finally
            {
                if (!transacao)
                    FechaConexao();
            }
            return retorno;
        }
        /// <summary>
        /// Método responsável pela execução dos comandos de Insert com retorno do último código cadastrado
        /// </summary>
        /// <returns>Retorna um número inteiro que indica a quantidade de linhas afetadas</returns>
        protected int ExecutaComando(bool transacao, out int ultimoCodigo)
        {
            if (_comandoSQL.CommandText.Trim() == string.Empty)
                throw new Exception("Não há instrução SQL a ser executada.");

            int retorno;
            ultimoCodigo = 0;
            AbreConexao(transacao);
            try
            {
                //Executa o comando de insert e já retorna o @@IDENTITY
                ultimoCodigo = Convert.ToInt32(_comandoSQL.ExecuteScalar());
                retorno = 1;
            }
            catch(Exception ex)
            {
                retorno = -1;
                throw new Exception("Erro ao executar o comando SQL: ", ex);
            }
            finally
            {
                if (!transacao)
                    FechaConexao();
            }
            return retorno;
        }
        /// <summary>
        /// Método responsável pela execução dos comandos de Select
        /// </summary>
        /// <returns>Retorna um DataTable com o resultado da operação</returns>
        protected DataTable ExecutaSelect()
        {
            if (_comandoSQL.CommandText.Trim() == string.Empty)
                throw new Exception("Não há instrução SQL a ser executada.");

            AbreConexao(false);
            DataTable dt = new DataTable();
            try
            {
                dt.Load(_comandoSQL.ExecuteReader());
            }
            catch(Exception ex)
            {
                dt = null;
                throw new Exception("Erro ao executar o comando SQL: ", ex);
            }
            finally
            {
                FechaConexao();
            }
            return dt;
        }
        /// <summary>
        /// Método que executa comandos de Select para retornos escalares, ou seja,
        /// retorna a primeira linha e primeira coluna do resultado do comando de Select.
        /// Para nosso exemplo, sempre convertemos esse valor para Double
        /// </summary>
        /// <returns>Retorna a primeira linha e primeira coluna do resultado comando de Select</returns>
        protected double ExecutaScalar()
        {
            if (_comandoSQL.CommandText.Trim() == string.Empty)
                throw new Exception("Não há instrução SQL a ser executada.");

            
			_comandoSQL.CommandText += "; select @@identity";
			AbreConexao(false);
            double retorno;
            try
            {
                retorno = Convert.ToDouble(_comandoSQL.ExecuteScalar());
            }
            catch(Exception ex)
            {
                retorno = -9999;
                //throw new Exception("Erro ao executar o comando SQL: ", ex);
            }
            finally
            {
                FechaConexao();
            }
            return retorno;
        }
    }
}