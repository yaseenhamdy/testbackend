using System;
using System.Collections.Generic;

namespace TactiForge.Repository.Entities.Fifa24Models;

public partial class MovementCharacteristic
{
    public int PlayerId { get; set; }

    public int FifaVersion { get; set; }

    public int? SkillMoves { get; set; }

    public int? MovementAcceleration { get; set; }

    public int? MovementSprintSpeed { get; set; }

    public int? MovementAgility { get; set; }

    public int? MovementReactions { get; set; }

    public int? MovementBalance { get; set; }

    public virtual Player Player { get; set; } = null!;
}
