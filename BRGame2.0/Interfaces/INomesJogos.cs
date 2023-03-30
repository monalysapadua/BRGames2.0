using BRGame2._0.Models;
using System.Collections.Generic;

namespace BRGame2._0.Interfaces
{
    public interface INomesJogos
    {
        ICollection<NomeJogo> GetAll();
        NomeJogo GetById(int id);
        NomeJogo Insert(NomeJogo jogo);
        NomeJogo Update(int idJogo, NomeJogo jogoAlterado);
        bool Delete(int idJogo);
    }
}
