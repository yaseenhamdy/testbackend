using System;
using System.Collections.Generic;

namespace TactiForge.Repository.Entities.TransferModels;

public partial class GameLineup
{
    public string GameLineupsId { get; set; } = null!;

    public string? Date { get; set; }

    public int? GameId { get; set; }

    public int? PlayerId { get; set; }

    public int? ClubId { get; set; }

    public string? PlayerName { get; set; }

    public string? Type { get; set; }

    public string? Position { get; set; }

    public string? Number { get; set; }

    public int? TeamCaptain { get; set; }
}
