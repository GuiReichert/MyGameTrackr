using AutoMapper;
using MyGameTrackr.DTO_s;
using MyGameTrackr.Models.RAWG_API_Models;

namespace MyGameTrackr
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<GameDetailsModel, GetGameDetailDTO>();
        }
    }
}
