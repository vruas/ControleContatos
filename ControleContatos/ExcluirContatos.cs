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
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // Obter o id_usuario com base no CPF
                            string sqlGetId = "SELECT id_usuario FROM contato WHERE cpf = @cpf";
                            using (SqlCommand cmdGetId = new SqlCommand(sqlGetId, conn, transaction))
                            {
                                cmdGetId.Parameters.AddWithValue("@cpf", cpf);
                                idUsuario = Convert.ToInt32(cmdGetId.ExecuteScalar());
                            }

                          
                            List<string> telefoneIds = new List<string>();

                            string sqlGetTelefoneIds = "SELECT id_telefone FROM num_telefone WHERE id_usuario = @id_usuario";
                            using (SqlCommand cmdGetTelefoneIds = new SqlCommand(sqlGetTelefoneIds, conn, transaction))
                            {
                                cmdGetTelefoneIds.Parameters.AddWithValue("@id_usuario", idUsuario);
                                using (SqlDataReader reader = cmdGetTelefoneIds.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        telefoneIds.Add(reader.GetString(0)); 
                                    }
                                }
                            }

                           //percorre a lista e exclui todos os telefones
                            string sqlDeleteTelefone = "DELETE FROM num_telefone WHERE id_telefone = @id_telefone";
                            foreach (var idTelefone in telefoneIds)
                            {
                                using (SqlCommand cmdDeleteTelefone = new SqlCommand(sqlDeleteTelefone, conn, transaction))
                                {
                                    cmdDeleteTelefone.Parameters.AddWithValue("@id_telefone", idTelefone);
                                    cmdDeleteTelefone.ExecuteNonQuery();
                                }
                            }

                            // no fim exclui o contato
                            string sqlDeleteContato = "DELETE FROM contato WHERE cpf = @cpf";
                            using (SqlCommand cmdDeleteContato = new SqlCommand(sqlDeleteContato, conn, transaction))
                            {
                                cmdDeleteContato.Parameters.AddWithValue("@cpf", cpf);
                                cmdDeleteContato.ExecuteNonQuery();
                            }

                           
                            transaction.Commit();
                        }
                        catch
                        {
                  
                            transaction.Rollback();
                            throw;
                        }
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
