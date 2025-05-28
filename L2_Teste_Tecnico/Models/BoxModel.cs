namespace L2_Teste_Tecnico.Models
{
    public class BoxModel
    {
        public string BoxId { get; set; } = string.Empty;
        public DimensionModel Dimensions { get; set; } = new DimensionModel();
    }
}
