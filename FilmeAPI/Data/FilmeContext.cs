using FilmeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmeAPI.Data; 
public class FilmeContext: DbContext {
    public FilmeContext(DbContextOptions<FilmeContext> opts) : base(opts) { 
    
    }

    public DbSet<Filme> filmes { get; set; }  
    public DbSet<Cinema> cinemas { get; set; }
    public DbSet<Endereco> enderecos { get; set; }
    public DbSet<Sessao> sessoes { get; set; }
}
