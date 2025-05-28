namespace L2_Teste_Tecnico.Models
{
    public class OrderModel
    {
        public int OrderId { get; set; }
        public List<ProductModel> Products { get; set; } = new();
    }
}
