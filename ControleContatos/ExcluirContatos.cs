 using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public bool telefoneExlcuido = false;
        public void DeletarTelefone(string idTelefone)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // Primeiro, obtenha o id_usuario associado ao telefone
                            string sqlSelectUser = "SELECT id_usuario FROM num_telefone WHERE id_telefone = @idTelefone";
                            int idUsuario = 0;

                            using (SqlCommand cmd = new SqlCommand(sqlSelectUser, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@idTelefone", idTelefone);
                                var resultado = cmd.ExecuteScalar();
                                if (resultado != null)
                                {
                                    idUsuario = Convert.ToInt32(resultado);
                                }
                            }

                            string sqlCountTelefones = "SELECT COUNT(*) FROM num_telefone WHERE id_usuario = @idUsuario";
                            using (SqlCommand cmd = new SqlCommand(sqlCountTelefones, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                                int count = Convert.ToInt32(cmd.ExecuteScalar());
                                if (count == 1)
                                {
                                    MessageBox.Show("Não é possível excluir o último telefone do usuário.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    telefoneExlcuido = false;
                                    return;

                                    //DialogResult result = MessageBox.Show("Este é o último telefone do usuário. Se você excluir este telefone, o contato será excluído. Deseja excluir o contato?", "Excluir contato", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                    //if (result == DialogResult.Yes)
                                    //{
                                    //    // Excluir o contato
                                    //    string sqlDeleteUser = "DELETE FROM contato WHERE id_usuario = @idUsuario";
                                    //    using (SqlCommand cmdDeleteUser = new SqlCommand(sqlDeleteUser, conn, transaction))
                                    //    {
                                    //        cmdDeleteUser.Parameters.AddWithValue("@idUsuario", idUsuario);
                                    //        cmdDeleteUser.ExecuteNonQuery();
                                    //    }
                                    //}

                                    // Excluir o contato do usuário se ele não tiver mais telefones
                                    //string sqlDeleteUser = "DELETE FROM contato WHERE id_usuario = @idUsuario";
                                    //using (SqlCommand cmdDeleteUser = new SqlCommand(sqlDeleteUser, conn, transaction))
                                    //{
                                    //    cmdDeleteUser.Parameters.AddWithValue("@idUsuario", idUsuario);
                                    //    cmdDeleteUser.ExecuteNonQuery();
                                    //}
                                }
                                else
                                {
                                    if (idUsuario > 0)
                                    {
                                        // Excluir o telefone
                                        string sql = "DELETE FROM num_telefone WHERE id_telefone = @id_telefone";
                                        using (SqlCommand cmdDelete = new SqlCommand(sql, conn, transaction))
                                        {
                                            cmdDelete.Parameters.AddWithValue("@id_telefone", idTelefone);
                                            cmdDelete.ExecuteNonQuery();

                                            telefoneExlcuido = true;
                                        }

                                        // Verificar se o usuário ainda possui outros telefones

                                    }
                                }
                            }

                            

                            // Commit da transação se tudo ocorrer bem
                            transaction.Commit();
                        }
                        catch
                        {
                            // Rollback da transação em caso de erro
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir telefone: " + ex.Message);
            }
        }

    }
}
