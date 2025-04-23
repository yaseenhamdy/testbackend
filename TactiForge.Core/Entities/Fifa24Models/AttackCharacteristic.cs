using System;
using System.Collections.Generic;

namespace TactiForge.Repository.Entities.Fifa24Models;

public partial class AttackCharacteristic
{
    public int PlayerId { get; set; }

    public int FifaVersion { get; set; }

    public int? AttackingCrossing { get; set; }

    public int? AttackingFinishing { get; set; }

    public int? AttackingHeadingAccuracy { get; set; }

    public int? AttackingShortPassing { get; set; }

    public int? AttackingVolleys { get; set; }

    public virtual Player Player { get; set; } = null!;
}
