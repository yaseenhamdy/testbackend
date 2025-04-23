using System;
using System.Collections.Generic;

namespace TactiForge.Repository.Entities.Fifa24Models;

public partial class PowerCharacteristic
{
    public int PlayerId { get; set; }

    public int FifaVersion { get; set; }

    public int? PowerShotPower { get; set; }

    public int? PowerJumping { get; set; }

    public int? PowerStamina { get; set; }

    public int? PowerStrength { get; set; }

    public int? PowerLongShots { get; set; }

    public virtual Player Player { get; set; } = null!;
}
