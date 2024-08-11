using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleContatos
{
    internal class EditarContato
    {
        private readonly string connectionString;

        public EditarContato(string connectionString)
        {
            this.connectionString = connectionString;
        }



        public void AtualizaContato(string nome, string cpf, string endereco, List<(string idTelefone, int tipoTelefone, int ddd, string telefone)> telefones/*string idTelefone, int tipoTel, int ddd, string telefone*/)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // Atualizar informações do contato
                        string sqlUpdateContato = "UPDATE contato SET nome = @nome, endereco = @endereco WHERE cpf = @cpf";

                        using (SqlCommand cmdUpdateContato = new SqlCommand(sqlUpdateContato, conn, transaction))
                        {
                            cmdUpdateContato.Parameters.AddWithValue("@nome", nome);
                            cmdUpdateContato.Parameters.AddWithValue("@endereco", endereco);
                            cmdUpdateContato.Parameters.AddWithValue("@cpf", cpf);
                            cmdUpdateContato.ExecuteNonQuery();
                        }

                        // Obter o id_usuario do contato
                        string sqlCheckUser = "SELECT id_usuario FROM contato WHERE cpf = @cpf";
                        int userCount = 0;

                        using (SqlCommand cmdCheckUser = new SqlCommand(sqlCheckUser, conn, transaction))
                        {
                            cmdCheckUser.Parameters.AddWithValue("@cpf", cpf);

                            using (SqlDataReader reader = cmdCheckUser.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    userCount = reader.GetInt32(0);
                                }
                            }
                        }

                        if (userCount == 0)
                        {
                            throw new Exception("Usuário não encontrado.");
                        }


                        //foreach (var (idTelefone, tipoTelefone, ddd, telefone) in telefones)
                        //{
                        //    string checkTelefoneExists = "SELECT COUNT(*) FROM num_telefone WHERE id_usuario = @id_usuario AND telefone = @telefone";
                        //    using (SqlCommand cmdCheckTelefone = new SqlCommand(checkTelefoneExists, conn, transaction))
                        //    {
                        //        cmdCheckTelefone.Parameters.AddWithValue("@id_usuario", userId);
                        //        cmdCheckTelefone.Parameters.AddWithValue("@telefone", telefone);
                        //        int count = (int)cmdCheckTelefone.ExecuteScalar();

                        //        if (count > 0)
                        //        {
                        //            throw new Exception("Um ou mais números de telefone já estão cadastrados para este usuário.");
                        //        }
                        //    }
                        //}



                        //Verificar existência do telefone

                        foreach (var (idTelefone, tipoTelefone, ddd, telefone) in telefones)
                        {
                            string sqlCheckExistence = "SELECT COUNT(*) FROM num_telefone WHERE id_telefone = @idTelefone";

                            using (SqlCommand cmdCheckTelefone = new SqlCommand(sqlCheckExistence, conn, transaction))
                            {
                                cmdCheckTelefone.Parameters.AddWithValue("@idTelefone", idTelefone);
                                int count = (int)cmdCheckTelefone.ExecuteScalar();

                                if (count == 0)
                                {
                                    string sqlInsertTelefone = @"
                                               INSERT INTO num_telefone (id_telefone, id_usuario, tipo_tel, ddd_tel, telefone) 
                                                    VALUES (@idTelefone, @idUsuario, @tipo, @ddd, @telefone)";

                                    using (SqlCommand cmdInsertTelefone = new SqlCommand(sqlInsertTelefone, conn, transaction))
                                    {
                                        cmdInsertTelefone.Parameters.AddWithValue("@idTelefone", idTelefone);
                                        cmdInsertTelefone.Parameters.AddWithValue("@idUsuario", userCount);
                                        cmdInsertTelefone.Parameters.AddWithValue("@tipo", tipoTelefone);
                                        cmdInsertTelefone.Parameters.AddWithValue("@ddd", ddd);
                                        cmdInsertTelefone.Parameters.AddWithValue("@telefone", telefone);
                                        cmdInsertTelefone.ExecuteNonQuery();
                                    }
                                }
                                else
                                {
                                    // Atualizar telefone existente
                                    string sqlUpdateTelefone = @"
                                        UPDATE num_telefone 
                                        SET tipo_tel = @tipo, ddd_tel = @ddd, telefone = @telefone 
                                        WHERE id_telefone = @idTelefone";

                                    using (SqlCommand cmdUpdateTelefone = new SqlCommand(sqlUpdateTelefone, conn, transaction))
                                    {
                                        cmdUpdateTelefone.Parameters.AddWithValue("@idTelefone", idTelefone);
                                        cmdUpdateTelefone.Parameters.AddWithValue("@tipo", tipoTelefone);
                                        cmdUpdateTelefone.Parameters.AddWithValue("@ddd", ddd);
                                        cmdUpdateTelefone.Parameters.AddWithValue("@telefone", telefone);
                                        cmdUpdateTelefone.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                        

                      

                   

                        //using (SqlCommand cmdCheckExistence = new SqlCommand(sqlCheckExistence, conn, transaction))
                        //{
                        //    cmdCheckExistence.Parameters.AddWithValue("@idTelefone", idTelefone);
                        //    int count = (int)cmdCheckExistence.ExecuteScalar();

                        //    if (count == 0)
                        //    {


                        //        // Inserir novo telefone
                        //        string sqlInsertTelefone = @"
                        //    INSERT INTO num_telefone (id_telefone, id_usuario, tipo_tel, ddd_tel, telefone) 
                        //    VALUES (@idTelefone, @idUsuario, @tipo, @ddd, @telefone)";

                        //        using (SqlCommand cmdInsertTelefone = new SqlCommand(sqlInsertTelefone, conn, transaction))
                        //        {
                        //            cmdInsertTelefone.Parameters.AddWithValue("@idTelefone", idTelefone);
                        //            cmdInsertTelefone.Parameters.AddWithValue("@idUsuario", userCount);
                        //            cmdInsertTelefone.Parameters.AddWithValue("@tipo", tipoTel);
                        //            cmdInsertTelefone.Parameters.AddWithValue("@ddd", ddd);
                        //            cmdInsertTelefone.Parameters.AddWithValue("@telefone", telefone);
                        //            cmdInsertTelefone.ExecuteNonQuery();
                        //        }
                        //    }
                        //    else
                        //    {
                        //        // Atualizar telefone existente
                        //        string sqlUpdateTelefone = @"
                        //    UPDATE num_telefone 
                        //    SET tipo_tel = @tipo, ddd_tel = @ddd, telefone = @telefone 
                        //    WHERE id_telefone = @idTelefone";

                        //        using (SqlCommand cmdUpdateTelefone = new SqlCommand(sqlUpdateTelefone, conn, transaction))
                        //        {
                        //            cmdUpdateTelefone.Parameters.AddWithValue("@idTelefone", idTelefone);
                        //            cmdUpdateTelefone.Parameters.AddWithValue("@tipo", tipoTel);
                        //            cmdUpdateTelefone.Parameters.AddWithValue("@ddd", ddd);
                        //            cmdUpdateTelefone.Parameters.AddWithValue("@telefone", telefone);
                        //            cmdUpdateTelefone.ExecuteNonQuery();
                        //        }
                        //    }
                        //}

                        // Confirmar a transação
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Erro ao atualizar contato: " + ex.Message);
                    }
                }
            }
        }
    }
}








            //public void AtualizaUsuario(string nome, string cpf, string endereco)
            //{
            //    using (SqlConnection conn = new SqlConnection(connectionString))
            //    {
            //        conn.Open();
            //        using (SqlTransaction transaction = conn.BeginTransaction())
            //        {
            //            try
            //            {
            //                string sql = @"
            //                    UPDATE contato
            //                    SET nome = @nome, endereco = @endereco
            //                    WHERE cpf = @cpf;";

//                using (SqlCommand cmd = new SqlCommand(sql, conn, transaction))
//                {
//                    cmd.Parameters.AddWithValue("@nome", nome);
//                    cmd.Parameters.AddWithValue("@endereco", endereco);
//                    cmd.Parameters.AddWithValue("@cpf", cpf);
//                    cmd.ExecuteNonQuery();
//                }

//                transaction.Commit();
//            }
//            catch (Exception ex)
//            {
//                transaction.Rollback();
//                throw new Exception("Erro ao atualizar usuário: " + ex.Message);
//            }
//        }
//        conn.Close();
//    }
//}

//public void AtualizaTelefone(string cpf, string idTelefone, int tipoTel, int ddd, string telefone)
//{
//    using (SqlConnection conn = new SqlConnection(connectionString))
//    {
//        conn.Open();
//        using (SqlTransaction transaction = conn.BeginTransaction())
//        {
//            try
//            {
//                int userCount = 0;
//                string sqlCheckExistence = "SELECT COUNT(*) FROM num_telefone WHERE id_telefone = @idTelefone";

//                using (SqlCommand cmdCheckExistence = new SqlCommand(sqlCheckExistence, conn, transaction))
//                {
//                    cmdCheckExistence.Parameters.AddWithValue("@idTelefone", idTelefone);
//                    int count = (int)cmdCheckExistence.ExecuteScalar();

//                    if (count == 0)
//                    {
//                        string sqlCheckUser = "SELECT id_usuario FROM contato WHERE cpf = @cpf";

//                        using (SqlCommand cmdCheckUser = new SqlCommand(sqlCheckUser, conn, transaction))
//                        {
//                            cmdCheckUser.Parameters.AddWithValue("@cpf", cpf);

//                            using (SqlDataReader reader = cmdCheckUser.ExecuteReader())
//                            {
//                                if (reader.Read())
//                                {
//                                    userCount = reader.GetInt32(0);
//                                }

//                                reader.Close();
//                            }
//                        }

//                        if (userCount == 0)
//                        {
//                            throw new Exception("Usuário não encontrado.");
//                        }

//                        string sqlInsertTelefone = @"
//                            INSERT INTO
//                                num_telefone (id_telefone, id_usuario, tipo_tel, ddd_tel, telefone) 
//                            VALUES 
//                                (@idTelefone, @idUsuario, @tipo, @ddd, @telefone)";
//                        using (SqlCommand cmdInsertTelefone = new SqlCommand(sqlInsertTelefone, conn, transaction))
//                        {
//                            cmdInsertTelefone.Parameters.AddWithValue("@idTelefone", idTelefone);
//                            cmdInsertTelefone.Parameters.AddWithValue("@idUsuario", userCount);
//                            cmdInsertTelefone.Parameters.AddWithValue("@tipo", tipoTel);
//                            cmdInsertTelefone.Parameters.AddWithValue("@ddd", ddd);
//                            cmdInsertTelefone.Parameters.AddWithValue("@telefone", telefone);
//                            cmdInsertTelefone.ExecuteNonQuery();
//                        }
//                    }
//                    else
//                    {
//                        string sqlUpdateTelefone = @"
//                            UPDATE
//                                num_telefone 
//                            SET 
//                                tipo_tel = @tipo, ddd_tel = @ddd, telefone = @telefone 
//                            WHERE 
//                                id_telefone = @idTelefone";
//                        using (SqlCommand cmdUpdateTelefone = new SqlCommand(sqlUpdateTelefone, conn, transaction))
//                        {
//                            cmdUpdateTelefone.Parameters.AddWithValue("@idTelefone", idTelefone);
//                            cmdUpdateTelefone.Parameters.AddWithValue("@tipo", tipoTel);
//                            cmdUpdateTelefone.Parameters.AddWithValue("@ddd", ddd);
//                            cmdUpdateTelefone.Parameters.AddWithValue("@telefone", telefone);
//                            cmdUpdateTelefone.ExecuteNonQuery();
//                        }
//                    }
//                }

//                transaction.Commit();
//            }
//            catch (Exception ex)
//            {
//                transaction.Rollback();
//                throw new Exception("Erro ao atualizar telefone: " + ex.Message);
//            }
//        }
//        conn.Close();
//    }
//}


