﻿using Microsoft.AspNetCore.Mvc;
using MyGameTrackr.DTO_s;
using MyGameTrackr.Models;
using MyGameTrackr.Services;

namespace MyGameTrackr.Controllers
{

    [ApiController]
    [Route("search-games")]
    public class SearchGamesController : ControllerBase
    {
        private ISearchGames _searchgames;

        public SearchGamesController(ISearchGames searchGames)
        {
            _searchgames = searchGames;
        }

        [HttpGet("details/id/{id}")]
        public async Task<ActionResult<ServiceResponse<GetAPIGameDetailDTO>>> GetDetailsById(int id)
        {
            var response = await _searchgames.FindGameById(id);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("details/name/{game_name}")]
        public async Task<ActionResult<ServiceResponse<GetAPIGameDetailDTO>>> GetDetailsByName(string game_name)
        {
            var response = await _searchgames.FindGameByName(game_name);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);

        }


    }
}
