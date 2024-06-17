using AgendaTotal.Models;
using Microsoft.Data.SqlClient;
using Microsoft.VisualStudio.Web.CodeGeneration.Design;

namespace AgendaTotal.Repositories.ADO.SQLServer
{
    public class UsuarioDAO
    {
            //Declarado para toda a classe. Possível alterar somente no construtor.
            private readonly string connectionString;

            //Quem invocar o construtor do repositório deve enviar a string de conexão.
            public UsuarioDAO(string connectionString)
            {
                // atualização do atributo por meio do valor que veio
                // no parâmetro do construtor.
                this.connectionString = connectionString;
            }

            /* Método para Listar todos os Carros. */
            public List<Usuario> getAll() // get() ou getCarros ou getAllCarros()
            {
                List<Usuario> usuarios = new List<Usuario>();

                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    //Abrir conexão do banco de dados: CarroDB
                    connection.Open();

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "SELECT * FROM tb_usuarios";

                        SqlDataReader dr = command.ExecuteReader();

                        while (dr.Read())
                        {
                            Usuario usuario = new Usuario();

                            usuario.id_usuario = (int)dr["id_usuario"];
                            usuario.nome = dr["nome"].ToString();
                            usuario.email = (string)dr["email"];
                            usuario.senha = (string)dr["senha"];
                            usuario.pais = (string)dr["pais"];
                            usuario.status_ = (bool)dr["status_"];

                            usuarios.Add(usuario);
                        }
                    }

                }

                return usuarios;
            }

            /* Método para Listar somente 1 Carro. */
            public Usuario getByIdUsuario(int id)
            {
                Usuario usuario = new Usuario();

                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    // Abrir conexão do banco de dados: CarroDB
                    connection.Open();

                    using (SqlCommand command = new SqlCommand())
                    {
                        // Cria o comando (instrução SQL) que será feita a tabela carro do banco de dados CarrosDB
                        command.Connection = connection;
                        command.CommandText = "select * from tb_usuarios where id_usuario=@id_usuario;";
                        command.Parameters.Add(new SqlParameter("@id_usuario", System.Data.SqlDbType.Int)).Value = id;

                        // Faz a consulta através do comando e retorna o resultado da consulta para o objeto dr (da classe SqlDataReader)
                        SqlDataReader dr = command.ExecuteReader();

                        // Caso encontrado um carro na consulta, os dados serão carregados no objeto carro.
                        if (dr.Read())
                        {
                            usuario.id_usuario = (int)dr["id_usuario"];
                            usuario.nome = dr["nome"].ToString();
                            usuario.email = (string)dr["email"];
                            usuario.senha = (string)dr["senha"];
                            usuario.pais = (string)dr["pais"];
                            usuario.status_ = (bool)dr["status_"];
                    }
                    }
                }
                return usuario; // retorna o carro encontrado na consulta.
            }

            /* Método para Editar um Carro pelo seu identificador (id). */
            public void update(int id, Usuario usuario)
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    // Abrir conexão do banco de dados: CarroDB
                    connection.Open();

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        // Cria o comando (instrução SQL) que será feita a atualização do carro
                        // na tabela do carro no banco de dados CarrosDB.
                        command.CommandText = "UPDATE tb_usuarios SET nome=@nome, " +
                                              "email=@email," +
                                              "senha=@senha," +
                                              "pais=@pais," +
                                              "status_=@status_ "+
                                              "WHERE id_usuario=@id_usuario;";
                        command.Parameters.Add(new SqlParameter("@nome", System.Data.SqlDbType.VarChar)).Value = usuario.nome;
                        command.Parameters.Add(new SqlParameter("@email", System.Data.SqlDbType.VarChar)).Value = usuario.email;
                        command.Parameters.Add(new SqlParameter("@senha", System.Data.SqlDbType.VarChar)).Value = usuario.senha;
                        command.Parameters.Add(new SqlParameter("@pais", System.Data.SqlDbType.VarChar)).Value = usuario.pais;
                        command.Parameters.Add(new SqlParameter("@status_", System.Data.SqlDbType.Bit)).Value = usuario.status_;
                        command.Parameters.Add(new SqlParameter("@id_usuario", System.Data.SqlDbType.Int)).Value = id;

                        /* Executar a atualização dos dados da tabela carro. */
                        command.ExecuteNonQuery();
                    }
                }
            }

            /* Método para Adicionar um Carro - objeto carro. */
            public void add(Usuario usuario)
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    // Abrir conexão do banco de dados: CarroDB
                    connection.Open();

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        // Cria o comando (instrução SQL) que será feita a inserção do carro
                        // na tabela do carro no banco de dados CarrosDB.
                        command.CommandText = "INSERT INTO tb_usuarios (nome, email, senha, pais,status_) " +
                                              "VALUES (@nome, @email, @senha, @pais,@status_);" +
                                              "SELECT CONVERT(INT,@@IDENTITY) AS id_usuario;;";
                        command.Parameters.Add(new SqlParameter("@nome", System.Data.SqlDbType.VarChar)).Value = usuario.nome;
                        command.Parameters.Add(new SqlParameter("@email", System.Data.SqlDbType.VarChar)).Value = usuario.email;
                        command.Parameters.Add(new SqlParameter("@senha", System.Data.SqlDbType.VarChar)).Value = usuario.senha;
                        command.Parameters.Add(new SqlParameter("@pais", System.Data.SqlDbType.VarChar)).Value = usuario.pais;
                        command.Parameters.Add(new SqlParameter("@status_", System.Data.SqlDbType.Bit)).Value = usuario.status_;

                    usuario.id_usuario = (int)command.ExecuteScalar(); // o homem do saco leva os dados até o
                                                                 // SGBD e volta com o valor do id -> ExecuteScalar retorna um único valor. Observe que
                                                                 // o ComandText foi alterado com mais de uma instrução. Então, as duas instruções são 
                                                                 // executadas e temos como retorno o valor do id que foi gerado pelo SGBD na tabela
                                                                 // carro. Assim, conseguimos atualizar o valor do id do objeto carro que antes da
                                                                 // inserção era 0.
                    } // finaliza SqlCommand.
                } // finaliza SqlConnection.
            } // fim do método add.

            /* Método para Remover um Carro pelo seu identificador (id). */
            public void delete(int id)
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    // Abrir conexão do banco de dados: CarroDB
                    connection.Open();

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        // Cria o comando (instrução SQL) que será feita a remoção do carro
                        // na tabela do carro no banco de dados CarrosDB.
                        command.CommandText = "DELETE FROM tb_usuarios WHERE id_usuario=@id_usuario";
                        command.Parameters.Add(new SqlParameter("@id_usuario", System.Data.SqlDbType.Int)).Value = id;

                        /* Executar a remoção dos dados da tabela carro. */
                        command.ExecuteNonQuery();
                    }
                }
            }

        }
    }


