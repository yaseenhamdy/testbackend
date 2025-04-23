using System;
using System.Collections.Generic;

namespace TactiForge.Repository.Entities.Fifa24Models;

public partial class DefendingCharacteristic
{
    public int PlayerId { get; set; }

    public int FifaVersion { get; set; }

    public int? DefendingMarkingAwareness { get; set; }

    public int? DefendingStandingTackle { get; set; }

    public int? DefendingSlidingTackle { get; set; }

    public virtual Player Player { get; set; } = null!;
}
