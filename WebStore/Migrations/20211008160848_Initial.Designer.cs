﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebStore;

namespace WebStore.Migrations
{
    [DbContext(typeof(Database))]
    [Migration("20211008160848_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.10");

            modelBuilder.Entity("WebStore.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("FromUserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Text")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ToUserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FromUserId");

                    b.HasIndex("ToUserId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("WebStore.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Fulfilled")
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("WebStore.OrderDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("OrderId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("WebStore.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WebStore.Message", b =>
                {
                    b.HasOne("WebStore.User", "FromUser")
                        .WithMany("SentMessages")
                        .HasForeignKey("FromUserId");

                    b.HasOne("WebStore.User", "ToUser")
                        .WithMany("ReceivedMessages")
                        .HasForeignKey("ToUserId");

                    b.Navigation("FromUser");

                    b.Navigation("ToUser");
                });

            modelBuilder.Entity("WebStore.Order", b =>
                {
                    b.HasOne("WebStore.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebStore.OrderDetail", b =>
                {
                    b.HasOne("WebStore.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("WebStore.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("WebStore.User", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("ReceivedMessages");

                    b.Navigation("SentMessages");
                });
#pragma warning restore 612, 618
        }
    }
}