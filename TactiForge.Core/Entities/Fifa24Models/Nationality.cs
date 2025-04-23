using System;
using System.Collections.Generic;

namespace TactiForge.Repository.Entities.Fifa24Models;

public partial class Nationality
{
    public int NationalityId { get; set; }

    public string? NationalityName { get; set; }

    public virtual ICollection<Coach> Coaches { get; set; } = new List<Coach>();

    public virtual ICollection<League> Leagues { get; set; } = new List<League>();

    public virtual ICollection<Player> Players { get; set; } = new List<Player>();
}
