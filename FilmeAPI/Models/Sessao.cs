﻿using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace FilmeAPI.Models; 
public class Sessao {
    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    public int FilmeId { get; set; }
    public virtual Filme Filme { get; set; }

    [Required]
    public int CinemaId { get; set; }
    public virtual Cinema Cinema { get; set; }

}
