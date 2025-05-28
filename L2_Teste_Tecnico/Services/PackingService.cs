using L2_Teste_Tecnico.Data.Interfaces;
using L2_Teste_Tecnico.Data.Util;
using L2_Teste_Tecnico.DTOs;
using L2_Teste_Tecnico.Models;
using L2_Teste_Tecnico.Services.Interfaces;
using System.Data;

namespace L2_Teste_Tecnico.Services
{
    public class PackingService : IPackingService
    {
        private readonly SqlConnectionFactory _connectionFactory;
        private readonly IBoxRepository _boxRepository;
        private readonly IPackingRepository _packingRepository;

        public PackingService(SqlConnectionFactory connectionFactory, IBoxRepository boxRepository, IPackingRepository packingRepository)
        {
            _connectionFactory = connectionFactory;
            _boxRepository = boxRepository;
            _packingRepository = packingRepository;
        }

        public async Task<PackingResponseDTO> PackOrders(PackingRequestDTO request)
        {
            var response = new PackingResponseDTO();

            using (IDbConnection connection = _connectionFactory.CreateConnection())
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var availableBoxes = await _boxRepository.GetBoxes(transaction);

                        foreach (var order in request.Orders)
                        {
                            var orderResult = new OrderDTO { OrderId = order.OrderId };
                            var remainingProducts = new List<ProductModel>(order.Products);
                            var orderId = await _packingRepository.InsertOrder(transaction);

                            while (remainingProducts.Any())
                            {
                                var packed = false;

                                foreach (var box in availableBoxes.OrderBy(b => b.Dimensions.Volume))
                                {
                                    var productsToBox = new List<ProductModel>();
                                    int remainingVolume = box.Dimensions.Volume;

                                    foreach (var product in remainingProducts)
                                    {
                                        if (product.Dimensions.FitsIn(box.Dimensions) &&
                                            product.Dimensions.Volume <= remainingVolume)
                                        {
                                            productsToBox.Add(product);
                                            remainingVolume -= product.Dimensions.Volume;
                                        }
                                    }

                                    if (productsToBox.Any())
                                    {
                                        orderResult.Boxes.Add(new BoxDTO
                                        {
                                            BoxId = box.BoxId,
                                            Products = productsToBox.Select(p => p.ProductId).ToList()
                                        });

                                        foreach (var p in productsToBox)
                                        {
                                            await _packingRepository.InsertOrderItem(orderId, p.ProductId, box.BoxId, transaction);
                                            remainingProducts.Remove(p);
                                        }

                                        packed = true;
                                        break;
                                    }
                                }

                                if (!packed)
                                {
                                    foreach (var product in remainingProducts)
                                    {
                                        await _packingRepository.InsertOrderItem(orderId, product.ProductId, null, transaction);
                                        orderResult.Boxes.Add(new BoxDTO
                                        {
                                            BoxId = null,
                                            Products = new List<string> { product.ProductId },
                                            Note = "Product does not fit in any available box."
                                        });
                                    }
                                    remainingProducts.Clear();
                                }
                            }

                            response.Orders.Add(orderResult);
                        }

                        transaction.Commit();
                        return response;                    
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw;
                    }

                }
            }            
        }
    }
}
