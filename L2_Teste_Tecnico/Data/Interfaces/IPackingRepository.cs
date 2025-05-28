using System.Data;

namespace L2_Teste_Tecnico.Data.Interfaces
{
    public interface IPackingRepository
    {
        Task<int> InsertOrder(IDbTransaction transaction);
        Task InsertOrderItem(int orderId, string productId, string? boxId, IDbTransaction transaction);
    }
}
