using AutoMapper;
using CondominiumNetwork.DomainModel.Entities;
using CondominiumNetwork.DomainModel.ValueObjects;
using CondominiumNetwork.Infrastructure.DataAcess.Context.Model;
using CondominiumNetwork.WebApp.Areas.Identity.Pages.Account;
using CondominiumNetwork.WebApp.ViewModels;
using Profile = AutoMapper.Profile;

namespace CondominiumNetwork.WebApp.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Ocurrence, OcurrenceViewModel>().ReverseMap();
            CreateMap<DomainModel.Entities.Profile, ProfileViewModel>().ReverseMap();
            CreateMap<Answer, AnswerViewModel>().ReverseMap();
            CreateMap<Warning, WarningViewModel>().ReverseMap();
            CreateMap<Category, DbCategory>().ReverseMap();
            CreateMap<Category, CategoryViewModel>().ReverseMap();

            //CreateMap<Category, OcurrenceViewModel>()
            //    .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Description));

        }
    }
}
