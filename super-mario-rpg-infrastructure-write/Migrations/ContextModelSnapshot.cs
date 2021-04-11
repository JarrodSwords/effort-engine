﻿// <auto-generated />

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SuperMarioRpg.Infrastructure.Write.Migrations
{
    [DbContext(typeof(Context))]
    internal class ContextModelSnapshot : ModelSnapshot
    {
        #region Protected Interface

        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity(
                "SuperMarioRpg.Infrastructure.Write.Character",
                b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid?>("CombatStatsId")
                        .HasColumnType("uuid")
                        .HasColumnName("combat_stats_id");

                    b.Property<bool>("IsEnemy")
                        .HasColumnType("boolean")
                        .HasColumnName("is_enemy");

                    b.Property<bool>("IsNonPlayerCharacter")
                        .HasColumnType("boolean")
                        .HasColumnName("is_non_player_character");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_character");

                    b.HasIndex("CombatStatsId")
                        .HasDatabaseName("ix_character_combat_stats_id");

                    b.ToTable("character");
                }
            );

            modelBuilder.Entity(
                "SuperMarioRpg.Infrastructure.Write.BaseStats",
                b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<short>("Attack")
                        .HasColumnType("smallint")
                        .HasColumnName("attack");

                    b.Property<short>("Defense")
                        .HasColumnType("smallint")
                        .HasColumnName("defense");

                    b.Property<decimal?>("Evade")
                        .HasColumnType("numeric")
                        .HasColumnName("evade");

                    b.Property<byte?>("FlowerPoints")
                        .HasColumnType("smallint")
                        .HasColumnName("flower_points");

                    b.Property<int>("HitPoints")
                        .HasColumnType("integer")
                        .HasColumnName("hit_points");

                    b.Property<short>("MagicAttack")
                        .HasColumnType("smallint")
                        .HasColumnName("magic_attack");

                    b.Property<short>("MagicDefense")
                        .HasColumnType("smallint")
                        .HasColumnName("magic_defense");

                    b.Property<decimal?>("MagicEvade")
                        .HasColumnType("numeric")
                        .HasColumnName("magic_evade");

                    b.Property<short>("Speed")
                        .HasColumnType("smallint")
                        .HasColumnName("speed");

                    b.HasKey("Id")
                        .HasName("pk_combat_stats");

                    b.ToTable("combat_stats");
                }
            );

            modelBuilder.Entity(
                "SuperMarioRpg.Infrastructure.Write.Character",
                b =>
                {
                    b.HasOne("SuperMarioRpg.Infrastructure.Write.BaseStats", "BaseStats")
                        .WithMany()
                        .HasForeignKey("CombatStatsId")
                        .HasConstraintName("fk_character_combat_stats_combat_stats_id");

                    b.Navigation("BaseStats");
                }
            );
#pragma warning restore 612, 618
        }

        #endregion
    }
}
