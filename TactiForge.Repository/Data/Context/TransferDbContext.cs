using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TactiForge.Repository.Entities.TransferModels;

namespace TactiForge.Repository.Data.Context;

public partial class TransferDbContext : DbContext
{
    public TransferDbContext()
    {
    }

    public TransferDbContext(DbContextOptions<TransferDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Appearance> Appearances { get; set; }

    public virtual DbSet<Club> Clubs { get; set; }

    public virtual DbSet<ClubGame> ClubGames { get; set; }

    public virtual DbSet<Competition> Competitions { get; set; }

    public virtual DbSet<Game> Games { get; set; }

    public virtual DbSet<GameEvent> GameEvents { get; set; }

    public virtual DbSet<GameLineup> GameLineups { get; set; }

    public virtual DbSet<Player> Players { get; set; }

    public virtual DbSet<PlayerMatching> PlayerMatchings { get; set; }

    public virtual DbSet<PlayerValuation> PlayerValuations { get; set; }

    public virtual DbSet<Transfer> Transfers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=transferMarket;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appearance>(entity =>
        {
            entity.HasKey(e => e.AppearanceId).HasName("PK__appearan__4BCC8ECD29B7C73B");

            entity.ToTable("appearances");

            entity.Property(e => e.AppearanceId)
                .HasMaxLength(100)
                .HasColumnName("appearance_id");
            entity.Property(e => e.Assists).HasColumnName("assists");
            entity.Property(e => e.CompetitionId)
                .HasMaxLength(20)
                .HasColumnName("competition_id");
            entity.Property(e => e.Date)
                .HasMaxLength(100)
                .HasColumnName("date");
            entity.Property(e => e.GameId).HasColumnName("game_id");
            entity.Property(e => e.Goals).HasColumnName("goals");
            entity.Property(e => e.MinutesPlayed).HasColumnName("minutes_played");
            entity.Property(e => e.PlayerClubId).HasColumnName("player_club_id");
            entity.Property(e => e.PlayerCurrentClubId).HasColumnName("player_current_club_id");
            entity.Property(e => e.PlayerId).HasColumnName("player_id");
            entity.Property(e => e.PlayerName)
                .HasMaxLength(255)
                .HasColumnName("player_name");
            entity.Property(e => e.RedCards).HasColumnName("red_cards");
            entity.Property(e => e.YellowCards).HasColumnName("yellow_cards");
        });

        modelBuilder.Entity<Club>(entity =>
        {
            entity.HasKey(e => e.ClubId).HasName("PK__clubs__BCAD3DD92074D788");

            entity.ToTable("clubs");

            entity.Property(e => e.ClubId)
                .ValueGeneratedNever()
                .HasColumnName("club_id");
            entity.Property(e => e.AverageAge).HasColumnName("average_age");
            entity.Property(e => e.ClubCode)
                .HasMaxLength(50)
                .HasColumnName("club_code");
            entity.Property(e => e.CoachName)
                .HasMaxLength(255)
                .HasColumnName("coach_name");
            entity.Property(e => e.DomesticCompetitionId)
                .HasMaxLength(20)
                .HasColumnName("domestic_competition_id");
            entity.Property(e => e.Filename)
                .HasMaxLength(255)
                .HasColumnName("filename");
            entity.Property(e => e.ForeignersNumber).HasColumnName("foreigners_number");
            entity.Property(e => e.ForeignersPercentage).HasColumnName("foreigners_percentage");
            entity.Property(e => e.LastSeason).HasColumnName("last_season");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.NationalTeamPlayers).HasColumnName("national_team_players");
            entity.Property(e => e.NetTransferRecord)
                .HasMaxLength(255)
                .HasColumnName("net_transfer_record");
            entity.Property(e => e.SquadSize).HasColumnName("squad_size");
            entity.Property(e => e.StadiumName)
                .HasMaxLength(255)
                .HasColumnName("stadium_name");
            entity.Property(e => e.StadiumSeats).HasColumnName("stadium_seats");
            entity.Property(e => e.TotalMarketValue).HasColumnName("total_market_value");
            entity.Property(e => e.Url)
                .HasMaxLength(500)
                .HasColumnName("url");

            entity.HasOne(d => d.DomesticCompetition).WithMany(p => p.Clubs)
                .HasForeignKey(d => d.DomesticCompetitionId)
                .HasConstraintName("FK__clubs__domestic___52593CB8");
        });

        modelBuilder.Entity<ClubGame>(entity =>
        {
            entity.HasKey(e => new { e.ClubId, e.OpponentId, e.GameId }).HasName("PK__club_gam__03071886A4FB5D2E");

            entity.ToTable("club_games");

            entity.Property(e => e.ClubId).HasColumnName("club_id");
            entity.Property(e => e.OpponentId).HasColumnName("opponent_id");
            entity.Property(e => e.GameId).HasColumnName("game_id");
            entity.Property(e => e.Hosting)
                .HasMaxLength(50)
                .HasColumnName("hosting");
            entity.Property(e => e.IsWin).HasColumnName("is_win");
            entity.Property(e => e.OpponentGoals).HasColumnName("opponent_goals");
            entity.Property(e => e.OpponentManagerName)
                .HasMaxLength(255)
                .HasColumnName("opponent_manager_name");
            entity.Property(e => e.OpponentPosition).HasColumnName("opponent_position");
            entity.Property(e => e.OwnGoals).HasColumnName("own_goals");
            entity.Property(e => e.OwnManagerName)
                .HasMaxLength(255)
                .HasColumnName("own_manager_name");
            entity.Property(e => e.OwnPosition).HasColumnName("own_position");

            entity.HasOne(d => d.Club).WithMany(p => p.ClubGames)
                .HasForeignKey(d => d.ClubId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__club_game__club___06CD04F7");

            entity.HasOne(d => d.Game).WithMany(p => p.ClubGames)
                .HasForeignKey(d => d.GameId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__club_game__game___07C12930");
        });

        modelBuilder.Entity<Competition>(entity =>
        {
            entity.HasKey(e => e.CompetitionId).HasName("PK__competit__BB383B58E7ED4A56");

            entity.ToTable("competitions");

            entity.Property(e => e.CompetitionId)
                .HasMaxLength(20)
                .HasColumnName("competition_id");
            entity.Property(e => e.CompetitionCode)
                .HasMaxLength(60)
                .HasColumnName("competition_code");
            entity.Property(e => e.Confederation)
                .HasMaxLength(100)
                .HasColumnName("confederation");
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.CountryName)
                .HasMaxLength(50)
                .HasColumnName("country_name");
            entity.Property(e => e.DomesticLeagueCode)
                .HasMaxLength(50)
                .HasColumnName("domestic_league_code");
            entity.Property(e => e.IsMajorNationalLeague)
                .HasMaxLength(6)
                .HasColumnName("is_major_national_league");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.SubType)
                .HasMaxLength(100)
                .HasColumnName("sub_type");
            entity.Property(e => e.Type)
                .HasMaxLength(100)
                .HasColumnName("type");
            entity.Property(e => e.Url)
                .HasMaxLength(500)
                .HasColumnName("url");
        });

        modelBuilder.Entity<Game>(entity =>
        {
            entity.HasKey(e => e.GameId).HasName("PK__games__FFE11FCF62B90BD2");

            entity.ToTable("games");

            entity.Property(e => e.GameId)
                .ValueGeneratedNever()
                .HasColumnName("game_id");
            entity.Property(e => e.Aggregate)
                .HasMaxLength(100)
                .HasColumnName("aggregate");
            entity.Property(e => e.Attendance).HasColumnName("attendance");
            entity.Property(e => e.AwayClubFormation)
                .HasMaxLength(100)
                .HasColumnName("away_club_formation");
            entity.Property(e => e.AwayClubGoals).HasColumnName("away_club_goals");
            entity.Property(e => e.AwayClubId).HasColumnName("away_club_id");
            entity.Property(e => e.AwayClubManagerName)
                .HasMaxLength(255)
                .HasColumnName("away_club_manager_name");
            entity.Property(e => e.AwayClubName)
                .HasMaxLength(255)
                .HasColumnName("away_club_name");
            entity.Property(e => e.AwayClubPosition).HasColumnName("away_club_position");
            entity.Property(e => e.CompetitionId)
                .HasMaxLength(20)
                .HasColumnName("competition_id");
            entity.Property(e => e.CompetitionType)
                .HasMaxLength(100)
                .HasColumnName("competition_type");
            entity.Property(e => e.Date)
                .HasMaxLength(100)
                .HasColumnName("date");
            entity.Property(e => e.HomeClubFormation)
                .HasMaxLength(100)
                .HasColumnName("home_club_formation");
            entity.Property(e => e.HomeClubGoals).HasColumnName("home_club_goals");
            entity.Property(e => e.HomeClubId).HasColumnName("home_club_id");
            entity.Property(e => e.HomeClubManagerName)
                .HasMaxLength(255)
                .HasColumnName("home_club_manager_name");
            entity.Property(e => e.HomeClubName)
                .HasMaxLength(255)
                .HasColumnName("home_club_name");
            entity.Property(e => e.HomeClubPosition).HasColumnName("home_club_position");
            entity.Property(e => e.Referee)
                .HasMaxLength(255)
                .HasColumnName("referee");
            entity.Property(e => e.Round)
                .HasMaxLength(100)
                .HasColumnName("round");
            entity.Property(e => e.Season).HasColumnName("season");
            entity.Property(e => e.Stadium)
                .HasMaxLength(255)
                .HasColumnName("stadium");
            entity.Property(e => e.Url)
                .HasMaxLength(500)
                .HasColumnName("url");

            entity.HasOne(d => d.Competition).WithMany(p => p.Games)
                .HasForeignKey(d => d.CompetitionId)
                .HasConstraintName("FK__games__competiti__5EBF139D");
        });

        modelBuilder.Entity<GameEvent>(entity =>
        {
            entity.HasKey(e => e.GameEventId).HasName("PK__game_eve__0E0B2B5B1FC71675");

            entity.ToTable("game_events");

            entity.Property(e => e.GameEventId)
                .HasMaxLength(100)
                .HasColumnName("game_event_id");
            entity.Property(e => e.ClubId).HasColumnName("club_id");
            entity.Property(e => e.Date)
                .HasMaxLength(100)
                .HasColumnName("date");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
            entity.Property(e => e.GameId).HasColumnName("game_id");
            entity.Property(e => e.Minute).HasColumnName("minute");
            entity.Property(e => e.PlayerAssistId).HasColumnName("player_assist_id");
            entity.Property(e => e.PlayerId).HasColumnName("player_id");
            entity.Property(e => e.PlayerInId).HasColumnName("player_in_id");
            entity.Property(e => e.Type)
                .HasMaxLength(100)
                .HasColumnName("type");

            entity.HasOne(d => d.Player).WithMany(p => p.GameEvents)
                .HasForeignKey(d => d.PlayerId)
                .HasConstraintName("FK__game_even__playe__14270015");
        });

        modelBuilder.Entity<GameLineup>(entity =>
        {
            entity.HasKey(e => e.GameLineupsId).HasName("PK__game_lin__537F659920AD2832");

            entity.ToTable("game_lineups");

            entity.Property(e => e.GameLineupsId)
                .HasMaxLength(100)
                .HasColumnName("game_lineups_id");
            entity.Property(e => e.ClubId).HasColumnName("club_id");
            entity.Property(e => e.Date)
                .HasMaxLength(100)
                .HasColumnName("date");
            entity.Property(e => e.GameId).HasColumnName("game_id");
            entity.Property(e => e.Number)
                .HasMaxLength(100)
                .HasColumnName("number");
            entity.Property(e => e.PlayerId).HasColumnName("player_id");
            entity.Property(e => e.PlayerName)
                .HasMaxLength(255)
                .HasColumnName("player_name");
            entity.Property(e => e.Position)
                .HasMaxLength(100)
                .HasColumnName("position");
            entity.Property(e => e.TeamCaptain).HasColumnName("team_captain");
            entity.Property(e => e.Type)
                .HasMaxLength(100)
                .HasColumnName("type");
        });

        modelBuilder.Entity<Player>(entity =>
        {
            entity.HasKey(e => e.PlayerId).HasName("PK__players__44DA120CCC4A6909");

            entity.ToTable("players");

            entity.Property(e => e.PlayerId)
                .ValueGeneratedNever()
                .HasColumnName("player_id");
            entity.Property(e => e.AgentName)
                .HasMaxLength(255)
                .HasColumnName("agent_name");
            entity.Property(e => e.CityOfBirth)
                .HasMaxLength(255)
                .HasColumnName("city_of_birth");
            entity.Property(e => e.ContractExpirationDate)
                .HasMaxLength(100)
                .HasColumnName("contract_expiration_date");
            entity.Property(e => e.CountryOfBirth)
                .HasMaxLength(255)
                .HasColumnName("country_of_birth");
            entity.Property(e => e.CountryOfCitizenship)
                .HasMaxLength(255)
                .HasColumnName("country_of_citizenship");
            entity.Property(e => e.CurrentClubDomesticCompetitionId)
                .HasMaxLength(100)
                .HasColumnName("current_club_domestic_competition_id");
            entity.Property(e => e.CurrentClubId).HasColumnName("current_club_id");
            entity.Property(e => e.CurrentClubName)
                .HasMaxLength(255)
                .HasColumnName("current_club_name");
            entity.Property(e => e.DateOfBirth)
                .HasMaxLength(100)
                .HasColumnName("date_of_birth");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .HasColumnName("first_name");
            entity.Property(e => e.Foot)
                .HasMaxLength(50)
                .HasColumnName("foot");
            entity.Property(e => e.HeightInCm).HasColumnName("height_in_cm");
            entity.Property(e => e.HighestMarketValueInEur).HasColumnName("highest_market_value_in_eur");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(500)
                .HasColumnName("image_url");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .HasColumnName("last_name");
            entity.Property(e => e.LastSeason).HasColumnName("last_season");
            entity.Property(e => e.MarketValueInEur).HasColumnName("market_value_in_eur");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.PlayerCode)
                .HasMaxLength(100)
                .HasColumnName("player_code");
            entity.Property(e => e.Position)
                .HasMaxLength(100)
                .HasColumnName("position");
            entity.Property(e => e.SubPosition)
                .HasMaxLength(100)
                .HasColumnName("sub_position");
            entity.Property(e => e.Url)
                .HasMaxLength(500)
                .HasColumnName("url");

            entity.HasOne(d => d.CurrentClub).WithMany(p => p.Players)
                .HasForeignKey(d => d.CurrentClubId)
                .HasConstraintName("FK__players__current__6477ECF3");
        });

        modelBuilder.Entity<PlayerMatching>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PlayerMatching");

            entity.Property(e => e.SofifId).HasColumnName("Sofif_ID");
            entity.Property(e => e.TransfermarktId).HasColumnName("Transfermarkt_ID");
        });

        modelBuilder.Entity<PlayerValuation>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("player_valuations");

            entity.Property(e => e.CurrentClubId).HasColumnName("current_club_id");
            entity.Property(e => e.Date)
                .HasMaxLength(100)
                .HasColumnName("date");
            entity.Property(e => e.MarketValueInEur).HasColumnName("market_value_in_eur");
            entity.Property(e => e.PlayerClubDomesticCompetitionId)
                .HasMaxLength(100)
                .HasColumnName("player_club_domestic_competition_id");
            entity.Property(e => e.PlayerId).HasColumnName("player_id");

            entity.HasOne(d => d.Player).WithMany()
                .HasForeignKey(d => d.PlayerId)
                .HasConstraintName("FK__player_va__playe__17F790F9");
        });

        modelBuilder.Entity<Transfer>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("transfers");

            entity.Property(e => e.FromClubId).HasColumnName("from_club_id");
            entity.Property(e => e.FromClubName)
                .HasMaxLength(255)
                .HasColumnName("from_club_name");
            entity.Property(e => e.MarketValueInEur).HasColumnName("market_value_in_eur");
            entity.Property(e => e.PlayerId).HasColumnName("player_id");
            entity.Property(e => e.PlayerName)
                .HasMaxLength(255)
                .HasColumnName("player_name");
            entity.Property(e => e.ToClubId).HasColumnName("to_club_id");
            entity.Property(e => e.ToClubName)
                .HasMaxLength(255)
                .HasColumnName("to_club_name");
            entity.Property(e => e.TransferDate)
                .HasMaxLength(100)
                .HasColumnName("transfer_date");
            entity.Property(e => e.TransferFee)
                .HasMaxLength(100)
                .HasColumnName("transfer_fee");
            entity.Property(e => e.TransferSeason)
                .HasMaxLength(50)
                .HasColumnName("transfer_season");

            entity.HasOne(d => d.Player).WithMany()
                .HasForeignKey(d => d.PlayerId)
                .HasConstraintName("FK__transfers__playe__2645B050");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
