﻿using AutoMapper;
using FilmeAPI.Data.Dtos;
using FilmeAPI.Models;

namespace FilmeAPI.Profiles; 
public class CinemaProfile: Profile {
    public CinemaProfile() {

        CreateMap<CreateCinemaDto, Cinema>();
        CreateMap<UpdateCinemaDto, Cinema>();
        CreateMap<Cinema, ReadCinemaDto>()
            .ForMember(cinemaDto => cinemaDto.ReadEnderecoDto, opt => opt.MapFrom(cinema => cinema.Endereco))
            .ForMember(cinemaDto => cinemaDto.Sessoes, opt => opt.MapFrom(cinema => cinema.Sessoes))
            ;
      
    }

}
