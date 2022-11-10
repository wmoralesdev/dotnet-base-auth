﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Wame.Application.Context;

#nullable disable

namespace Wame.Application.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20221110035437_CreatedInvitationId")]
    partial class CreatedInvitationId
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Wame.Domain.Entities.BaseIdentities.BaseIdentity", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.HasKey("Email");

                    b.ToTable("BaseIdentities");

                    b.HasDiscriminator<string>("Discriminator").HasValue("BaseIdentity");
                });

            modelBuilder.Entity("Wame.Domain.Entities.Campaigns.Campaign", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("HiredEmail")
                        .HasColumnType("text");

                    b.Property<Guid?>("InvitationId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("PositionId")
                        .HasColumnType("integer");

                    b.Property<string>("RecruiterEmail")
                        .HasColumnType("text");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("HiredEmail");

                    b.HasIndex("PositionId");

                    b.HasIndex("RecruiterEmail");

                    b.ToTable("Campaigns");
                });

            modelBuilder.Entity("Wame.Domain.Entities.Jobs.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Responsibilities")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("Wame.Domain.Entities.Users.Candidate", b =>
                {
                    b.HasBaseType("Wame.Domain.Entities.BaseIdentities.BaseIdentity");

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<string>("Aptitudes")
                        .HasColumnType("text");

                    b.Property<int?>("CampaignId")
                        .HasColumnType("integer");

                    b.Property<string>("Experience")
                        .HasColumnType("text");

                    b.Property<string>("Formation")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.HasIndex("CampaignId");

                    b.HasDiscriminator().HasValue("Candidate");
                });

            modelBuilder.Entity("Wame.Domain.Entities.Users.Recruiter", b =>
                {
                    b.HasBaseType("Wame.Domain.Entities.BaseIdentities.BaseIdentity");

                    b.HasDiscriminator().HasValue("Recruiter");
                });

            modelBuilder.Entity("Wame.Domain.Entities.Campaigns.Campaign", b =>
                {
                    b.HasOne("Wame.Domain.Entities.Users.Candidate", "Hired")
                        .WithMany("Campaigns")
                        .HasForeignKey("HiredEmail");

                    b.HasOne("Wame.Domain.Entities.Jobs.Job", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId");

                    b.HasOne("Wame.Domain.Entities.Users.Recruiter", "Recruiter")
                        .WithMany("Campaigns")
                        .HasForeignKey("RecruiterEmail");

                    b.Navigation("Hired");

                    b.Navigation("Position");

                    b.Navigation("Recruiter");
                });

            modelBuilder.Entity("Wame.Domain.Entities.Users.Candidate", b =>
                {
                    b.HasOne("Wame.Domain.Entities.Campaigns.Campaign", null)
                        .WithMany("Candidates")
                        .HasForeignKey("CampaignId");
                });

            modelBuilder.Entity("Wame.Domain.Entities.Campaigns.Campaign", b =>
                {
                    b.Navigation("Candidates");
                });

            modelBuilder.Entity("Wame.Domain.Entities.Users.Candidate", b =>
                {
                    b.Navigation("Campaigns");
                });

            modelBuilder.Entity("Wame.Domain.Entities.Users.Recruiter", b =>
                {
                    b.Navigation("Campaigns");
                });
#pragma warning restore 612, 618
        }
    }
}
