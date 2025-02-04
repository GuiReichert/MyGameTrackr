using Microsoft.AspNetCore.Mvc;
using MyGameTrackr.Models.RAWG_API_Models;

namespace MyGameTrackr.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        public IHttpClientFactory _clientFactory { get; set; }

        private IConfiguration _config;

        public TestController(IHttpClientFactory clientfactory, IConfiguration config)
        {
            _clientFactory = clientfactory;
            _config = config;
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<GameDetailsModel>> GetGameDetail(int id)
        {
            var client = _clientFactory.CreateClient("GetGameDetails");


            var response = await client.GetFromJsonAsync<GameDetailsModel>(id.ToString()+ "?key="+_config.GetValue<string>("RAWG_API_KEY"));


            return Ok(response);


        }

    }
}
