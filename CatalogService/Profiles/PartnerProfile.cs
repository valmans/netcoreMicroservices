using AutoMapper;
using CatalogService.Models;
using CatalogService.Dtos;

namespace CatalogService.Profiles
{
    public class PartnerProfile :Profile
    {
        public PartnerProfile()
        {
            CreateMap<Partner, PartnerDto>();
            CreateMap<PartnerResource, Partner>();

        }
    }
}
