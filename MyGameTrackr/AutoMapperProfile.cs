﻿using AutoMapper;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
using MyGameTrackr.DTO_s;
using MyGameTrackr.DTO_s.LibraryDTO_s;
using MyGameTrackr.Models.RAWG_API_Models;
using MyGameTrackr.Models.User;

namespace MyGameTrackr
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<GameDetailsModel, GetAPIGameDetailDTO>();
            CreateMap<LibraryGames_Model,GetLibraryGameDetailDTO>();
            CreateMap<AddLibraryGameDTO, LibraryGames_Model>();
        }
    }
}
