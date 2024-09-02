using System.ComponentModel.DataAnnotations;

namespace FilmeAPI.Models; 
public class Sessao {
    [Key]
    [Required]
    public int Id { get; set; }
}
