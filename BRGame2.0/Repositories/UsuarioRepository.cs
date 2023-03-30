using BRGame2._0.Interfaces;
using BRGame2._0.Models;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

namespace BRGame2._0.Repositories
{
    public class UsuarioRepository : IUsuariosRepository
    {
        
        readonly string connectionString = "Data Source=DESKTOP-LDCFMA3\\SQLEXPRESS;Integrated Security=true;Initial Catalog=BRGames";


        public bool Delete(int id)
        {
            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                string script = "DELETE FROM [BRGames].[dbo].[UsuarioGamer]  WHERE Id=@id";

                using (SqlCommand cmd = new SqlCommand(script, conexao))
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    cmd.CommandType = CommandType.Text;
                    int linhasAfetadas = cmd.ExecuteNonQuery();
                    if (linhasAfetadas == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public ICollection<Usuario> GetAll()
        {
            var listaUsuario = new List<Usuario>();

            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                string consulta = "SELECT * FROM [BRGames].[dbo].[UsuarioGamer]";

                using (SqlCommand cmd = new SqlCommand(consulta, conexao))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listaUsuario.Add(new Usuario
                            {
                                Id = (int)reader[0],
                                Nome = (string)reader[1],
                                Email = (string)reader[2],
                                Senha = (string)reader[3],
                                Idade = (string)reader[4]
                            });
                        }
                    }
                }
            }
            return listaUsuario;

        }

        public Usuario GetById(int id)
        {
            var usuario = new Usuario();

            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                string consulta = "SELECT * FROM [BRGames].[dbo].[UsuarioGamer] WHERE Id=@id";

                using (SqlCommand cmd = new SqlCommand(consulta, conexao))
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            usuario.Id = (int)reader[0];
                            usuario.Nome = (string)reader[1];
                            usuario.Email = (string)reader[2];
                            usuario.Senha = (string)reader[3];
                            usuario.Idade = (string)reader[4];
                        }
                    }
                }
            }
            return usuario;
        }

        public Usuario Insert(Usuario usuario)
        {
            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                string script = "INSERT INTO [BRGames].[dbo].[UsuarioGamer] (Nome, Email, Senha, Idade) VALUES (@Nome, @Email, @Senha, @Idade)";

                using (SqlCommand cmd = new SqlCommand(script, conexao))
                {
                    cmd.Parameters.Add("@Nome", SqlDbType.NVarChar).Value = usuario.Nome;
                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = usuario.Email;
                    cmd.Parameters.Add("@Senha", SqlDbType.NVarChar).Value = usuario.Senha;
                    cmd.Parameters.Add("@Idade", SqlDbType.NVarChar).Value = usuario.Idade;

                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
            return usuario;
        }

        public Usuario Update(int id, Usuario usuarioAlterado)
        {
            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                string script = "UPDATE [BRGames].[dbo].[UsuarioGamer] SET Nome=@Nome, Email=@Email, Senha=@Senha, Idade=@Idade WHERE Id=@id";

                using (SqlCommand cmd = new SqlCommand(script, conexao))
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    cmd.Parameters.Add("@Nome", SqlDbType.NVarChar).Value = usuarioAlterado.Nome;
                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = usuarioAlterado.Email;
                    cmd.Parameters.Add("@Senha", SqlDbType.NVarChar).Value = usuarioAlterado.Senha;
                    cmd.Parameters.Add("@Idade", SqlDbType.NVarChar).Value = usuarioAlterado.Idade;

                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    usuarioAlterado.Id = id;
                }
            }
            return usuarioAlterado;
        }
    }
}
