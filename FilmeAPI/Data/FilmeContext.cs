﻿using FilmeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmeAPI.Data; 
public class FilmeContext: DbContext {
    public FilmeContext(DbContextOptions<FilmeContext> opts) : base(opts) { 
    
    }

    protected override void OnModelCreating(ModelBuilder builder) {

        builder.Entity<Sessao>().HasKey(sessao => new { sessao.FilmeId, sessao.CinemaId });
        
        builder.Entity<Sessao>().HasOne(sessao => sessao.Cinema).WithMany(cinema => cinema.Sessoes).HasForeignKey(sessao=> sessao.CinemaId);
        builder.Entity<Sessao>().HasOne(sessao => sessao.Cinema).WithMany(filme => filme.Sessoes).HasForeignKey(sessao => sessao.FilmeId);

        builder.Entity<Endereco>()
            .HasOne(endereco => endereco.Cinema)
            .WithOne(cinema => cinema.Endereco)
            .OnDelete(DeleteBehavior.Restrict);


    }

    public DbSet<Filme> filmes { get; set; }  
    public DbSet<Cinema> cinemas { get; set; }
    public DbSet<Endereco> enderecos { get; set; }
    public DbSet<Sessao> sessoes { get; set; }
}
