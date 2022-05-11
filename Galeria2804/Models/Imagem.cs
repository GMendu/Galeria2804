using System.ComponentModel.DataAnnotations;

namespace Galeria2804.Models
{
    public class Imagem
    {
        [Key]
        public int arquivoId { get; set; }
        [Required]
        public string arquivoName { get; set; }
        [Required]
        public int arquivoTam { get; set; }
        [Required]
        public string arquivoType { get; set; }
        public string arquivoDescricao { get; set; }
    }

}
