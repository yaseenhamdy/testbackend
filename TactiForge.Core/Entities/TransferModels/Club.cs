using System;
using System.Collections.Generic;

namespace TactiForge.Repository.Entities.TransferModels;

public partial class Club
{
    public int ClubId { get; set; }

    public string? ClubCode { get; set; }

    public string? Name { get; set; }

    public string? DomesticCompetitionId { get; set; }

    public double? TotalMarketValue { get; set; }

    public int? SquadSize { get; set; }

    public double? AverageAge { get; set; }

    public int? ForeignersNumber { get; set; }

    public double? ForeignersPercentage { get; set; }

    public int? NationalTeamPlayers { get; set; }

    public string? StadiumName { get; set; }

    public int? StadiumSeats { get; set; }

    public string? NetTransferRecord { get; set; }

    public string? CoachName { get; set; }

    public int? LastSeason { get; set; }

    public string? Filename { get; set; }

    public string? Url { get; set; }

    public virtual ICollection<ClubGame> ClubGames { get; set; } = new List<ClubGame>();

    public virtual Competition? DomesticCompetition { get; set; }

    public virtual ICollection<Player> Players { get; set; } = new List<Player>();
}
