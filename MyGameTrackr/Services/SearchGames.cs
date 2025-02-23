﻿using AutoMapper;
using MyGameTrackr.DTO_s;
using MyGameTrackr.Models;
using MyGameTrackr.Models.RAWG_API_Models;

namespace MyGameTrackr.Services
{
    public class SearchGames : ISearchGames
    {
        IHttpClientFactory _clientfactory;
        IConfiguration _config;
        IMapper _mapper;

        public SearchGames(IHttpClientFactory clientFactory, IConfiguration config, IMapper mapper)
        {
            _clientfactory = clientFactory;
            _config = config;
            _mapper = mapper;
        }



        public async Task<ServiceResponse<GetAPIGameDetailDTO>> FindGameById(int id)
        {
            var response = new ServiceResponse<GetAPIGameDetailDTO>();

            try
            {
                var client = _clientfactory.CreateClient("GetGameDetails");
                var gamedetail = await client.GetFromJsonAsync<APIGameDetailsModel>(id + Environment.GetEnvironmentVariable("RAWG_API_KEY"));


                response.Data = _mapper.Map<GetAPIGameDetailDTO>(gamedetail);
            }
            catch (Exception)
            {
                response.Success = false;
                response.Message = $"Could not find a game in the API with the following Id: {id}";
            }
            return response;


        }

        public async Task<ServiceResponse<GetAPIGameDetailDTO>> FindGameByName(string gameName)
        {
            var response = new ServiceResponse<GetAPIGameDetailDTO>();

            try
            {
                var client = _clientfactory.CreateClient("GetGameDetails");

                var formattedName = gameName.Replace(" ", "-").ToLower();                          //transforma a barra de espaço inserida pelo usuário por uma barra.

                var gamedetail = await client.GetFromJsonAsync<APIGameDetailsModel>(formattedName + Environment.GetEnvironmentVariable("RAWG_API_KEY"));



                response.Data = _mapper.Map<GetAPIGameDetailDTO>(gamedetail);
            }
            catch (Exception)
            {
                response.Success = false;
                response.Message = $"Could not find a game in the API with the following name: '{gameName}'. Try checking the spelling or text formatting"; 
            }
            return response;


        }
    }
}
