using System;
using System.Collections.Generic;

namespace TactiForge.Repository.Entities.Fifa24Models;

public partial class MentalityCharacteristic
{
    public int PlayerId { get; set; }

    public int FifaVersion { get; set; }

    public int? MentalityAggression { get; set; }

    public int? MentalityInterceptions { get; set; }

    public int? MentalityPositioning { get; set; }

    public int? MentalityVision { get; set; }

    public int? MentalityPenalties { get; set; }

    public int? MentalityComposure { get; set; }

    public virtual Player Player { get; set; } = null!;
}
