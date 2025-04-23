using System;
using System.Collections.Generic;

namespace TactiForge.Repository.Entities.Fifa24Models;

public partial class SkillCharacteristic
{
    public int PlayerId { get; set; }

    public int FifaVersion { get; set; }

    public int? SkillDribbling { get; set; }

    public int? SkillCurve { get; set; }

    public int? SkillFkAccuracy { get; set; }

    public int? SkillLongPassing { get; set; }

    public int? SkillBallControl { get; set; }

    public virtual Player Player { get; set; } = null!;
}
