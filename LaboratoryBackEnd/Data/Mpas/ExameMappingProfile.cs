using AutoMapper;
using LaboratoryBackEnd.Data.DTO;
using LaboratoryBackEnd.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LaboratoryBackEnd.Data.Mpas
{
    public class ExameMappingProfile : Profile
    {
        public ExameMappingProfile()
        {
            CreateMap<Exame, ExameDTO>()
                .ForMember(dest => dest.Preco, opt => opt.Ignore()); // Ignore 'Preco' for now
        }
    }
}
