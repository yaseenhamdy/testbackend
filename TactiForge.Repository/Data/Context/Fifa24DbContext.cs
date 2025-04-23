using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TactiForge.Repository.Entities.Fifa24Models;

namespace TactiForge.Repository.Data.Context;

public partial class Fifa24DbContext : DbContext
{
    public Fifa24DbContext()
    {
    }

    public Fifa24DbContext(DbContextOptions<Fifa24DbContext> options)
        : base(options)
    {
    }

      




    public virtual DbSet<AttackCharacteristic> AttackCharacteristics { get; set; }

    public virtual DbSet<Coach> Coaches { get; set; }

    public virtual DbSet<DefendingCharacteristic> DefendingCharacteristics { get; set; }

    public virtual DbSet<Gkcharacteristic> Gkcharacteristics { get; set; }

    public virtual DbSet<League> Leagues { get; set; }

    public virtual DbSet<MainCharacteristic> MainCharacteristics { get; set; }

    public virtual DbSet<MentalityCharacteristic> MentalityCharacteristics { get; set; }

    public virtual DbSet<MovementCharacteristic> MovementCharacteristics { get; set; }

    public virtual DbSet<Nationality> Nationalities { get; set; }

    public virtual DbSet<Player> Players { get; set; }

    public virtual DbSet<PlayerHistory> PlayerHistories { get; set; }

    public virtual DbSet<PlayerPosition> PlayerPositions { get; set; }

    public virtual DbSet<PowerCharacteristic> PowerCharacteristics { get; set; }

    public virtual DbSet<SkillCharacteristic> SkillCharacteristics { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=FIFA_24;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AttackCharacteristic>(entity =>
        {
            entity.HasKey(e => new { e.PlayerId, e.FifaVersion }).HasName("PK__AttackCh__54EC714D07FB36A1");

            entity.Property(e => e.PlayerId).HasColumnName("player_id");
            entity.Property(e => e.FifaVersion).HasColumnName("fifa_version");
            entity.Property(e => e.AttackingCrossing).HasColumnName("attacking_crossing");
            entity.Property(e => e.AttackingFinishing).HasColumnName("attacking_finishing");
            entity.Property(e => e.AttackingHeadingAccuracy).HasColumnName("attacking_heading_accuracy");
            entity.Property(e => e.AttackingShortPassing).HasColumnName("attacking_short_passing");
            entity.Property(e => e.AttackingVolleys).HasColumnName("attacking_volleys");

            entity.HasOne(d => d.Player).WithMany(p => p.AttackCharacteristics)
                .HasForeignKey(d => d.PlayerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AttackCha__playe__5DCAEF64");
        });

        modelBuilder.Entity<Coach>(entity =>
        {
            entity.HasKey(e => e.CoachId).HasName("PK__Coaches__2BEBE044FA229BCC");

            entity.Property(e => e.CoachId)
                .ValueGeneratedNever()
                .HasColumnName("coach_id");
            entity.Property(e => e.Dob).HasColumnName("dob");
            entity.Property(e => e.FaceUrl)
                .HasColumnType("text")
                .HasColumnName("face_url");
            entity.Property(e => e.FifaVersion).HasColumnName("fifa_version");
            entity.Property(e => e.LongName)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("long_name");
            entity.Property(e => e.NationalityId).HasColumnName("nationality_id");
            entity.Property(e => e.NationalityName)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("nationality_name");
            entity.Property(e => e.ShortName)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("short_name");
            entity.Property(e => e.TeamId).HasColumnName("team_id");

            entity.HasOne(d => d.Nationality).WithMany(p => p.Coaches)
                .HasForeignKey(d => d.NationalityId)
                .HasConstraintName("FK__Coaches__nationa__5165187F");

            entity.HasOne(d => d.Team).WithMany(p => p.Coaches)
                .HasForeignKey(d => d.TeamId)
                .HasConstraintName("FK__Coaches__team_id__52593CB8");
        });

        modelBuilder.Entity<DefendingCharacteristic>(entity =>
        {
            entity.HasKey(e => new { e.PlayerId, e.FifaVersion }).HasName("PK__Defendin__54EC714D6890185A");

            entity.Property(e => e.PlayerId).HasColumnName("player_id");
            entity.Property(e => e.FifaVersion).HasColumnName("fifa_version");
            entity.Property(e => e.DefendingMarkingAwareness).HasColumnName("defending_marking_awareness");
            entity.Property(e => e.DefendingSlidingTackle).HasColumnName("defending_sliding_tackle");
            entity.Property(e => e.DefendingStandingTackle).HasColumnName("defending_standing_tackle");

            entity.HasOne(d => d.Player).WithMany(p => p.DefendingCharacteristics)
                .HasForeignKey(d => d.PlayerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Defending__playe__6C190EBB");
        });

        modelBuilder.Entity<Gkcharacteristic>(entity =>
        {
            entity.HasKey(e => new { e.PlayerId, e.FifaVersion }).HasName("PK__GKCharac__54EC714DAF7B2968");

            entity.ToTable("GKCharacteristics");

            entity.Property(e => e.PlayerId).HasColumnName("player_id");
            entity.Property(e => e.FifaVersion).HasColumnName("fifa_version");
            entity.Property(e => e.GoalkeepingDiving).HasColumnName("goalkeeping_diving");
            entity.Property(e => e.GoalkeepingHandling).HasColumnName("goalkeeping_handling");
            entity.Property(e => e.GoalkeepingKicking).HasColumnName("goalkeeping_kicking");
            entity.Property(e => e.GoalkeepingPositioning).HasColumnName("goalkeeping_positioning");
            entity.Property(e => e.GoalkeepingReflexes).HasColumnName("goalkeeping_reflexes");
            entity.Property(e => e.GoalkeepingSpeed).HasColumnName("goalkeeping_speed");

            entity.HasOne(d => d.Player).WithMany(p => p.Gkcharacteristics)
                .HasForeignKey(d => d.PlayerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__GKCharact__playe__6EF57B66");
        });

        modelBuilder.Entity<League>(entity =>
        {
            entity.HasKey(e => e.LeagueId).HasName("PK__Leagues__EBE3BB2FF89AD024");

            entity.Property(e => e.LeagueId)
                .ValueGeneratedNever()
                .HasColumnName("league_id");
            entity.Property(e => e.LeagueLevel).HasColumnName("league_level");
            entity.Property(e => e.LeagueName)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("league_name");
            entity.Property(e => e.NationalityId).HasColumnName("nationality_id");

            entity.HasOne(d => d.Nationality).WithMany(p => p.Leagues)
                .HasForeignKey(d => d.NationalityId)
                .HasConstraintName("FK__Leagues__nationa__4BAC3F29");
        });

        modelBuilder.Entity<MainCharacteristic>(entity =>
        {
            entity.HasKey(e => new { e.PlayerId, e.FifaVersion }).HasName("PK__MainChar__54EC714D66C1A4CD");

            entity.Property(e => e.PlayerId).HasColumnName("player_id");
            entity.Property(e => e.FifaVersion).HasColumnName("fifa_version");
            entity.Property(e => e.Defending).HasColumnName("defending");
            entity.Property(e => e.Dribbling).HasColumnName("dribbling");
            entity.Property(e => e.Pace).HasColumnName("pace");
            entity.Property(e => e.Passing).HasColumnName("passing");
            entity.Property(e => e.Physic).HasColumnName("physic");
            entity.Property(e => e.Shooting).HasColumnName("shooting");

            entity.HasOne(d => d.Player).WithMany(p => p.MainCharacteristics)
                .HasForeignKey(d => d.PlayerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MainChara__playe__5AEE82B9");
        });

        modelBuilder.Entity<MentalityCharacteristic>(entity =>
        {
            entity.HasKey(e => new { e.PlayerId, e.FifaVersion }).HasName("PK__Mentalit__54EC714DC90B5B1D");

            entity.Property(e => e.PlayerId).HasColumnName("player_id");
            entity.Property(e => e.FifaVersion).HasColumnName("fifa_version");
            entity.Property(e => e.MentalityAggression).HasColumnName("mentality_aggression");
            entity.Property(e => e.MentalityComposure).HasColumnName("mentality_composure");
            entity.Property(e => e.MentalityInterceptions).HasColumnName("mentality_interceptions");
            entity.Property(e => e.MentalityPenalties).HasColumnName("mentality_penalties");
            entity.Property(e => e.MentalityPositioning).HasColumnName("mentality_positioning");
            entity.Property(e => e.MentalityVision).HasColumnName("mentality_vision");

            entity.HasOne(d => d.Player).WithMany(p => p.MentalityCharacteristics)
                .HasForeignKey(d => d.PlayerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Mentality__playe__693CA210");
        });

        modelBuilder.Entity<MovementCharacteristic>(entity =>
        {
            entity.HasKey(e => new { e.PlayerId, e.FifaVersion }).HasName("PK__Movement__54EC714D07D75920");

            entity.Property(e => e.PlayerId).HasColumnName("player_id");
            entity.Property(e => e.FifaVersion).HasColumnName("fifa_version");
            entity.Property(e => e.MovementAcceleration).HasColumnName("movement_acceleration");
            entity.Property(e => e.MovementAgility).HasColumnName("movement_agility");
            entity.Property(e => e.MovementBalance).HasColumnName("movement_balance");
            entity.Property(e => e.MovementReactions).HasColumnName("movement_reactions");
            entity.Property(e => e.MovementSprintSpeed).HasColumnName("movement_sprint_speed");
            entity.Property(e => e.SkillMoves).HasColumnName("skill_moves");

            entity.HasOne(d => d.Player).WithMany(p => p.MovementCharacteristics)
                .HasForeignKey(d => d.PlayerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MovementC__playe__6383C8BA");
        });

        modelBuilder.Entity<Nationality>(entity =>
        {
            entity.HasKey(e => e.NationalityId).HasName("PK__National__2E6444ED63AC103B");

            entity.Property(e => e.NationalityId)
                .ValueGeneratedNever()
                .HasColumnName("nationality_id");
            entity.Property(e => e.NationalityName)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("nationality_name");
        });

        modelBuilder.Entity<Player>(entity =>
        {
            entity.HasKey(e => e.PlayerId).HasName("PK__Players__44DA120CA4CE371D");

            entity.Property(e => e.PlayerId)
                .ValueGeneratedNever()
                .HasColumnName("player_id");
            entity.Property(e => e.ClubJerseyNumber).HasColumnName("club_jersey_number");
            entity.Property(e => e.ClubTeamId).HasColumnName("club_team_id");
            entity.Property(e => e.CoachId).HasColumnName("coach_id");
            entity.Property(e => e.Dob).HasColumnName("dob");
            entity.Property(e => e.FifaVersion).HasColumnName("fifa_version");
            entity.Property(e => e.HeightCm).HasColumnName("height_cm");
            entity.Property(e => e.LeagueId).HasColumnName("league_id");
            entity.Property(e => e.LongName)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("long_name");
            entity.Property(e => e.NationalityId).HasColumnName("nationality_id");
            entity.Property(e => e.PlayerFaceUrl)
                .HasColumnType("text")
                .HasColumnName("player_face_url");
            entity.Property(e => e.PlayerPositions)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("player_positions");
            entity.Property(e => e.PlayerTags)
                .HasColumnType("text")
                .HasColumnName("player_tags");
            entity.Property(e => e.PreferredFoot)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("preferred_foot");
            entity.Property(e => e.WeightKg).HasColumnName("weight_kg");

            entity.HasOne(d => d.ClubTeam).WithMany(p => p.Players)
                .HasForeignKey(d => d.ClubTeamId)
                .HasConstraintName("FK__Players__club_te__571DF1D5");

            entity.HasOne(d => d.Coach).WithMany(p => p.Players)
                .HasForeignKey(d => d.CoachId)
                .HasConstraintName("FK__Players__coach_i__5535A963");

            entity.HasOne(d => d.League).WithMany(p => p.Players)
                .HasForeignKey(d => d.LeagueId)
                .HasConstraintName("FK__Players__league___5629CD9C");

            entity.HasOne(d => d.Nationality).WithMany(p => p.Players)
                .HasForeignKey(d => d.NationalityId)
                .HasConstraintName("FK__Players__nationa__5812160E");
        });

        modelBuilder.Entity<PlayerHistory>(entity =>
        {
            entity.HasKey(e => new { e.PlayerId, e.FifaVersion }).HasName("PK__PlayerHi__54EC714D4E1A516C");

            entity.ToTable("PlayerHistory");

            entity.Property(e => e.PlayerId).HasColumnName("player_id");
            entity.Property(e => e.FifaVersion).HasColumnName("fifa_version");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.BodyType)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("body_type");
            entity.Property(e => e.FifaUpdateDate).HasColumnName("fifa_update_date");
            entity.Property(e => e.HeightCm).HasColumnName("height_cm");
            entity.Property(e => e.InternationalReputation).HasColumnName("international_reputation");
            entity.Property(e => e.Overall).HasColumnName("overall");
            entity.Property(e => e.PlayerPositions)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("player_positions");
            entity.Property(e => e.PlayerTags)
                .HasColumnType("text")
                .HasColumnName("player_tags");
            entity.Property(e => e.Potential).HasColumnName("potential");
            entity.Property(e => e.PreferredFoot)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("preferred_foot");
            entity.Property(e => e.ShortName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("short_name");
            entity.Property(e => e.ValueEur).HasColumnName("value_eur");
            entity.Property(e => e.WeakFoot).HasColumnName("weak_foot");
            entity.Property(e => e.WeightKg).HasColumnName("weight_kg");
            entity.Property(e => e.WorkRate)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("work_rate");

            entity.HasOne(d => d.Player).WithMany(p => p.PlayerHistories)
                .HasForeignKey(d => d.PlayerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PlayerHis__playe__74AE54BC");
        });

        modelBuilder.Entity<PlayerPosition>(entity =>
        {
            entity.HasKey(e => new { e.PlayerId, e.FifaVersion }).HasName("PK__PlayerPo__54EC714D347E0E50");

            entity.Property(e => e.PlayerId).HasColumnName("player_id");
            entity.Property(e => e.FifaVersion).HasColumnName("fifa_version");
            entity.Property(e => e.Cam)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("cam");
            entity.Property(e => e.Cb)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("cb");
            entity.Property(e => e.Cdm)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("cdm");
            entity.Property(e => e.Cf)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("cf");
            entity.Property(e => e.Cm)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("cm");
            entity.Property(e => e.Gk)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("gk");
            entity.Property(e => e.Lam)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("lam");
            entity.Property(e => e.Lb)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("lb");
            entity.Property(e => e.Lcb)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("lcb");
            entity.Property(e => e.Lcm)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("lcm");
            entity.Property(e => e.Ldm)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ldm");
            entity.Property(e => e.Lf)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("lf");
            entity.Property(e => e.Lm)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("lm");
            entity.Property(e => e.Ls)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ls");
            entity.Property(e => e.Lw)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("lw");
            entity.Property(e => e.Lwb)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("lwb");
            entity.Property(e => e.Ram)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ram");
            entity.Property(e => e.Rb)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("rb");
            entity.Property(e => e.Rcb)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("rcb");
            entity.Property(e => e.Rcm)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("rcm");
            entity.Property(e => e.Rdm)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("rdm");
            entity.Property(e => e.Rf)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("rf");
            entity.Property(e => e.Rm)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("rm");
            entity.Property(e => e.Rs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("rs");
            entity.Property(e => e.Rw)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("rw");
            entity.Property(e => e.Rwb)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("rwb");
            entity.Property(e => e.St)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("st");

            entity.HasOne(d => d.Player).WithMany(p => p.PlayerPositionsNavigation)
                .HasForeignKey(d => d.PlayerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PlayerPos__playe__71D1E811");
        });

        modelBuilder.Entity<PowerCharacteristic>(entity =>
        {
            entity.HasKey(e => new { e.PlayerId, e.FifaVersion }).HasName("PK__PowerCha__54EC714DE23A754E");

            entity.Property(e => e.PlayerId).HasColumnName("player_id");
            entity.Property(e => e.FifaVersion).HasColumnName("fifa_version");
            entity.Property(e => e.PowerJumping).HasColumnName("power_jumping");
            entity.Property(e => e.PowerLongShots).HasColumnName("power_long_shots");
            entity.Property(e => e.PowerShotPower).HasColumnName("power_shot_power");
            entity.Property(e => e.PowerStamina).HasColumnName("power_stamina");
            entity.Property(e => e.PowerStrength).HasColumnName("power_strength");

            entity.HasOne(d => d.Player).WithMany(p => p.PowerCharacteristics)
                .HasForeignKey(d => d.PlayerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PowerChar__playe__66603565");
        });

        modelBuilder.Entity<SkillCharacteristic>(entity =>
        {
            entity.HasKey(e => new { e.PlayerId, e.FifaVersion }).HasName("PK__SkillCha__54EC714D3A5445A7");

            entity.Property(e => e.PlayerId).HasColumnName("player_id");
            entity.Property(e => e.FifaVersion).HasColumnName("fifa_version");
            entity.Property(e => e.SkillBallControl).HasColumnName("skill_ball_control");
            entity.Property(e => e.SkillCurve).HasColumnName("skill_curve");
            entity.Property(e => e.SkillDribbling).HasColumnName("skill_dribbling");
            entity.Property(e => e.SkillFkAccuracy).HasColumnName("skill_fk_accuracy");
            entity.Property(e => e.SkillLongPassing).HasColumnName("skill_long_passing");

            entity.HasOne(d => d.Player).WithMany(p => p.SkillCharacteristics)
                .HasForeignKey(d => d.PlayerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SkillChar__playe__60A75C0F");
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(e => e.TeamId).HasName("PK__Teams__F82DEDBC105706A1");

            entity.Property(e => e.TeamId)
                .ValueGeneratedNever()
                .HasColumnName("team_id");
            entity.Property(e => e.Attack).HasColumnName("attack");
            entity.Property(e => e.Defence).HasColumnName("defence");
            entity.Property(e => e.FifaVersion).HasColumnName("fifa_version");
            entity.Property(e => e.HomeStadium)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("home_stadium");
            entity.Property(e => e.LeagueId).HasColumnName("league_id");
            entity.Property(e => e.Midfield).HasColumnName("midfield");
            entity.Property(e => e.NationalityId).HasColumnName("nationality_id");
            entity.Property(e => e.Overall).HasColumnName("overall");
            entity.Property(e => e.RivalTeam).HasColumnName("rival_team");
            entity.Property(e => e.TeamName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("team_name");

            entity.HasOne(d => d.League).WithMany(p => p.Teams)
                .HasForeignKey(d => d.LeagueId)
                .HasConstraintName("FK__Teams__league_id__4E88ABD4");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
