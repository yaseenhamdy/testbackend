using System;
using System.Collections.Generic;

namespace TactiForge.Repository.Entities.Fifa24Models;

public partial class Coach
{
    public int CoachId { get; set; }

    public int? FifaVersion { get; set; }

    public int? TeamId { get; set; }

    public string? ShortName { get; set; }

    public string? LongName { get; set; }

    public DateOnly? Dob { get; set; }

    public int? NationalityId { get; set; }

    public string? NationalityName { get; set; }

    public string? FaceUrl { get; set; }

    public virtual Nationality? Nationality { get; set; }

    public virtual ICollection<Player> Players { get; set; } = new List<Player>();

    public virtual Team? Team { get; set; }
}
