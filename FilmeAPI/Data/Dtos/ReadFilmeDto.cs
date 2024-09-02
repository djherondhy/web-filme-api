using FilmeAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace FilmeAPI.Data.Dtos; 
public class ReadFilmeDto {
  
    public string Titulo { get; set; }
    public string Genero { get; set; }
    public int Duracao { get; set; }

    public DateTime QueryTime { get; set; } = DateTime.Now;

    public virtual ICollection<ReadSessaoDto> Sessoes { get; set; }
}
