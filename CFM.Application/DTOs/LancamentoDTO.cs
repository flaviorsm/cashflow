using System.ComponentModel.DataAnnotations;

namespace CFM.Application.DTOs
{
    public class LancamentoDTO
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "A Data é obrigatória")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "O Valor é obrigatório")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O Valor deve ser maior que zero")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "A Descrição é obrigatória")]
        [StringLength(255, ErrorMessage = "A Descrição não pode ter mais que 255 caracteres")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "A Categoria é obrigatória")]
        public int Categoria { get; set; }
    }
}
