using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleContatos
{
    internal class ListarContatos
    {
        private readonly string connectionString;

        public ListarContatos(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public DataTable GetContatos()
        {
            DataTable agenda = new DataTable();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = @"
                            SELECT 
                            a.id_usuario, 
                            a.nome, 
                            a.cpf, 
                            b.id_telefone,
                            b.tipo_tel, 
                            b.ddd_tel, 
                            b.telefone, 
                            a.endereco                        
                        FROM 
                            contato a                        
                        INNER JOIN 
                            num_telefone b ON a.id_usuario = b.id_usuario
                        WHERE b.id_telefone IS NOT NULL
                        ORDER BY a.id_usuario";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            agenda.Load(reader);
                        }
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar contatos: " + ex.Message);
            }
            return agenda;
        }

        public DataTable PesquisarContato(string cpf)
        {
            DataTable contato = new DataTable();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"
                        SELECT a.id_usuario, a.nome, a.cpf, b.id_telefone, b.tipo_tel, b.ddd_tel, b.telefone, a.endereco
                        FROM contato a
                        INNER JOIN num_telefone b ON a.id_usuario = b.id_usuario
                        WHERE a.cpf = @cpf;";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@cpf", cpf);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            contato.Load(reader);
                        }
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao pesquisar contato: " + ex.Message);
            }
            return contato;
        }

        



    }
}
