using Dapper;
using L2_Teste_Tecnico.Data.Interfaces;
using L2_Teste_Tecnico.Models;
using System.Data;

namespace L2_Teste_Tecnico.Data.Repositories
{
    public class BoxRepository : IBoxRepository
    {
        public async Task<IEnumerable<BoxModel>> GetBoxes(IDbTransaction transaction)
        {
            var dbConnection = transaction.Connection;

            const string sql = @"SELECT 
                                     BoxId,
                                     Height,
                                     Width,
                                     Length
                                FROM Box";

            var dbBoxes = await dbConnection.QueryAsync<dynamic>(sql, transaction: transaction);

            var boxes = dbBoxes.Select(row => new BoxModel
            {
                BoxId = row.BoxId,
                Dimensions = new DimensionModel
                {
                    Height = (int)row.Height,
                    Width = (int)row.Width,
                    Length = (int)row.Length
                }
            });

            return boxes;
        }
    }
}
