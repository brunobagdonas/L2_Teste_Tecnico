namespace L2_Teste_Tecnico.DTOs
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public List<BoxDTO> Boxes { get; set; } = new();
    }
}
