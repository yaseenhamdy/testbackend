using System;
using System.Collections.Generic;

namespace TactiForge.Repository.Entities.Fifa24Models;

public partial class League
{
    public int LeagueId { get; set; }

    public int? NationalityId { get; set; }

    public string? LeagueName { get; set; }

    public int? LeagueLevel { get; set; }

    public virtual Nationality? Nationality { get; set; }

    public virtual ICollection<Player> Players { get; set; } = new List<Player>();

    public virtual ICollection<Team> Teams { get; set; } = new List<Team>();
}
