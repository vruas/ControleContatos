using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
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

        int idUsuario = 0;
        string idTelefoneNovo = string.Empty;

        public void AtualizarContato(string nome, string cpf, string endereco, List<(string idTelefone, int tipoTelefone, int ddd, string telefone)> telefones, List<string> telefonesRemovidos)
        {
            try
            {


                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    EditarUsuario(nome, cpf, endereco, conn);

                    try
                    {
                        using (SqlTransaction transaction = conn.BeginTransaction())
                        {
                            foreach (var (idTelefone, tipoTelefone, ddd, telefone) in telefones)
                            {
                                if (verificaExistenciaTelefone(idTelefone, conn, transaction))
                                {
                                    EditarTelefone(cpf, idTelefone, tipoTelefone, ddd, telefone, conn, transaction);
                                }
                                else
                                {
                                    InserirTelefone(cpf, idTelefone, tipoTelefone, ddd, telefone, conn, transaction);
                                }
                            }

                            if (telefonesRemovidos.Count > 0)
                            {
                                ExcluirTelefone(telefonesRemovidos, conn, transaction);
                            }

                            transaction.Commit();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Erro ao atualizar contato: " + ex.Message);
                    }

                    conn.Close();
                }
                    
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar contato: " + ex.Message);
            }
           

            //foreach (var (idTelefone, tipoTelefone, ddd, telefone) in telefones)
            //{
            //    if (verificaExistenciaTelefone(idTelefone))
            //    {
            //        EditarTelefone(cpf, idTelefone, tipoTelefone, ddd, telefone);
            //    }
            //    else
            //    {
            //        InserirTelefone(cpf, idTelefone, tipoTelefone, ddd, telefone);
            //    }
            //}

            //if (telefonesRemovidos.Count > 0)
            //{
            //    ExcluirTelefone(telefonesRemovidos);
            //}

        }

        public void EditarUsuario(string nome, string cpf, string endereco, SqlConnection conn)
        {
            string nomeCadastrado = string.Empty;
            string cpfCadastrado = string.Empty;
            string enderecoCadastrado = string.Empty;

            BuscaUsuarioCadastrado(ref nomeCadastrado, ref cpfCadastrado, ref enderecoCadastrado, ref cpf);

            if (nomeCadastrado != nome || enderecoCadastrado != endereco)
            {
                try
                {

                    string sql = @"
                            UPDATE contato
                            SET nome = @nome, endereco = @endereco
                            WHERE cpf = @cpf;";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@nome", nome);
                        cmd.Parameters.AddWithValue("@cpf", cpf);
                        cmd.Parameters.AddWithValue("@endereco", endereco);
                        cmd.ExecuteNonQuery();
                        queryExecutada = true;
                    }

                    //using (SqlConnection conn = new SqlConnection(connectionString))
                    //{
                    //    conn.Open();

                    //    string sql = @"
                    //        UPDATE contato
                    //        SET nome = @nome, endereco = @endereco
                    //        WHERE cpf = @cpf;";

                    //    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    //    {
                    //        cmd.Parameters.AddWithValue("@nome", nome);
                    //        cmd.Parameters.AddWithValue("@cpf", cpf);
                    //        cmd.Parameters.AddWithValue("@endereco", endereco);
                    //        cmd.ExecuteNonQuery();
                    //        queryExecutada = true;
                    //    }

                    //    conn.Close();
                    //}
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao atualizar contato: " + ex.Message);
                }
            }
            else
            {
                queryExecutada = false;
            }

        }

        public bool verificaExistenciaTelefone(string idTelefone, SqlConnection conn, SqlTransaction transaction)
        {
            if (idTelefone != null)
            {
                try
                {
                    string telefoneCount = "SELECT COUNT(*) FROM num_telefone WHERE id_telefone = @idTelefone";

                    using (SqlCommand cmdCount = new SqlCommand(telefoneCount, conn, transaction))
                    {
                        cmdCount.Parameters.AddWithValue("@idTelefone", idTelefone);
                        int count = (int)cmdCount.ExecuteScalar();

                        if (count > 0)
                        {
                            return true;
                        }
                        else
                        {
                            idTelefoneNovo = idTelefone;
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao verificar existência do telefone: " + ex.Message);
                }
            }

            return false;
        }

        public void BuscarIdUsuario(string cpf)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = "SELECT id_usuario FROM contato WHERE cpf = @cpf";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@cpf", cpf);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                idUsuario = reader.GetInt32(0);
                            }
                        }
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar id do usuário: " + ex.Message);
            }
        }

        public void InserirTelefone(string cpf, string idTelefone, int tipoTelefone, int ddd, string telefone, SqlConnection conn, SqlTransaction transaction)
        {
            if (idTelefone == idTelefoneNovo)
            {
                BuscarIdUsuario(cpf);
                
                try
                {
                    string sqlInsert = @"
                        INSERT INTO num_telefone (id_telefone, id_usuario, tipo_tel, ddd_tel, telefone)
                        VALUES (@idTelefone, @idUsuario, @tipoTelefone, @ddd, @telefone);";

                    using (SqlCommand cmdInsert = new SqlCommand(sqlInsert, conn, transaction))
                    {
                        cmdInsert.Parameters.AddWithValue("@idTelefone", idTelefone);
                        cmdInsert.Parameters.AddWithValue("@idUsuario", idUsuario);
                        cmdInsert.Parameters.AddWithValue("@tipoTelefone", tipoTelefone);
                        cmdInsert.Parameters.AddWithValue("@ddd", ddd);
                        cmdInsert.Parameters.AddWithValue("@telefone", telefone);
                        cmdInsert.ExecuteNonQuery();
                        queryExecutada = true;
                    }

                }
                catch (Exception ex)
                {
                    
                    throw new Exception("Erro ao inserir telefone: " + ex.Message);
                }
            }
            else
            {
                queryExecutada = false;
            }
        }

        public void EditarTelefone(string cpf, string idTelefone, int tipoTelefone, int ddd, string telefone, SqlConnection conn, SqlTransaction transaction)
        {
            

            string idTelCad = string.Empty;
            int tipoTelCad = 0;
            int dddCad = 0;
            string telefoneCad = string.Empty;

           

            if (idTelefone != null)
            {
                try
                {
                    List<(string idTelefone, int tipoTelefone, int ddd, string telefone)> telefonesCadastrados = BuscaTelefonesCadastrados(cpf);

                    foreach (var (idTelefoneCadastrado, tipoTelefoneCadastrado, dddCadastrado, telefoneCadastrado) in telefonesCadastrados)
                    {
                        idTelCad = idTelefoneCadastrado;
                        tipoTelCad = tipoTelefoneCadastrado;
                        dddCad = dddCadastrado;
                        telefoneCad = telefoneCadastrado;

                        string sqlUpdate = "UPDATE num_telefone SET tipo_tel = @tipoTelefone, ddd_tel = @ddd, telefone = @telefone WHERE id_telefone = @idTelefone";

                        if (idTelCad == idTelefone)
                        {
                            if (tipoTelCad != tipoTelefone || dddCad != ddd || telefoneCad != telefone)
                            {
                                using (SqlCommand cmdUpdate = new SqlCommand(sqlUpdate, conn, transaction))
                                {
                                    cmdUpdate.Parameters.Clear();
                                    cmdUpdate.Parameters.AddWithValue("@idTelefone", idTelefone);
                                    cmdUpdate.Parameters.AddWithValue("@tipoTelefone", tipoTelefone);
                                    cmdUpdate.Parameters.AddWithValue("@ddd", ddd);
                                    cmdUpdate.Parameters.AddWithValue("@telefone", telefone);
                                    cmdUpdate.ExecuteNonQuery();
                                    queryExecutada = true;
                                }
                            }
                        }
                    }


                }
                catch (Exception ex)
                {
                    
                    throw new Exception("Erro ao editar telefone: " + ex.Message);
                }

                
            }
            else
            {
                queryExecutada = false;
            }
        }

        public void ExcluirTelefone(List<string> telefonesRemovidos, SqlConnection conn, SqlTransaction transaction)
        {
            try
            {
                

                int countTelefones = 0;

                string sqlCountTelefones = "SELECT COUNT(*) FROM num_telefone WHERE id_telefone = @idTelefone";

                foreach (var idTel in telefonesRemovidos)
                {
                    if (idTel != null)
                    {
                        using (SqlCommand cmdCountTelefones = new SqlCommand(sqlCountTelefones, conn, transaction))
                        {
                            cmdCountTelefones.Parameters.Clear();
                            cmdCountTelefones.Parameters.AddWithValue("@idTelefone", idTel);
                            countTelefones = (int)cmdCountTelefones.ExecuteScalar();
                        }

                        if (countTelefones > 0)
                        {
                            string sqlDelete = "DELETE FROM num_telefone WHERE id_telefone = @idTelefone";

                            using (SqlCommand cmdDelete = new SqlCommand(sqlDelete, conn, transaction))
                            {
                                cmdDelete.Parameters.Clear();
                                cmdDelete.Parameters.AddWithValue("@idTelefone", idTel);
                                cmdDelete.ExecuteNonQuery();
                                queryExecutada = true;
                            }

                        }
                    }
                    else
                    {
                        queryExecutada = false;
                    }
                }
            }
            catch (Exception ex)
            {
                
                throw new Exception("Erro ao excluir telefone: " + ex.Message);
            }
        }



        




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
                if (ex.HResult == -2146232060)
                {
                    MessageBox.Show("A agenda está em atualização. Por favor, tente novamente mais tarde.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                { 
                    throw new Exception("Erro ao pesquisar contato: " + ex.Message);
                
                }
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
                if (ex.HResult == -2146232060)
                {
                    MessageBox.Show("A agenda está em atualização. Por favor, tente novamente mais tarde.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    throw new Exception("Erro ao pesquisar telefones: " + ex.Message);
                }
            }

            return telefonesCadastrados;
        }

    }
}


















