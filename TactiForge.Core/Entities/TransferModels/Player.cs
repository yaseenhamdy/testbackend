using System;
using System.Collections.Generic;

namespace TactiForge.Repository.Entities.TransferModels;

public partial class Player
{
    public int PlayerId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Name { get; set; }

    public int? LastSeason { get; set; }

    public int? CurrentClubId { get; set; }

    public string? PlayerCode { get; set; }

    public string? CountryOfBirth { get; set; }

    public string? CityOfBirth { get; set; }

    public string? CountryOfCitizenship { get; set; }

    public string? DateOfBirth { get; set; }

    public string? SubPosition { get; set; }

    public string? Position { get; set; }

    public string? Foot { get; set; }

    public double? HeightInCm { get; set; }

    public string? ContractExpirationDate { get; set; }

    public string? AgentName { get; set; }

    public string? ImageUrl { get; set; }

    public string? Url { get; set; }

    public string? CurrentClubDomesticCompetitionId { get; set; }

    public string? CurrentClubName { get; set; }

    public double? MarketValueInEur { get; set; }

    public double? HighestMarketValueInEur { get; set; }

    public virtual Club? CurrentClub { get; set; }

    public virtual ICollection<GameEvent> GameEvents { get; set; } = new List<GameEvent>();
}
