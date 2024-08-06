using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleContatos
{
    internal class ExcluirContatos
    {
        private readonly string connectionString;

        public ExcluirContatos(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void ExcluirContato(string cpf)
        {
            try
            {
                int idUsuario = 0;
                
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sqlGetId = "SELECT id_usuario FROM contato WHERE cpf = @cpf";

                    using (SqlCommand cmdGetId = new SqlCommand(sqlGetId, conn))
                    { 
                        cmdGetId.Parameters.AddWithValue("@cpf", cpf);
                        idUsuario = Convert.ToInt32(cmdGetId.ExecuteScalar());
                    }

                    string sqlDeleteTelefone = "DELETE FROM num_telefone WHERE id_usuario = @id_usuario";

                    using (SqlCommand cmdDeleteTelefone = new SqlCommand(sqlDeleteTelefone, conn))
                    {
                        cmdDeleteTelefone.Parameters.AddWithValue("@id_usuario", idUsuario);
                        cmdDeleteTelefone.ExecuteNonQuery();
                    }

                    string sqlDeleteContato = "DELETE FROM contato WHERE cpf = @cpf";

                    using (SqlCommand cmdDeleteContato = new SqlCommand(sqlDeleteContato, conn))
                    {
                        cmdDeleteContato.Parameters.AddWithValue("@cpf", cpf);
                        cmdDeleteContato.ExecuteNonQuery();
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir contato: " + ex.Message);
            }
        }

        public void DeletarTelefone(string idTelefone)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = "DELETE FROM num_telefone WHERE id_telefone = @id_telefone";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id_telefone", idTelefone);
                        cmd.ExecuteNonQuery();
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir telefone: " + ex.Message);
            }
        }
    }
}
