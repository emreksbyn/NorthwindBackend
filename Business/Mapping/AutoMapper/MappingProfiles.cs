using AutoMapper;
using Entities.Concrete;
using Entities.Dtos;
using Entities.ViewModels;

namespace Business.Mapping.AutoMapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Supplier, CreateSupplierDto>().ReverseMap();
            CreateMap<Supplier, UpdateSupplierDto>().ReverseMap();
            CreateMap<Supplier, SupplierViewModel>().ReverseMap();
        }
    }
}