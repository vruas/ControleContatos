using System;
using System.Data.SqlClient;

namespace ControleContatos
{
    public class NovoContato
    {
        private readonly string connectionString;

        public NovoContato(string connectionString)
        {
            this.connectionString = connectionString;
        }

        private int newId;

        public bool VerificaCPFExistente(string cpf)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string getCpfSql = "SELECT cpf FROM contato WHERE cpf = @cpf";

                using (SqlCommand sqlCommand = new SqlCommand(getCpfSql, conn))
                {
                    sqlCommand.Parameters.AddWithValue("@cpf", cpf);
                    var result = sqlCommand.ExecuteScalar();
                    if (result != null)
                    {
                        // CPF já cadastrado
                        return true;
                    }
                }

                conn.Close();
            }

            // CPF não encontrado
            return false;
        }

        public void AdicionarContato(string nome, string cpf, string endereco, string idTelefone, int tipoTelefone, int ddd, string telefone)
        {
            if (!IsValidCPF(cpf))
            {
                throw new Exception("CPF inválido");
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        int userId = 0;

                        // Verifica se o contato já existe
                        string checkContactExists = "SELECT id_usuario FROM contato WHERE cpf = @cpf";
                        using (SqlCommand cmdCheckContact = new SqlCommand(checkContactExists, conn, transaction))
                        {
                            cmdCheckContact.Parameters.AddWithValue("@cpf", cpf);
                            var result = cmdCheckContact.ExecuteScalar();
                            if (result != null)
                            {
                                userId = Convert.ToInt32(result);
                            }
                        }

                        // Se o contato não existe, insere um novo e incrementa o ID
                        if (userId == 0)
                        {
                            string getMaxId = "SELECT ISNULL(MAX(id_usuario), 0) FROM contato";
                            using (SqlCommand cmdGetMaxId = new SqlCommand(getMaxId, conn, transaction))
                            {
                                var result = cmdGetMaxId.ExecuteScalar();
                                if (result != DBNull.Value)
                                {
                                    userId = Convert.ToInt32(result) + 1;
                                }
                            }

                            string insertContato = "INSERT INTO contato (id_usuario, nome, cpf, endereco) VALUES (@id_usuario, @nome, @cpf, @endereco)";
                            using (SqlCommand cmdInsertContato = new SqlCommand(insertContato, conn, transaction))
                            {
                                cmdInsertContato.Parameters.AddWithValue("@id_usuario", userId);
                                cmdInsertContato.Parameters.AddWithValue("@nome", nome);
                                cmdInsertContato.Parameters.AddWithValue("@cpf", cpf);
                                cmdInsertContato.Parameters.AddWithValue("@endereco", endereco);
                                cmdInsertContato.ExecuteNonQuery();
                            }
                        }

                        // Insere o telefone
                        if (!string.IsNullOrEmpty(telefone))
                        {
                            string insertTelefone = "INSERT INTO num_telefone (id_usuario, id_telefone, tipo_tel, ddd_tel, telefone) VALUES (@id_usuario, @id_telefone, @tipo, @ddd, @telefone)";
                            string[] telefoneArray = telefone.Split(',');

                            foreach (string valor in telefoneArray)
                            {
                                using (SqlCommand cmdInsertTelefone = new SqlCommand(insertTelefone, conn, transaction))
                                {
                                    cmdInsertTelefone.Parameters.AddWithValue("@id_usuario", userId);
                                    cmdInsertTelefone.Parameters.AddWithValue("@id_telefone", idTelefone);
                                    cmdInsertTelefone.Parameters.AddWithValue("@tipo", tipoTelefone);
                                    cmdInsertTelefone.Parameters.AddWithValue("@ddd", ddd);
                                    cmdInsertTelefone.Parameters.AddWithValue("@telefone", valor);
                                    cmdInsertTelefone.ExecuteNonQuery();
                                }
                            }
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Erro ao adicionar novo contato: " + ex.Message);
                    }
                }
            }
        }









        //public void AdicionarUsuario(string nome, string cpf, string endereco)
        //{
        //    if (!IsValidCPF(cpf))
        //    {
        //        throw new Exception("CPF inválido");
        //    }

        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        conn.Open();
        //        using (SqlTransaction transaction = conn.BeginTransaction())
        //        {
        //            try
        //            {
        //                int maxId = 0;
        //                string getMaxId = "SELECT MAX(id_usuario) FROM contato";

        //                using (SqlCommand cmd = new SqlCommand(getMaxId, conn, transaction))
        //                {
        //                    var result = cmd.ExecuteScalar();
        //                    if (result != DBNull.Value)
        //                    {
        //                        maxId = Convert.ToInt32(result);
        //                    }
        //                }

        //                newId = maxId + 1;

        //                string insertContato = "INSERT INTO contato (id_usuario, nome, cpf, endereco) VALUES (@id_usuario, @nome, @cpf, @endereco)";
        //                using (SqlCommand cmd = new SqlCommand(insertContato, conn, transaction))
        //                {
        //                    cmd.Parameters.AddWithValue("@id_usuario", newId);
        //                    cmd.Parameters.AddWithValue("@nome", nome);
        //                    cmd.Parameters.AddWithValue("@cpf", cpf);
        //                    cmd.Parameters.AddWithValue("@endereco", endereco);
        //                    cmd.ExecuteNonQuery();
        //                }

        //                transaction.Commit();
        //            }
        //            catch (Exception ex)
        //            {
        //                transaction.Rollback();
        //                throw new Exception("Erro ao adicionar novo contato: " + ex.Message);
        //            }
        //        }
        //        conn.Close();
        //    }
        //}

        //public void AdicionarTelefone(string cpf, string idTelefone, int tipoTelefone, int ddd, string telefone)
        //{
        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        conn.Open();
        //        using (SqlTransaction transaction = conn.BeginTransaction())
        //        {
        //            try
        //            {
        //                int idUsuario = 0;
        //                string getIdUsuario = "SELECT id_usuario FROM contato WHERE cpf = @cpf";

        //                using (SqlCommand cmd = new SqlCommand(getIdUsuario, conn, transaction))
        //                {
        //                    cmd.Parameters.AddWithValue("@cpf", cpf);
        //                    var result = cmd.ExecuteScalar();
        //                    if (result != DBNull.Value)
        //                    {
        //                        idUsuario = Convert.ToInt32(result);
        //                    }
        //                    else
        //                    {
        //                        throw new Exception("Usuário com o CPF fornecido não encontrado.");
        //                    }
        //                }

        //                if (!string.IsNullOrEmpty(telefone))
        //                {
        //                    string delimitador = ",";
        //                    string[] telefoneArray = telefone.Split(new string[] { delimitador }, StringSplitOptions.None);

        //                    foreach (string valor in telefoneArray)
        //                    {
        //                        string insertTelefone = "INSERT INTO num_telefone (id_usuario, id_telefone, tipo_tel, ddd_tel, telefone) VALUES (@id_usuario, @id_telefone, @tipo, @ddd, @telefone)";
        //                        using (SqlCommand cmd = new SqlCommand(insertTelefone, conn, transaction))
        //                        {
        //                            cmd.Parameters.AddWithValue("@id_usuario", idUsuario);
        //                            cmd.Parameters.AddWithValue("@id_telefone", idTelefone);
        //                            cmd.Parameters.AddWithValue("@tipo", tipoTelefone);
        //                            cmd.Parameters.AddWithValue("@ddd", ddd);
        //                            cmd.Parameters.AddWithValue("@telefone", valor);
        //                            cmd.ExecuteNonQuery();
        //                        }
        //                    }
        //                }

        //                transaction.Commit();
        //            }
        //            catch (Exception ex)
        //            {
        //                transaction.Rollback();
        //                throw new Exception("Erro ao adicionar novo telefone: " + ex.Message);
        //            }
        //        }
        //        conn.Close();
        //    }
        //}

        public bool IsValidCPF(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;

            cpf = cpf.Trim().Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
                return false;

            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
        }
    }
}
