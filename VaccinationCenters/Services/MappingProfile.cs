using AutoMapper;
using VaccinationCenters.DTOs;
using VaccinationCenters.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VaccinationCenters.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<VaccinationCenter, VaccinationCenterDto>().ReverseMap();
            CreateMap<Vaccine, VaccineDto>().ReverseMap();
        }
    }
}
