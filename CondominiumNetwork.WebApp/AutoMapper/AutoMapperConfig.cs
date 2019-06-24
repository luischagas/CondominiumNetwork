using AutoMapper;
using CondominiumNetwork.DomainModel.Entities;
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

        }
    }
}
