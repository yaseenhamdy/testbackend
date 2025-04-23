using System;
using System.Collections.Generic;

namespace TactiForge.Repository.Entities.TransferModels;

public partial class Competition
{
    public string CompetitionId { get; set; } = null!;

    public string? CompetitionCode { get; set; }

    public string? Name { get; set; }

    public string? SubType { get; set; }

    public string? Type { get; set; }

    public int? CountryId { get; set; }

    public string? CountryName { get; set; }

    public string? DomesticLeagueCode { get; set; }

    public string? Confederation { get; set; }

    public string? Url { get; set; }

    public string? IsMajorNationalLeague { get; set; }

    public virtual ICollection<Club> Clubs { get; set; } = new List<Club>();

    public virtual ICollection<Game> Games { get; set; } = new List<Game>();
}
