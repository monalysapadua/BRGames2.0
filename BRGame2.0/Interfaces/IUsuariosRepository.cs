using BRGame2._0.Models;
using System.Collections.Generic;

namespace BRGame2._0.Interfaces
{
    public interface IUsuariosRepository
    {
        //CRUD
        //READ
        ICollection<Usuario> GetAll();
        Usuario GetById(int id);
        //CREATE
        Usuario Insert(Usuario usuario);
        //UPDATE
        Usuario Update(int id, Usuario usuario);
        //DELETE
        bool Delete(int id);
    }
}
