﻿using FilmeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmeAPI.Data; 
public class FilmeContext: DbContext {
    public FilmeContext(DbContextOptions<FilmeContext> opts) : base(opts) { 
    
    }

    public DbSet<Filme> filmes { get; set; }
}
