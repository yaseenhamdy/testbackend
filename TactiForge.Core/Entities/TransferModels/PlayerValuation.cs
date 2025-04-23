using System;
using System.Collections.Generic;

namespace TactiForge.Repository.Entities.TransferModels;

public partial class PlayerValuation
{
    public int? PlayerId { get; set; }

    public string? Date { get; set; }

    public long? MarketValueInEur { get; set; }

    public int? CurrentClubId { get; set; }

    public string? PlayerClubDomesticCompetitionId { get; set; }

    public virtual Player? Player { get; set; }
}
