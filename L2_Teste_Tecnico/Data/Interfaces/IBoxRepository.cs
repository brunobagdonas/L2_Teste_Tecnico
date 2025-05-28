using L2_Teste_Tecnico.Models;
using System.Data;

namespace L2_Teste_Tecnico.Data.Interfaces
{
    public interface IBoxRepository
    {
        Task<IEnumerable<BoxModel>> GetBoxes(IDbTransaction transaction);
    }
}
