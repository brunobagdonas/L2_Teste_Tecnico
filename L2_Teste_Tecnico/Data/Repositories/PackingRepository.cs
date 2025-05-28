using Dapper;
using L2_Teste_Tecnico.Data.Interfaces;
using L2_Teste_Tecnico.Models;
using System.Data;

namespace L2_Teste_Tecnico.Data.Repositories
{
    public class PackingRepository : IPackingRepository
    {
        public async Task<int> InsertOrder(IDbTransaction transaction)
        {
            var dbConnection = transaction.Connection;

            const string sql = @"
                        INSERT INTO [Order] (OrderDate)
                        OUTPUT INSERTED.OrderId
                        VALUES (GETDATE());";

            var orderId = await dbConnection.ExecuteScalarAsync<int>(sql, transaction: transaction);
            
            return orderId;
        }

        public async Task InsertOrderItem(int orderId, string productId, string? boxId, IDbTransaction transaction)
        {
            var dbConnection = transaction.Connection;

            var parameters = new
            {
                orderId,
                productId,
                boxId
            };

            const string sql = @"INSERT INTO OrderItems 
                                (
                                    OrderId,
                                    ProductId,
                                    BoxId
                                )
                                VALUES
                                (
                                   @orderId,
                                   @productId,
                                   @boxId  
                                )";

            await dbConnection.ExecuteAsync(sql, parameters, transaction: transaction);
        }
    }
}
