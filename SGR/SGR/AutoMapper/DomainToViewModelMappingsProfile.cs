
using AutoMapper;
using SGR.Domain.Entities;
using SGR.Models.Restaurant;

namespace SGR.AutoMapper
{
    public class DomainToViewModelMappingsProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected  void Configure()
        {
            CreateMap<Restaurant, RestaurantListViewModel>();
        }
    }
}