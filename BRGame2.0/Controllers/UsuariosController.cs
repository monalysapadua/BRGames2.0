using BRGame2._0.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using BRGame2._0.Repositories;

namespace BRGame2._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {

        private UsuarioRepository repositorio = new UsuarioRepository();
        
        /// <summary>
        /// Cadastra Usuários na Aplicação
        /// </summary>
        /// <param name="usuario">Nomes dos usuários</param>
        /// <returns>usuário cadastrado na aplicação</returns>
        [HttpPost]
        public IActionResult Cadastrar(Models.Usuario usuario)
        {
            try
            {

                repositorio.Insert(usuario);
                return Ok(usuario);
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
        /// Lista todos os usuários da aplicação
        /// </summary>
        /// <returns>Lista de usuários</returns>
        [HttpGet]
        public IActionResult Listar()
        {
           try
            {

                var listaUsuario = repositorio.GetAll();
                return Ok(listaUsuario);
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
        /// Altera os dados de um usuário
        /// </summary>
        /// <param name="id">Id do Usuário</param>
        /// <param name="usuarioAlterado">Todas as informações do usuário</param>
        /// <returns>Usuário alterado</returns>
        [HttpPut("/{id}")]
        public IActionResult Alterar(int id, Models.Usuario usuario)
        {
            try
            {

                var buscarUsuario = repositorio.GetById(id);
                if (buscarUsuario == null)
                {
                    return NotFound();

                }

                var usuarioAlterado = repositorio.Update(id, usuario);
                return Ok(usuarioAlterado);
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
        /// Exclui um usuário da aplicação
        /// </summary>
        /// <param name="id">Dados do usuário</param>
        /// <returns>Mensagem de exclusão</returns>
        [HttpDelete("/{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                var buscarUsuario = repositorio.GetById(id);
                if (buscarUsuario == null)
                {
                    return NotFound();

                }
                repositorio.Delete(id);

                return Ok(new
                {
                    msg = "Usuário Exluído com sucesso!"
                });
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



    }
}
