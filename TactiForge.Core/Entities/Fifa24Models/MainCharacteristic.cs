using System;
using System.Collections.Generic;

namespace TactiForge.Repository.Entities.Fifa24Models;

public partial class MainCharacteristic
{
    public int PlayerId { get; set; }

    public int FifaVersion { get; set; }

    public int? Pace { get; set; }

    public int? Shooting { get; set; }

    public int? Passing { get; set; }

    public int? Dribbling { get; set; }

    public int? Defending { get; set; }

    public int? Physic { get; set; }

    public virtual Player Player { get; set; } = null!;
}
