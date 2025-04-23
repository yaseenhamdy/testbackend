using System;
using System.Collections.Generic;

namespace TactiForge.Repository.Entities.TransferModels;

public partial class Appearance
{
    public string AppearanceId { get; set; } = null!;

    public int? GameId { get; set; }

    public int? PlayerId { get; set; }

    public int? PlayerClubId { get; set; }

    public int? PlayerCurrentClubId { get; set; }

    public string? Date { get; set; }

    public string? PlayerName { get; set; }

    public string? CompetitionId { get; set; }

    public int? YellowCards { get; set; }

    public int? RedCards { get; set; }

    public int? Goals { get; set; }

    public int? Assists { get; set; }

    public int? MinutesPlayed { get; set; }
}
