using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TactiForge.API.DTO;
using TactiForge.API.DTO.PlayersDTO;
using TactiForge.API.DTO.Team.CheckId;
using TactiForge.Core.Interfaces;
using TactiForge.Repository.Repositories;

namespace TactiForge.API.Controllers
{

    public class PlayersController : ApiBaseController
    {
        private readonly IUnitOfWork _unitOfWork;

        public PlayersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet("/players")]
        [ProducesResponseType(typeof(PlayersResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PlayersResponseDTO>> GetPlayerInSpecificTeam([FromQuery] int teamId)
        {
            if (teamId <= 0)
            {
                return BadRequest(new ApiResponse(400, "Invalid team ID. Team ID must be greater than 0"));
            }

            var players = await _unitOfWork.PlayersRepository.GetPlayersInTeamAsync(teamId);

            if (players == null || !players.Any())
            {
                return NotFound(new ApiResponse(404, $"No players found for team with ID {teamId}"));
            }

            var playerDTOs = players.Select(p => new GetPlayersReturnDTO()
            {
                PlayerName = p.LongName,
                PlayerPosision = p.PlayerPositions,
                PlayerImg = p.PlayerFaceUrl
            }).ToList();

            var response = new PlayersResponseDTO
            {
                Players = playerDTOs,
                Status = new StatusResponse
                {
                    StatusCode = 200,
                    StatusString = "Players retrieved successfully"
                }
            };

            return Ok(response);
        }



     

    }
}

