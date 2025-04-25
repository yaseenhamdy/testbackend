using System;
using System.Collections.Generic;

namespace TactiForge.Repository.Entities.Fifa24Models;

public partial class Player
{
    public int PlayerId { get; set; }
    
    public int? FifaVersion { get; set; }

    public string? LongName { get; set; }

    public string? PlayerPositions { get; set; }

    public DateOnly? Dob { get; set; }

    public int? ClubJerseyNumber { get; set; }

    public int? HeightCm { get; set; }

    public int? WeightKg { get; set; }

    public string? PreferredFoot { get; set; }

    public string? PlayerTags { get; set; }

    public string? PlayerFaceUrl { get; set; }

    public int? CoachId { get; set; }

    public int? LeagueId { get; set; }

    public int? ClubTeamId { get; set; }

    public int? NationalityId { get; set; }

    public virtual ICollection<AttackCharacteristic> AttackCharacteristics { get; set; } = new List<AttackCharacteristic>();

    public virtual Team? ClubTeam { get; set; }

    public virtual Coach? Coach { get; set; }

    public virtual ICollection<DefendingCharacteristic> DefendingCharacteristics { get; set; } = new List<DefendingCharacteristic>();

    public virtual ICollection<Gkcharacteristic> Gkcharacteristics { get; set; } = new List<Gkcharacteristic>();

    public virtual League? League { get; set; }

    public virtual ICollection<MainCharacteristic> MainCharacteristics { get; set; } = new List<MainCharacteristic>();

    public virtual ICollection<MentalityCharacteristic> MentalityCharacteristics { get; set; } = new List<MentalityCharacteristic>();

    public virtual ICollection<MovementCharacteristic> MovementCharacteristics { get; set; } = new List<MovementCharacteristic>();

    public virtual Nationality? Nationality { get; set; }

    public virtual ICollection<PlayerHistory> PlayerHistories { get; set; } = new List<PlayerHistory>();

    public virtual ICollection<PlayerPosition> PlayerPositionsNavigation { get; set; } = new List<PlayerPosition>();

    public virtual ICollection<PowerCharacteristic> PowerCharacteristics { get; set; } = new List<PowerCharacteristic>();

    public virtual ICollection<SkillCharacteristic> SkillCharacteristics { get; set; } = new List<SkillCharacteristic>();
}
