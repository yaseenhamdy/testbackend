using System;
using System.Collections.Generic;

namespace TactiForge.Repository.Entities.TransferModels;

public partial class ClubGame
{
    public int ClubId { get; set; }

    public int GameId { get; set; }

    public int? OwnGoals { get; set; }

    public int? OwnPosition { get; set; }

    public string? OwnManagerName { get; set; }

    public int OpponentId { get; set; }

    public int? OpponentGoals { get; set; }

    public int? OpponentPosition { get; set; }

    public string? OpponentManagerName { get; set; }

    public string? Hosting { get; set; }

    public int? IsWin { get; set; }

    public virtual Club Club { get; set; } = null!;

    public virtual Game Game { get; set; } = null!;
}
