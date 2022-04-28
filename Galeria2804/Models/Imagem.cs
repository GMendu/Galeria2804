using System.ComponentModel.DataAnnotations;

namespace Galeria2804.Models
{
    public class Imagem
    {
        [Key]
        public int imagemId { get; set; }
        [Required]
        public string imagemName { get; set; }
        [Required]
        public int imagemTam { get; set; }
        [Required]
        public string imagemType { get; set; }
        public string imagemDescricao { get; set; }
    }
}
