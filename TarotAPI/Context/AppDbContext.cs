using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TarotAPI.Models;

namespace TarotAPI.Context;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Character> Characters { get; set; }

    public virtual DbSet<Guild> Guilds { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    public virtual DbSet<User> Users { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Character>(entity =>
        {
            entity.HasMany(d => d.Teams).WithMany(p => p.Characters)
                .UsingEntity<Dictionary<string, object>>(
                    "CharacterTeam",
                    r => r.HasOne<Team>().WithMany().HasForeignKey("TeamsId"),
                    l => l.HasOne<Character>().WithMany().HasForeignKey("CharactersId"),
                    j =>
                    {
                        j.HasKey("CharactersId", "TeamsId");
                        j.ToTable("CharacterTeam");
                        j.HasIndex(new[] { "TeamsId" }, "IX_CharacterTeam_TeamsId");
                    });
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_Teams_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.Teams).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(e => e.GuildId, "IX_Users_GuildId");

            entity.HasOne(d => d.Guild).WithMany(p => p.Users).HasForeignKey(d => d.GuildId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
