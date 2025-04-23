using System;
using System.Collections.Generic;

namespace TactiForge.Repository.Entities.Fifa24Models;

public partial class PlayerHistory
{
    public int PlayerId { get; set; }

    public int FifaVersion { get; set; }

    public string? ShortName { get; set; }

    public DateOnly? FifaUpdateDate { get; set; }

    public int? InternationalReputation { get; set; }

    public string? PlayerPositions { get; set; }

    public int? HeightCm { get; set; }

    public int? WeightKg { get; set; }

    public string? PreferredFoot { get; set; }

    public int? Overall { get; set; }

    public int? Potential { get; set; }

    public int? ValueEur { get; set; }

    public int? Age { get; set; }

    public int? WeakFoot { get; set; }

    public string? WorkRate { get; set; }

    public string? BodyType { get; set; }

    public string? PlayerTags { get; set; }

    public virtual Player Player { get; set; } = null!;
}
