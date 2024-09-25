namespace CFM.Domain.Entities
{
    public class ConsolidadoDTO
    {
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public decimal ValorDespesas { get; set; } = 0;
        public decimal ValorReceitas { get; set; } = 0;
        public decimal ValorTotal { get; set; } = 0;
    }
}
