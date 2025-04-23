using System;
using System.Collections.Generic;

namespace TactiForge.Repository.Entities.TransferModels;

public partial class Game
{
    public int GameId { get; set; }

    public string? CompetitionId { get; set; }

    public int? Season { get; set; }

    public string? Round { get; set; }

    public string? Date { get; set; }

    public int? HomeClubId { get; set; }

    public int? AwayClubId { get; set; }

    public int? HomeClubGoals { get; set; }

    public int? AwayClubGoals { get; set; }

    public int? HomeClubPosition { get; set; }

    public int? AwayClubPosition { get; set; }

    public string? HomeClubManagerName { get; set; }

    public string? AwayClubManagerName { get; set; }

    public string? Stadium { get; set; }

    public int? Attendance { get; set; }

    public string? Referee { get; set; }

    public string? Url { get; set; }

    public string? HomeClubFormation { get; set; }

    public string? AwayClubFormation { get; set; }

    public string? HomeClubName { get; set; }

    public string? AwayClubName { get; set; }

    public string? Aggregate { get; set; }

    public string? CompetitionType { get; set; }

    public virtual ICollection<ClubGame> ClubGames { get; set; } = new List<ClubGame>();

    public virtual Competition? Competition { get; set; }
}
