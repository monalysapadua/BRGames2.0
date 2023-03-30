using BRGame2._0.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using BRGame2._0.Repositories;

namespace BRGame2._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NomesJogosController : ControllerBase
    {
        private NomeJogoRepository repositorio = new NomeJogoRepository();

        /// <summary>
        /// Cadastra jogos na aplicação
        /// </summary>
        /// <param name="jogo">Nomes dos Jogos</param>
        /// <returns>Dados dos jogos cadatrados</returns>
        [HttpPost]
        public IActionResult Cadastrar(NomeJogo jogo)
        {
            try
            {
                repositorio.Insert(jogo);
                return Ok(jogo);


            }
            catch (System.Exception ex)
            {

                return StatusCode(500, new
                {
                    msg = "Falha na conexão",
                    erro = ex.Message,
                });
            }
        }
        /// <summary>
        /// Lista Todos os Jogos Cadastrados
        /// </summary>
        /// <returns>Lista de Jogos</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                var jogo = repositorio.GetAll();

                return Ok(jogo);
            }
            catch (System.Exception ex)
            {

                return StatusCode(500, new
                {
                    msg = "Falha na conexão",
                    erro = ex.Message,
                });
            }


        }

        /// <summary>
        /// Altera os dados de um jogo
        /// </summary>
        /// <param name="idJogo">ID do jogo</param>
        /// <param name="jogo">Todas as informações do jogo</param>
        /// <returns>Jogo alterado</returns>
        [HttpPut("Alterar/{idJogo}")]
        public IActionResult AlterarNomeJogo(int idJogo, NomeJogo jogoAlterado)
        {
            try
            {
                var buscarJogo = repositorio.GetById(idJogo);
                if (buscarJogo == null)
                {
                    return NotFound();
                }

                var jogoUsuario = repositorio.Update(idJogo, jogoAlterado);
                return Ok(jogoAlterado);

            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new
                {
                    msg = "falha de conexão",
                    erro = ex.Message,
                });
            }
        }

        /// <summary>
        /// Exclui um usuário da aplicação
        /// </summary>
        /// <param name="idJogo">Id do Usuário</param>
        /// <returns>Mensagem de Exclusão</returns>
        [HttpDelete("Deletar/{idJogo}")]
        public IActionResult Deletar(int idJogo) 
        {
            try
            {
                var buscarJogo = repositorio.GetById(idJogo);
                if (buscarJogo == null)
                {
                    return NotFound();

                }
                repositorio.Delete(idJogo);

                return Ok(new
                {
                    msg = "Jogo Exluído com sucesso!"
                });

            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new
                {
                    msg = "falha de conexão",
                    erro = ex.Message,
                });
            }
        }
    }
}
