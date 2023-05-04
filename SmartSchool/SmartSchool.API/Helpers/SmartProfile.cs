using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SmartSchool.API.Dto;
using SmartSchool.API.Models;

namespace SmartSchool.API.Helpers
{
    public class SmartProfile : Profile
    {
        // Mapeando as Entidades com as DTO's
        public SmartProfile()
        {
            CreateMap<Aluno, AlunoDTO>()
                .ForMember(
                    dest => dest.Nome,
                    opt => opt.MapFrom(src => $"{src.Nome} {src.Sobrenome}")
                );
        }
    }
}