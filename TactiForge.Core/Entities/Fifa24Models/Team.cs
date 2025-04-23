using System;
using System.Collections.Generic;

namespace TactiForge.Repository.Entities.Fifa24Models;

public partial class Team
{
    public int TeamId { get; set; }

    public string? TeamName { get; set; }

    public int? FifaVersion { get; set; }

    public int? LeagueId { get; set; }

    public int? NationalityId { get; set; }

    public int? Overall { get; set; }

    public int? Attack { get; set; }

    public int? Midfield { get; set; }

    public int? Defence { get; set; }

    public string? HomeStadium { get; set; }

    public int? RivalTeam { get; set; }

    public virtual ICollection<Coach> Coaches { get; set; } = new List<Coach>();

    public virtual League? League { get; set; }

    public virtual ICollection<Player> Players { get; set; } = new List<Player>();
}
