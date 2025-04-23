using System;
using System.Collections.Generic;

namespace TactiForge.Repository.Entities.TransferModels;

public partial class GameEvent
{
    public string GameEventId { get; set; } = null!;

    public string? Date { get; set; }

    public int? GameId { get; set; }

    public int? Minute { get; set; }

    public string? Type { get; set; }

    public int? ClubId { get; set; }

    public int? PlayerId { get; set; }

    public string? Description { get; set; }

    public int? PlayerInId { get; set; }

    public int? PlayerAssistId { get; set; }

    public virtual Player? Player { get; set; }
}
