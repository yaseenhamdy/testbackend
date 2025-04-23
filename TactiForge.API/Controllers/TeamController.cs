//using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TactiForge.API.DTO.Team.CheckId;
//using TactiForge.API.Exceptions;
using TactiForge.Core.Interfaces;
using TactiForge.Repository.Entities;

namespace TactiForge.API.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TeamController : ApiBaseController
    {
        private readonly IUnitOfWork _unitOfWork;


        public TeamController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        [HttpPost("check-team-id")]
        public async Task<IActionResult> CheckTeamId([FromBody] CheckTeamIdDto model)
        {



            var teamExists = await _unitOfWork.TeamsRepository.GetByIdAsync(model.TeamId);
            if (teamExists == null)
            {
                return NotFound(new ApiResponse(404, "There is no Team with this ID"));
            }

            string message = $"Team ID is valid. The team name is '{teamExists.TeamName}'. Please proceed with inserting a valid email.";


            //return Ok(new ApiResponse(200, "This ID is found in the database, please move to the next step and insert a valid email."));
            return Ok(new ApiResponse(200, message));
        }




    }





}

