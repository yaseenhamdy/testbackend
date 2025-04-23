namespace TactiForge.API.DTO.PlayersDTO
{
    public class PlayersResponseDTO
    {
        public List<GetPlayersReturnDTO> Players { get; set; } // List of players
        public StatusResponse Status { get; set; } // Status object
    }
}
