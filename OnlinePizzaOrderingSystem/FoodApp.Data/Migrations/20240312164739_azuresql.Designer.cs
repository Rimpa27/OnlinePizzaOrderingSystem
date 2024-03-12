﻿// <auto-generated />
using System;
using FoodApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FoodApp.Data.Migrations
{
    [DbContext(typeof(PizzaOrderingAppContext))]
    [Migration("20240312164739_azuresql")]
    partial class azuresql
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FoodApp.Entities.Address", b =>
                {
                    b.Property<int>("AddressID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AddressID"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Line1")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Line2")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PinCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("AddressID");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("FoodApp.Entities.Cart", b =>
                {
                    b.Property<int>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CartId"));

                    b.Property<int>("CustomersUserID")
                        .HasColumnType("int");

                    b.Property<int?>("DeliveryDetailsDeliveryId")
                        .HasColumnType("int");

                    b.HasKey("CartId");

                    b.HasIndex("CustomersUserID");

                    b.HasIndex("DeliveryDetailsDeliveryId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("FoodApp.Entities.CartItem", b =>
                {
                    b.Property<int>("CartItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CartItemId"));

                    b.Property<int?>("CartId")
                        .HasColumnType("int");

                    b.Property<decimal>("CartItemPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CartItemQuantity")
                        .HasColumnType("int");

                    b.Property<int>("MenuItemId")
                        .HasColumnType("int");

                    b.Property<string>("ToppingType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CartItemId");

                    b.HasIndex("CartId");

                    b.HasIndex("MenuItemId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("FoodApp.Entities.DeliveryDetails", b =>
                {
                    b.Property<int>("DeliveryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DeliveryId"));

                    b.Property<DateTime>("DeliveryDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("DeliveryId");

                    b.ToTable("DeliveryDetails");
                });

            modelBuilder.Entity("FoodApp.Entities.MenuItem", b =>
                {
                    b.Property<int>("MenuItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MenuItemId"));

                    b.Property<int>("Calories")
                        .HasColumnType("int");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<int>("MenuItemCategory")
                        .HasColumnType("int");

                    b.Property<string>("MenuItemDescription")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("MenuItemName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PreparationTime")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductPhoto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VegOrNonVeg")
                        .HasColumnType("int");

                    b.HasKey("MenuItemId");

                    b.ToTable("MenuItems");
                });

            modelBuilder.Entity("FoodApp.Entities.OrderItem", b =>
                {
                    b.Property<int>("OrderItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderItemId"));

                    b.Property<decimal>("CartItemPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CartItemQuantity")
                        .HasColumnType("int");

                    b.Property<int>("MenuItemId")
                        .HasColumnType("int");

                    b.Property<int?>("OrderSummaryOrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderItemId");

                    b.HasIndex("MenuItemId");

                    b.HasIndex("OrderSummaryOrderId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("FoodApp.Entities.OrderPayment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentId"));

                    b.Property<int>("PaymentStatus")
                        .HasColumnType("int");

                    b.Property<int>("PaymentType")
                        .HasColumnType("int");

                    b.Property<string>("TransactionId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PaymentId");

                    b.ToTable("OrderPayments");
                });

            modelBuilder.Entity("FoodApp.Entities.OrderSummary", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int?>("DeliveryDetailsDeliveryId")
                        .HasColumnType("int");

                    b.Property<int?>("DeliveryPersonId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderStatus")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.Property<decimal>("OrderTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("PaymentId")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("DeliveryDetailsDeliveryId");

                    b.HasIndex("DeliveryPersonId");

                    b.HasIndex("PaymentId");

                    b.ToTable("OrderSummaries");
                });

            modelBuilder.Entity("FoodApp.Entities.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("nvarchar(21)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ProfileImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleType")
                        .HasColumnType("int");

                    b.HasKey("UserID");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("FoodApp.Entities.Admin", b =>
                {
                    b.HasBaseType("FoodApp.Entities.User");

                    b.HasDiscriminator().HasValue("Admin");
                });

            modelBuilder.Entity("FoodApp.Entities.Customer", b =>
                {
                    b.HasBaseType("FoodApp.Entities.User");

                    b.Property<int?>("AddressID")
                        .HasColumnType("int");

                    b.Property<long>("Phone")
                        .HasColumnType("bigint");

                    b.HasIndex("AddressID");

                    b.ToTable("Users", t =>
                        {
                            t.Property("Phone")
                                .HasColumnName("Customer_Phone");
                        });

                    b.HasDiscriminator().HasValue("Customer");
                });

            modelBuilder.Entity("FoodApp.Entities.DeliveryPerson", b =>
                {
                    b.HasBaseType("FoodApp.Entities.User");

                    b.Property<long>("Phone")
                        .HasColumnType("bigint");

                    b.HasDiscriminator().HasValue("DeliveryPerson");
                });

            modelBuilder.Entity("FoodApp.Entities.Cart", b =>
                {
                    b.HasOne("FoodApp.Entities.Customer", "Customers")
                        .WithMany()
                        .HasForeignKey("CustomersUserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodApp.Entities.DeliveryDetails", "DeliveryDetails")
                        .WithMany()
                        .HasForeignKey("DeliveryDetailsDeliveryId");

                    b.Navigation("Customers");

                    b.Navigation("DeliveryDetails");
                });

            modelBuilder.Entity("FoodApp.Entities.CartItem", b =>
                {
                    b.HasOne("FoodApp.Entities.Cart", null)
                        .WithMany("CartItemList")
                        .HasForeignKey("CartId");

                    b.HasOne("FoodApp.Entities.MenuItem", "MenuItem")
                        .WithMany()
                        .HasForeignKey("MenuItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MenuItem");
                });

            modelBuilder.Entity("FoodApp.Entities.OrderItem", b =>
                {
                    b.HasOne("FoodApp.Entities.MenuItem", "MenuItem")
                        .WithMany()
                        .HasForeignKey("MenuItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodApp.Entities.OrderSummary", null)
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderSummaryOrderId");

                    b.Navigation("MenuItem");
                });

            modelBuilder.Entity("FoodApp.Entities.OrderSummary", b =>
                {
                    b.HasOne("FoodApp.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodApp.Entities.DeliveryDetails", "DeliveryDetails")
                        .WithMany()
                        .HasForeignKey("DeliveryDetailsDeliveryId");

                    b.HasOne("FoodApp.Entities.DeliveryPerson", "DeliveryPerson")
                        .WithMany()
                        .HasForeignKey("DeliveryPersonId");

                    b.HasOne("FoodApp.Entities.OrderPayment", "Payment")
                        .WithMany()
                        .HasForeignKey("PaymentId");

                    b.Navigation("Customer");

                    b.Navigation("DeliveryDetails");

                    b.Navigation("DeliveryPerson");

                    b.Navigation("Payment");
                });

            modelBuilder.Entity("FoodApp.Entities.Customer", b =>
                {
                    b.HasOne("FoodApp.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressID");

                    b.Navigation("Address");
                });

            modelBuilder.Entity("FoodApp.Entities.Cart", b =>
                {
                    b.Navigation("CartItemList");
                });

            modelBuilder.Entity("FoodApp.Entities.OrderSummary", b =>
                {
                    b.Navigation("OrderItems");
                });
#pragma warning restore 612, 618
        }
    }
}
