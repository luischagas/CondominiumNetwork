﻿using AutoMapper;
using CondominiumNetwork.DomainModel.Entities;
using CondominiumNetwork.WebApp.ViewModels;
using Profile = AutoMapper.Profile;

namespace CondominiumNetwork.WebApp.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Ocurrence, OcurrenceViewModel>();
            CreateMap<Profile, ProfileViewModel>();
        }
    }
}
