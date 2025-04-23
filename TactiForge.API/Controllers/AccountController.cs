using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics.X86;
using TactiForge.API.DTO;
using TactiForge.API.DTO.Team.CheckId;
using TactiForge.API.Helper;
using TactiForge.API.Setting;
using TactiForge.Core.Identity;
using TactiForge.Core.Interfaces;
using TactiForge.Core.Services;
using TactiForge.Repository.Data.Context;
using TactiForge.Repository.Entities;
using TactiForge.Services;
using TactiForge.Services.Services;

namespace TactiForge.API.Controllers
{

    public class AccountController : ApiBaseController
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMailSettings _mailSettings;
        private readonly ITokenService tokenService;
        private readonly SignInManager<AppUser> signInManager;
        private readonly UsersDbContext usersDbContext;

        public AccountController(IUnitOfWork unitOfWork, UserManager<AppUser> userManager
            , IMailSettings mailSettings, ITokenService tokenService
            , SignInManager<AppUser> signInManager)
        {
            _unitOfWork = unitOfWork;
            this.unitOfWork = unitOfWork;
            _userManager = userManager;
            _mailSettings = mailSettings;
            this.tokenService = tokenService;
            this.signInManager = signInManager;
        }


        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]  // waht type should return if status code is 200
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status401Unauthorized)]
        [HttpPost("register-team-user")]
        public async Task<ActionResult<RigesterDTO>> RegisterTeamUser(RegisterTeamUserDto model)
        {

            var team = await _unitOfWork.TeamsRepository.GetByIdAsync(model.TeamId);
            if (team == null)
            {
                return NotFound(new ApiResponse(404, "No team found with this ID"));
            }

            // ✅ Step 2: Generate a system email
            string systemGeneratedEmail = $"{team.TeamName.Replace(" ", "").ToLower()}@tactiforge.com";

            // ✅ Step 3: Generate a random password
            string generatedPassword = PasswordGenerator.GenerateRandomPassword(10);



            // Step To Check If this team registed befor or not 

            var existingUser = await _userManager.FindByEmailAsync(systemGeneratedEmail);
            if (existingUser != null)
                return BadRequest(new ApiResponse(400, "This email is already in use.Please try again."));




            // ✅ Step 4: Insert user into the Identity database
            var user = new AppUser
            {
                UserName = team.TeamName.Replace(" ", ""),
                Email = systemGeneratedEmail,
                DisplayName = team.TeamName
            };



            var result = await _userManager.CreateAsync(user, generatedPassword);

            if (!result.Succeeded)
            {
                return BadRequest(new ApiResponse(400, "Failed to create user"));
            }


            var email = new Email
            {

                To = model.Email,
                Subject = "Team Registration Successful",
                Body = $"Your email is {systemGeneratedEmail}  and your name is {team.TeamName}  and your password is {generatedPassword}"
            };

            _mailSettings.SendEmail(email);


            return Ok(new RigesterDTO()
            {
                Email = systemGeneratedEmail,
                Status = new StatusResponse
                {
                    StatusCode = 200,
                    StatusString = "Team registered successfully , see your email"
                }
            });
        }








        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status401Unauthorized)]
        [HttpPost("Login")]
        public async Task<ActionResult<UserDTO>> Login(EnterLoginDTO loginUser)
        {
            // Fetch the user by email
            var user = await _userManager.FindByEmailAsync(loginUser.Email);
            if (user == null)
            {
                return Unauthorized(new ApiResponse(401));
            }

            // Check if the password is correct
            var result = await signInManager.CheckPasswordSignInAsync(user, loginUser.Password, lockoutOnFailure: false);
            if (!result.Succeeded)
            {
                return Unauthorized(new ApiResponse(401));
            }

            // Fetch Team by name from EnterLoginDTO
            var team = await _unitOfWork.TeamsRepository.GetTeamByNameAsync(loginUser.name);
            if (team == null)
            {
                return NotFound(new ApiResponse(404, "Team not found"));
            }

            // Fetch Coach by TeamId
            var coach = await _unitOfWork.CoachesRepository.GetCoachByTeamIdAsync(team.TeamId);
            if (coach == null)
            {
                return NotFound(new ApiResponse(404, "Coach not found"));
            }

            // Create the token with TeamId and CoachId
            var token = await tokenService.CreateTokenAsync(user, team.TeamId, coach.CoachId);

            // Return the response with the token
            return Ok(new UserDTO()
            {
                Email = loginUser.Email,
                DisplayName = loginUser.Email.Split('@')[0],  // Display name from email (before '@')
                Token = token,
                EmailConfirmed = user.EmailConfirmed,
                Status = new StatusResponse
                {
                    StatusCode = 200,
                    StatusString = "Login Successfully"
                }
            });
        }






        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status401Unauthorized)]
        [HttpPost("update-password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordInputDTO model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return Unauthorized(new ApiResponse(401, "User not found"));
            }

            var isPasswordCorrect = await _userManager.CheckPasswordAsync(user, model.OldPassword);
            if (!isPasswordCorrect)
            {
                return BadRequest(new ApiResponse(400, "Old password is incorrect"));
            }

            var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);

            if (!result.Succeeded)
            {
                return BadRequest(new ApiResponse(400, "Old password is incorrect"));
            }

            user.EmailConfirmed = true; // Review if this line is necessary
            await _userManager.UpdateAsync(user);

            return Ok(new StatusResponse { StatusCode = 200, StatusString = "Password updated successfully" });
        }




    }
}
