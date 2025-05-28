using L2_Teste_Tecnico.DTOs;

namespace L2_Teste_Tecnico.Services.Interfaces
{
    public interface IPackingService
    {
        Task<PackingResponseDTO> PackOrders(PackingRequestDTO request);
    }
}
