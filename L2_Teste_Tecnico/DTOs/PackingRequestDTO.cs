using L2_Teste_Tecnico.Models;

namespace L2_Teste_Tecnico.DTOs
{
    public class PackingRequestDTO
    {
        public List<OrderModel> Orders { get; set; } = new();
    }
}
