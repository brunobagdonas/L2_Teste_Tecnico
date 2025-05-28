using System.Text.Json.Serialization;

namespace L2_Teste_Tecnico.DTOs
{
    public class BoxDTO
    {
        public string? BoxId { get; set; }
        public List<string> Products { get; set; } = new();
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Note { get; set; }
    }
}
