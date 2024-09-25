using CFM.Domain.Enums;

namespace CFM.Domain.Entities
{
    public class Lancamento
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public string? Descricao { get; set; }
        public CategoriaEnum Categoria { get; set; }
    }
}
