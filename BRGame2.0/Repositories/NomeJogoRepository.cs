using BRGame2._0.Interfaces;
using BRGame2._0.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Mvc;

namespace BRGame2._0.Repositories
{
    public class NomeJogoRepository : INomesJogos
    {
        readonly string connectionString = "Data Source=DESKTOP-LDCFMA3\\SQLEXPRESS;Integrated Security=true;Initial Catalog=BRGames";

        public bool Delete(int idJogo)
        {
            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                string script = "DELETE FROM [BRGames].[dbo].[NomeJogo] WHERE ID=@idJogo";

                using (SqlCommand cmd = new SqlCommand(script, conexao))
                {
                    cmd.Parameters.Add("@idJogo", SqlDbType.Int).Value = idJogo;

                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }

            return true;
        }

        public ICollection<NomeJogo> GetAll()
        {
            var jogo = new List<NomeJogo>();

            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                string consulta = "SELECT * FROM [BRGames].[dbo].[NomeJogo]";

                using (SqlCommand cmd = new SqlCommand(consulta, conexao))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            jogo.Add(new NomeJogo
                            {
                                ID = (int)reader[0],
                                Jogo = (string)reader[1]
                            });
                        }
                    }
                }
            }
            return jogo;
        }

        public NomeJogo GetById(int id)
        {
            var jogo = new NomeJogo();

            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                string consulta = "SELECT * FROM [BRGames].[dbo].[NomeJogo] WHERE ID=@idJogo";

                using (SqlCommand cmd = new SqlCommand(consulta, conexao))
                {
                    cmd.Parameters.Add("@idJogo", SqlDbType.Int).Value = id;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                                                        
                               jogo.ID = (int)reader[0];
                               jogo.Jogo = (string)reader[1];
                            
                        }
                    }
                }
            }
            return jogo;
        }

        public NomeJogo Insert(NomeJogo jogo)
        {
            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                string script = "INSERT INTO [BRGames].[dbo].[NomeJogo] (Jogo) VALUES (@Jogo)";

                using (SqlCommand cmd = new SqlCommand(script, conexao))
                {
                    cmd.Parameters.Add("@Jogo", SqlDbType.NVarChar).Value = jogo.Jogo;

                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }

            return jogo;
        }

        public NomeJogo Update(int idJogo, NomeJogo jogoAlterado)
        {
            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                string script = "UPDATE [BRGames].[dbo].[NomeJogo] set Jogo=@Jogo WHERE ID=@idJogo";

                using (SqlCommand cmd = new SqlCommand(script, conexao))
                {
                    cmd.Parameters.Add("@idJogo", SqlDbType.Int).Value = idJogo;
                    cmd.Parameters.Add("@Jogo", SqlDbType.NVarChar).Value = jogoAlterado.Jogo;

                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    jogoAlterado.ID = idJogo;
                }
            }
            return jogoAlterado;
        }
    }
}
