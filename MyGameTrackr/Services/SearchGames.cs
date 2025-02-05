using AutoMapper;
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



        public async Task<ServiceResponse<GetGameDetailDTO>> FindGameById(int id)
        {
            var response = new ServiceResponse<GetGameDetailDTO>();

            try
            {
                var client = _clientfactory.CreateClient("GetGameDetails");
                var gamedetail = await client.GetFromJsonAsync<GameDetailsModel>(id+_config.GetValue<string>("RAWG_API_KEY"));

                response.Data = _mapper.Map<GetGameDetailDTO>(gamedetail);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;


        }

        public async Task<ServiceResponse<GetGameDetailDTO>> FindGameByName(string gameName)
        {
            var response = new ServiceResponse<GetGameDetailDTO>();

            try
            {
                var client = _clientfactory.CreateClient("GetGameDetails");

                var formattedName = gameName.Replace(" ", "-").ToLower();                          //transforma a barra de espaço inserida pelo usuário por uma barra.

                var gamedetail = await client.GetFromJsonAsync<GameDetailsModel>(formattedName + _config.GetValue<string>("RAWG_API_KEY"));
                response.Data = _mapper.Map<GetGameDetailDTO>(gamedetail);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;


        }
    }
}
