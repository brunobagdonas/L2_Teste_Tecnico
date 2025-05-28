namespace L2_Teste_Tecnico.Models
{
    public class DimensionModel
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }

        public int Volume => Height * Width * Length;

        public bool FitsIn(DimensionModel box)
        {
            return Height <= box.Height &&
                   Width <= box.Width &&
                   Length <= box.Length;
        }
    }
}
