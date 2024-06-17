using Microsoft.Data.SqlClient;
using NuGet.Protocol.Plugins;
using AgendaTotal.Models;

namespace AgendaTotal.Repositories.ADO.SQLServer
{
    public class LoginDAO
    {
        private readonly string connectionString;
        public LoginDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool check(Usuario login)
        {
            bool result = false;
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT id_usuario FROM tb_usuarios WHERE EMAIL=@EMAIL AND SENHA=@SENHA;";
                    command.Parameters.Add(new SqlParameter("@EMAIL", System.Data.SqlDbType.VarChar)).Value = login.email;
                    command.Parameters.Add(new SqlParameter("@SENHA", System.Data.SqlDbType.VarChar)).Value = login.senha;

                    SqlDataReader dr = command.ExecuteReader();

                    result = dr.Read();
                }
            }
            return result;
        }
        
        public LoginResultado getTipo(Usuario login)
        {
            LoginResultado result = new LoginResultado();
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT id_usuario, nome FROM tb_usuarios WHERE email=@email AND SENHA=@SENHA;";
                    command.Parameters.Add(new SqlParameter("@email", System.Data.SqlDbType.VarChar)).Value = login.email;
                    command.Parameters.Add(new SqlParameter("@SENHA", System.Data.SqlDbType.VarChar)).Value = login.senha;

                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        result.Sucesso = dr.Read();
                        if (result.Sucesso)
                        {
                            result.Id = (int)dr["id_usuario"];
                            result.TipoUsuario = dr["nome"].ToString();

                            login.id_usuario = result.Id;
                            login.nome = result.TipoUsuario;
                        }
                    }
                }
            }
            return result;
        }
    }
}

