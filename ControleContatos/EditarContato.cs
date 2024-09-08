using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleContatos
{
    internal class EditarContato
    {
        private readonly string connectionString;

        public EditarContato(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool queryExecutada = false;

        public void AtualizarContato(string nome, string cpf, string endereco, List<(string idTelefone, int tipoTelefone, int ddd, string telefone)> telefones)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string nomeCadastrado = "";
                        string cpfCadastrado = "";
                        string enderecoCadastrado = "";

                        BuscaUsuarioCadastrado(ref nomeCadastrado, ref cpfCadastrado, ref enderecoCadastrado, ref cpf);

                        List<(string idTelefone, int tipoTelefone, int ddd, string telefone)> telefonesCadastrados = BuscaTelefonesCadastrados(cpf);

                        if (nomeCadastrado != nome || enderecoCadastrado != endereco)
                        {
                            //UpdateContato(nome, cpf, endereco);

                            try
                            {
                                string sql = @"
                            UPDATE contato
                            SET nome = @nome, endereco = @endereco
                            WHERE cpf = @cpf;";

                                using (SqlCommand cmd = new SqlCommand(sql, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@nome", nome);
                                    cmd.Parameters.AddWithValue("@cpf", cpf);
                                    cmd.Parameters.AddWithValue("@endereco", endereco);
                                    //cmd.ExecuteNonQuery();

                                    if (cmd.ExecuteNonQuery() > 0)
                                    {
                                        queryExecutada = true;
                                    }
                                   
                                }

                            }
                            catch (Exception ex)
                            {

                                throw new Exception("Erro ao atualizar usuário: " + ex.Message);
                            }
                        }

                        foreach (var (idTelefone, tipoTelefone, ddd, telefone) in telefones)
                        {
                            string idTelefoneEditado = idTelefone;
                            int tipoTelefoneEditado = tipoTelefone;
                            int dddEditado = ddd;
                            string telefoneEditado = telefone;

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

                            string sqlCheckExistence = "SELECT COUNT(*) FROM num_telefone WHERE id_telefone = @idTelefone";

                            using (SqlCommand cmdCheckExistence = new SqlCommand(sqlCheckExistence, conn, transaction))
                            {
                                cmdCheckExistence.Parameters.AddWithValue("@idTelefone", idTelefone);
                                int count = (int)cmdCheckExistence.ExecuteScalar();

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
                                        //cmdInsertTelefone.ExecuteNonQuery();

                                        if (cmdInsertTelefone.ExecuteNonQuery() > 0)
                                        {
                                            queryExecutada = true;
                                        }
                                        
                                    }
                                }
                                else
                                {

                                    foreach (var (idTelefoneCadastrado, tipoTelefoneCadastrado, dddCadastrado, telefoneCadastrado) in telefonesCadastrados)
                                    {
                                        if (idTelefoneEditado == idTelefoneCadastrado)
                                        {
                                            if (tipoTelefoneEditado != tipoTelefoneCadastrado || dddEditado != dddCadastrado || telefoneEditado != telefoneCadastrado)
                                            {
                                                //UpdateTelefone(cpf, telefones);

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
                                                    //cmdUpdateTelefone.ExecuteNonQuery();

                                                    if (cmdUpdateTelefone.ExecuteNonQuery() > 0)
                                                    {
                                                        queryExecutada = true;
                                                    }
                                                   
                                                }
                                            }
                                        }
                                    }

                                }

                            }


                        }

                        transaction.Commit();
                        if (queryExecutada)
                        {
                            MessageBox.Show("Contato atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Nenhuma informação foi alterada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }


                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Erro ao atualizar contato: " + ex.Message);
                    }

                    
                }

                conn.Close();
            }

        }




        //foreach (var (idTelefoneCadastrado, tipoTelefoneCadastrado, dddCadastrado, telefoneCadastrado) in telefonesCadastrados)
        //{
        //    if (idTelefoneEditado == idTelefoneCadastrado)
        //    {
        //        if (tipoTelefoneEditado != tipoTelefoneCadastrado || dddEditado != dddCadastrado || telefoneEditado != telefoneCadastrado)
        //        {
        //            //UpdateTelefone(cpf, telefones);

        //            string sqlCheckExistence = "SELECT COUNT(*) FROM num_telefone WHERE id_telefone = @idTelefone";

        //            using (SqlCommand cmdCheckTelefone = new SqlCommand(sqlCheckExistence, conn, transaction))
        //            {


        //                cmdCheckTelefone.Parameters.AddWithValue("@idTelefone", idTelefone);
        //                int count = (int)cmdCheckTelefone.ExecuteScalar();

        //                if (count == 0)
        //                {
        //                    string sqlInsertTelefone = @"
        //                                INSERT INTO num_telefone (id_telefone, id_usuario, tipo_tel, ddd_tel, telefone) 
        //                                VALUES (@idTelefone, @idUsuario, @tipo, @ddd, @telefone)";

        //                    using (SqlCommand cmdInsertTelefone = new SqlCommand(sqlInsertTelefone, conn, transaction))
        //                    {
        //                        cmdInsertTelefone.Parameters.AddWithValue("@idTelefone", idTelefone);
        //                        cmdInsertTelefone.Parameters.AddWithValue("@idUsuario", userCount);
        //                        cmdInsertTelefone.Parameters.AddWithValue("@tipo", tipoTelefone);
        //                        cmdInsertTelefone.Parameters.AddWithValue("@ddd", ddd);
        //                        cmdInsertTelefone.Parameters.AddWithValue("@telefone", telefone);
        //                        cmdInsertTelefone.ExecuteNonQuery();
        //                    }
        //                }
        //                else
        //                {
        //                    string sqlUpdateTelefone = @"
        //                                UPDATE num_telefone 
        //                                SET tipo_tel = @tipo, ddd_tel = @ddd, telefone = @telefone 
        //                                WHERE id_telefone = @idTelefone";

        //                    using (SqlCommand cmdUpdateTelefone = new SqlCommand(sqlUpdateTelefone, conn, transaction))
        //                    {
        //                        cmdUpdateTelefone.Parameters.AddWithValue("@idTelefone", idTelefone);
        //                        cmdUpdateTelefone.Parameters.AddWithValue("@tipo", tipoTelefone);
        //                        cmdUpdateTelefone.Parameters.AddWithValue("@ddd", ddd);
        //                        cmdUpdateTelefone.Parameters.AddWithValue("@telefone", telefone);
        //                        cmdUpdateTelefone.ExecuteNonQuery();
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}



        //public void UpdateContato(string nome, string cpf, string endereco)
        //{
        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        conn.Open();

        //        try
        //        {
        //            string sql = @"
        //                    UPDATE contato
        //                    SET nome = @nome, endereco = @endereco
        //                    WHERE cpf = @cpf;";

        //            using (SqlCommand cmd = new SqlCommand(sql, conn))
        //            {
        //                cmd.Parameters.AddWithValue("@nome", nome);
        //                cmd.Parameters.AddWithValue("@cpf", cpf);
        //                cmd.Parameters.AddWithValue("@endereco", endereco);
        //                cmd.ExecuteNonQuery();
        //            }

        //        }
        //        catch (Exception ex)
        //        {

        //            throw new Exception("Erro ao atualizar usuário: " + ex.Message);
        //        }

        //        conn.Close();
        //    }
        //}



        //public void UpdateTelefone(string cpf, List<(string idTelefone, int tipoTelefone, int ddd, string telefone)> telefones)
        //{
        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        conn.Open();

        //        try
        //        {
        //            string sqlCheckUser = "SELECT id_usuario FROM contato WHERE cpf = @cpf";
        //            int userCount = 0;

        //            using (SqlCommand cmdCheckUser = new SqlCommand(sqlCheckUser, conn))
        //            {
        //                cmdCheckUser.Parameters.AddWithValue("@cpf", cpf);

        //                using (SqlDataReader reader = cmdCheckUser.ExecuteReader())
        //                {
        //                    if (reader.Read())
        //                    {
        //                        userCount = reader.GetInt32(0);
        //                    }
        //                }
        //            }

        //            if (userCount == 0)
        //            {
        //                throw new Exception("Usuário não encontrado.");
        //            }

        //            string sqlCheckExistence = "SELECT COUNT(*) FROM num_telefone WHERE id_telefone = @idTelefone";

        //            using (SqlCommand cmdCheckTelefone = new SqlCommand(sqlCheckExistence, conn))
        //            {
        //                foreach (var item in telefones)
        //                {
        //                    var idTelefone = item.idTelefone;
        //                    var tipoTelefone = item.tipoTelefone;
        //                    var ddd = item.ddd;
        //                    var telefone = item.telefone;

        //                    cmdCheckTelefone.Parameters.AddWithValue("@idTelefone", idTelefone);
        //                    int count = (int)cmdCheckTelefone.ExecuteScalar();

        //                    if (count == 0)
        //                    {
        //                        string sqlInsertTelefone = @"
        //                                INSERT INTO num_telefone (id_telefone, id_usuario, tipo_tel, ddd_tel, telefone) 
        //                                VALUES (@idTelefone, @idUsuario, @tipo, @ddd, @telefone)";

        //                        using (SqlCommand cmdInsertTelefone = new SqlCommand(sqlInsertTelefone, conn))
        //                        {
        //                            cmdInsertTelefone.Parameters.AddWithValue("@idTelefone", idTelefone);
        //                            cmdInsertTelefone.Parameters.AddWithValue("@idUsuario", userCount);
        //                            cmdInsertTelefone.Parameters.AddWithValue("@tipo", tipoTelefone);
        //                            cmdInsertTelefone.Parameters.AddWithValue("@ddd", ddd);
        //                            cmdInsertTelefone.Parameters.AddWithValue("@telefone", telefone);
        //                            cmdInsertTelefone.ExecuteNonQuery();
        //                        }
        //                    }
        //                    else
        //                    {
        //                        string sqlUpdateTelefone = @"
        //                                UPDATE num_telefone 
        //                                SET tipo_tel = @tipo, ddd_tel = @ddd, telefone = @telefone 
        //                                WHERE id_telefone = @idTelefone";

        //                        using (SqlCommand cmdUpdateTelefone = new SqlCommand(sqlUpdateTelefone, conn))
        //                        {
        //                            cmdUpdateTelefone.Parameters.AddWithValue("@idTelefone", idTelefone);
        //                            cmdUpdateTelefone.Parameters.AddWithValue("@tipo", tipoTelefone);
        //                            cmdUpdateTelefone.Parameters.AddWithValue("@ddd", ddd);
        //                            cmdUpdateTelefone.Parameters.AddWithValue("@telefone", telefone);
        //                            cmdUpdateTelefone.ExecuteNonQuery();
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {

        //            throw new Exception("Erro ao atualizar telefone: " + ex.Message);
        //        }

        //        conn.Close();
        //    }
        //}


        public void BuscaUsuarioCadastrado(ref string nomeCadastrado, ref string cpfCadastrado, ref string enderecoCadastrado, ref string cpf)
        {
            DataTable contato = new DataTable();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT nome, cpf, endereco FROM contato WHERE cpf = @cpf";
                       

                    using (SqlCommand cmdVerificaContato = new SqlCommand(sql, conn))
                    {
                        cmdVerificaContato.Parameters.AddWithValue("@cpf", cpf);

                        using (SqlDataReader reader = cmdVerificaContato.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                nomeCadastrado = reader["nome"].ToString();
                                cpfCadastrado = reader["cpf"].ToString();
                                enderecoCadastrado = reader["endereco"].ToString();
                               
                            }
                        }
                    }

                    conn.Close();
                }


            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao pesquisar contato: " + ex.Message);
            }

        }

        public List<(string idTelefone, int tipoTelefone, int ddd, string telefone)> BuscaTelefonesCadastrados(string cpf)
        {
            List<(string idTelefone, int tipoTelefone, int ddd, string telefone)> telefonesCadastrados = new List<(string idTelefone, int tipoTelefone, int ddd, string telefone)>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = @"
                     SELECT b.id_telefone, b.tipo_tel, b.ddd_tel, b.telefone
                     FROM contato a
                     INNER JOIN num_telefone b ON a.id_usuario = b.id_usuario
                     WHERE a.cpf = @cpf;";

                    using (SqlCommand cmdBuscaTelefones = new SqlCommand(sql, conn))
                    {
                        cmdBuscaTelefones.Parameters.AddWithValue("@cpf", cpf);

                        using (SqlDataReader reader = cmdBuscaTelefones.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string idTelefone = reader["id_telefone"].ToString();
                                int tipoTelefone = Convert.ToInt32(reader["tipo_tel"]);
                                int ddd = Convert.ToInt32(reader["ddd_tel"]);
                                string telefone = reader["telefone"].ToString();

                                telefonesCadastrados.Add((idTelefone, tipoTelefone, ddd, telefone));
                            }
                        }
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao pesquisar telefones: " + ex.Message);
            }

            return telefonesCadastrados;
        }

    }
}




// Método para atualizar informações de um contato

//public void AtualizaContato(string nome, string cpf, string endereco, List<(string idTelefone, int tipoTelefone, int ddd, string telefone)> telefones/*string idTelefone, int tipoTel, int ddd, string telefone*/)
//{
//    using (SqlConnection conn = new SqlConnection(connectionString))
//    {
//        conn.Open();
//        using (SqlTransaction transaction = conn.BeginTransaction())
//        {
//            try
//            {
//                //verificar se as informações de contato foram alteradas, se sim fazer update, se não pular o update

//                string nomeCadastrado = "";
//                string cpfCadastrado = "";
//                string enderecoCadastrado = "";


//                int tipoTelCadastrado = 0;
//                int dddCadastrado = 0;
//                string telefoneCadastrado = "";


//                BuscaContatoCadastrado(ref nomeCadastrado, ref cpfCadastrado, ref enderecoCadastrado, ref tipoTelCadastrado, ref dddCadastrado, ref telefoneCadastrado, cpf);

//                if (nomeCadastrado != nome  || enderecoCadastrado != endereco)
//                {
//                    string sqlUpdateContato = "UPDATE contato SET nome = @nome, endereco = @endereco WHERE cpf = @cpf";

//                    using (SqlCommand cmdUpdateContato = new SqlCommand(sqlUpdateContato, conn, transaction))
//                    {
//                        cmdUpdateContato.Parameters.AddWithValue("@nome", nome);
//                        cmdUpdateContato.Parameters.AddWithValue("@endereco", endereco);
//                        cmdUpdateContato.Parameters.AddWithValue("@cpf", cpf);
//                        cmdUpdateContato.ExecuteNonQuery();
//                    }
//                }
//                // Obter o id_usuario do contato
//                string sqlCheckUser = "SELECT id_usuario FROM contato WHERE cpf = @cpf";
//                int userCount = 0;

//                using (SqlCommand cmdCheckUser = new SqlCommand(sqlCheckUser, conn, transaction))
//                {
//                    cmdCheckUser.Parameters.AddWithValue("@cpf", cpf);

//                    using (SqlDataReader reader = cmdCheckUser.ExecuteReader())
//                    {
//                        if (reader.Read())
//                        {
//                            userCount = reader.GetInt32(0);
//                        }
//                    }
//                }

//                if (userCount == 0)
//                {
//                    throw new Exception("Usuário não encontrado.");
//                }



//                // verificar se os telefones foram alteradas, se sim fazer update, se não pular o update
//                foreach (var item in telefones)
//                {
//                    // Acessa os valores de cada telefone na lista
//                    var idTelefone = item.idTelefone;
//                    var tipoTelefone = item.tipoTelefone;
//                    var ddd = item.ddd;
//                    var telefone = item.telefone;

//                    // Exibe informações para depuração
//                    Console.WriteLine($"Processando telefone: ID = {idTelefone}, Tipo = {tipoTelefone}, DDD = {ddd}, Número = {telefone}");

//                    // Verifica se os valores do telefone atual são diferentes dos valores cadastrados
//                    if (tipoTelCadastrado != tipoTelefone || dddCadastrado != ddd || telefoneCadastrado != telefone)
//                    {
//                        // Verifica se o telefone já existe no banco de dados
//                        string sqlCheckExistence = "SELECT COUNT(*) FROM num_telefone WHERE id_telefone = @idTelefone";

//                        using (SqlCommand cmdCheckTelefone = new SqlCommand(sqlCheckExistence, conn, transaction))
//                        {
//                            cmdCheckTelefone.Parameters.AddWithValue("@idTelefone", idTelefone);
//                            int count = (int)cmdCheckTelefone.ExecuteScalar();

//                            if (count == 0)
//                            {
//                                // Telefone não existe, inserir novo registro
//                                string sqlInsertTelefone = "INSERT INTO num_telefone (id_telefone, id_usuario, tipo_tel, ddd_tel, telefone) VALUES (@idTelefone, @idUsuario, @tipo, @ddd, @telefone)";

//                                using (SqlCommand cmdInsertTelefone = new SqlCommand(sqlInsertTelefone, conn, transaction))
//                                {
//                                    cmdInsertTelefone.Parameters.AddWithValue("@idTelefone", idTelefone);
//                                    cmdInsertTelefone.Parameters.AddWithValue("@idUsuario", userCount);
//                                    cmdInsertTelefone.Parameters.AddWithValue("@tipo", tipoTelefone);
//                                    cmdInsertTelefone.Parameters.AddWithValue("@ddd", ddd);
//                                    cmdInsertTelefone.Parameters.AddWithValue("@telefone", telefone);
//                                    cmdInsertTelefone.ExecuteNonQuery();

//                                    Console.WriteLine($"Telefone inserido: ID = {idTelefone}");
//                                }
//                            }
//                            else
//                            {
//                                // Telefone já existe, atualizar registro
//                                string sqlUpdateTelefone = "UPDATE num_telefone SET tipo_tel = @tipo, ddd_tel = @ddd, telefone = @telefone WHERE id_telefone = @idTelefone";

//                                using (SqlCommand cmdUpdateTelefone = new SqlCommand(sqlUpdateTelefone, conn, transaction))
//                                {
//                                    cmdUpdateTelefone.Parameters.AddWithValue("@idTelefone", idTelefone);
//                                    cmdUpdateTelefone.Parameters.AddWithValue("@tipo", tipoTelefone);
//                                    cmdUpdateTelefone.Parameters.AddWithValue("@ddd", ddd);
//                                    cmdUpdateTelefone.Parameters.AddWithValue("@telefone", telefone);
//                                    cmdUpdateTelefone.ExecuteNonQuery();

//                                    Console.WriteLine($"Telefone atualizado: ID = {idTelefone}");
//                                }
//                            }
//                        }
//                    }
//                    else
//                    {
//                        Console.WriteLine($"Nenhuma alteração necessária para o telefone: ID = {idTelefone}");
//                    }
//                }                      
//                // Confirmar a transação
//                transaction.Commit();
//            }
//            catch (Exception ex)
//            {
//                transaction.Rollback();
//                throw new Exception("Erro ao atualizar contato: " + ex.Message);
//            }
//        }

//        conn.Close();
//    }
//}













