using System;
using System.Collections.Generic;

namespace TactiForge.Repository.Entities.Fifa24Models;

public partial class Gkcharacteristic
{
    public int PlayerId { get; set; }

    public int FifaVersion { get; set; }

    public int? GoalkeepingDiving { get; set; }

    public int? GoalkeepingHandling { get; set; }

    public int? GoalkeepingKicking { get; set; }

    public int? GoalkeepingPositioning { get; set; }

    public int? GoalkeepingReflexes { get; set; }

    public int? GoalkeepingSpeed { get; set; }

    public virtual Player Player { get; set; } = null!;
}
