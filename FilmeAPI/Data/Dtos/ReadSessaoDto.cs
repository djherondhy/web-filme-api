using System.ComponentModel.DataAnnotations;

namespace FilmeAPI.Data.Dtos; 
public class ReadSessaoDto {

    [Required]
    public int Id { get; set; }
}
