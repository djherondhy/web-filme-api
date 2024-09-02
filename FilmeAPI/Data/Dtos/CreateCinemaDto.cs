﻿using System.ComponentModel.DataAnnotations;

namespace FilmeAPI.Data.Dtos; 
public class CreateCinemaDto {

    [Required(ErrorMessage = "O campo é obrigatório")]
    public string Nome { get; set; }

    public int EnderecoId { get; set; }
}
