using System;
using System.Collections.Generic;

namespace TactiForge.Repository.Entities.TransferModels;

public partial class Transfer
{
    public int? PlayerId { get; set; }

    public string? TransferDate { get; set; }

    public string? TransferSeason { get; set; }

    public int? FromClubId { get; set; }

    public int? ToClubId { get; set; }

    public string? FromClubName { get; set; }

    public string? ToClubName { get; set; }

    public string? TransferFee { get; set; }

    public double? MarketValueInEur { get; set; }

    public string? PlayerName { get; set; }

    public virtual Player? Player { get; set; }
}
