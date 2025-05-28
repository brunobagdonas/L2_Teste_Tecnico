namespace L2_Teste_Tecnico.Models
{
    public class ProductModel
    {
        public string ProductId { get; set; } = string.Empty;
        public DimensionModel Dimensions { get; set; } = new DimensionModel();
    }
}
