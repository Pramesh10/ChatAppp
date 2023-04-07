﻿// <auto-generated />
using System;
using DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataLayer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220328121248_AddedGroupMemberTable")]
    partial class AddedGroupMemberTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DataLayer.Entities.GroupMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("GroupId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("UserId");

                    b.ToTable("GroupMembers");
                });

            modelBuilder.Entity("DataLayer.Group", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GroupId"), 1L, 1);

                    b.Property<string>("GroupName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("GroupId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("DataLayer.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MessageId"), 1L, 1);

                    b.Property<string>("MessageContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MessageFromUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("MessageTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MessageToGroupGroupId")
                        .HasColumnType("int");

                    b.Property<int?>("MessageToUserUserId")
                        .HasColumnType("int");

                    b.HasKey("MessageId");

                    b.HasIndex("MessageFromUserId");

                    b.HasIndex("MessageToGroupGroupId");

                    b.HasIndex("MessageToUserUserId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("DataLayer.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DataLayer.Entities.GroupMember", b =>
                {
                    b.HasOne("DataLayer.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId");

                    b.HasOne("DataLayer.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Group");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DataLayer.Message", b =>
                {
                    b.HasOne("DataLayer.User", "MessageFrom")
                        .WithMany()
                        .HasForeignKey("MessageFromUserId");

                    b.HasOne("DataLayer.Group", "MessageToGroup")
                        .WithMany()
                        .HasForeignKey("MessageToGroupGroupId");

                    b.HasOne("DataLayer.User", "MessageToUser")
                        .WithMany()
                        .HasForeignKey("MessageToUserUserId");

                    b.Navigation("MessageFrom");

                    b.Navigation("MessageToGroup");

                    b.Navigation("MessageToUser");
                });
#pragma warning restore 612, 618
        }
    }
}
