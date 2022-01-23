using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Investimento.API.Dtos;
using Investimento.Domain.Entities;

namespace Investimento.API.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class InvestimentoProfile : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public InvestimentoProfile()
        {
            CreateMap<Ativo, AtivoDto>();

            CreateMap<Cliente, ClienteDto>()
                .ForMember(
                    dest => dest.Nome,
                    opt => opt.MapFrom(src => $"{src.Nome} {src.SobreNome}")
                )
                .ForMember(
                    dest => dest.Idade,
                    opt => opt.MapFrom(src => src.DataDeNascimento.GetCurrentAge())
                )
                ;
                
            CreateMap<Cliente, ClienteRegistrarDto>().ReverseMap();
        }
    }
}