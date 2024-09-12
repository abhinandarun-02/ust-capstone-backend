using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EventPlannerAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialSeedMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Caterings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    About = table.Column<string>(type: "text", nullable: false),
                    Rating = table.Column<decimal>(type: "numeric", nullable: false),
                    Tier = table.Column<string>(type: "text", nullable: false),
                    Contact = table.Column<string>(type: "text", nullable: false),
                    MenuDetails = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caterings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Photographies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    About = table.Column<string>(type: "text", nullable: false),
                    Rating = table.Column<decimal>(type: "numeric", nullable: false),
                    Tier = table.Column<string>(type: "text", nullable: false),
                    Contact = table.Column<string>(type: "text", nullable: false),
                    PackageDetails = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photographies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Venues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    About = table.Column<string>(type: "text", nullable: false),
                    Rating = table.Column<decimal>(type: "numeric", nullable: false),
                    Tier = table.Column<string>(type: "text", nullable: false),
                    Contact = table.Column<string>(type: "text", nullable: false),
                    Capacity = table.Column<int>(type: "integer", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Weddings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    GuestCount = table.Column<int>(type: "integer", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    Budget = table.Column<decimal>(type: "numeric", nullable: false),
                    PlannerId = table.Column<string>(type: "text", nullable: true),
                    PlannerUsername = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weddings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WeddingId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Cost = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expenses_Weddings_WeddingId",
                        column: x => x.WeddingId,
                        principalTable: "Weddings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "text", nullable: false),
                    WeddingId = table.Column<int>(type: "integer", nullable: false),
                    CateringId = table.Column<int>(type: "integer", nullable: true),
                    PhotographyId = table.Column<int>(type: "integer", nullable: true),
                    VenueId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_Caterings_CateringId",
                        column: x => x.CateringId,
                        principalTable: "Caterings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Services_Photographies_PhotographyId",
                        column: x => x.PhotographyId,
                        principalTable: "Photographies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Services_Venues_VenueId",
                        column: x => x.VenueId,
                        principalTable: "Venues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Services_Weddings_WeddingId",
                        column: x => x.WeddingId,
                        principalTable: "Weddings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Caterings",
                columns: new[] { "Id", "About", "Contact", "Location", "MenuDetails", "Name", "Price", "Rating", "Tier" },
                values: new object[,]
                {
                    { 1, "High-end catering service with gourmet options.", "info@gourmetdelights.com", "New York", "Italian, Mexican, and American cuisine", "Gourmet Delights", 1500.00m, 4.5m, "Premium" },
                    { 2, "Specializes in vegetarian and vegan meals.", "contact@greenbites.com", "San Francisco", "Vegan salads, wraps, and smoothies", "Green Bites", 1200.00m, 4.8m, "Standard" },
                    { 3, "Classic catering with a wide range of dishes.", "hello@classicfeasts.com", "Chicago", "American BBQ, salads, and desserts", "Classic Feasts", 1800.00m, 4.6m, "Standard" },
                    { 4, "Elegant catering for sophisticated events.", "info@elegantevents.com", "Los Angeles", "French cuisine and gourmet options", "Elegant Events", 2000.00m, 4.9m, "Luxury" }
                });

            migrationBuilder.InsertData(
                table: "Photographies",
                columns: new[] { "Id", "About", "Contact", "Location", "Name", "PackageDetails", "Price", "Rating", "Tier" },
                values: new object[,]
                {
                    { 1, "Specializing in wedding photography with a magical touch.", "contact@photomagic.com", "Los Angeles", "PhotoMagic Studios", "Full-day coverage, digital album, and prints", 2500.00m, 4.9m, "Luxury" },
                    { 2, "Capturing the essence of every event.", "info@eventsnapshots.com", "New York", "Event Snapshots", "Half-day coverage, digital photos", 1800.00m, 4.7m, "Standard" },
                    { 3, "High-quality photography with creative styles.", "contact@memorablemoments.com", "Miami", "Memorable Moments", "Full-day coverage, digital and printed photos", 2200.00m, 4.8m, "Luxury" },
                    { 4, "Affordable and reliable photography services.", "info@captureall.com", "San Francisco", "Capture All", "Basic coverage with digital photos", 1500.00m, 4.5m, "Standard" }
                });

            migrationBuilder.InsertData(
                table: "Venues",
                columns: new[] { "Id", "About", "Address", "Capacity", "Contact", "Location", "Name", "Price", "Rating", "Tier" },
                values: new object[,]
                {
                    { 1, "A luxurious venue with a grand view and ample space.", "123 Grand Ave, New York, NY", 500, "contact@grandballroom.com", "New York", "Grand Ballroom", 8000.00m, 4.9m, "Luxury" },
                    { 2, "Beautiful beachside venue with stunning ocean views.", "456 Beach Blvd, Miami, FL", 300, "info@oceanviewresort.com", "Miami", "Ocean View Resort", 6000.00m, 4.7m, "Premium" },
                    { 3, "A picturesque garden venue perfect for outdoor weddings.", "789 Garden St, San Francisco, CA", 250, "contact@elegantgardens.com", "San Francisco", "Elegant Gardens", 5500.00m, 4.8m, "Premium" },
                    { 4, "A chic, modern space for urban weddings.", "101 Loft Lane, Chicago, IL", 150, "info@modernloft.com", "Chicago", "Modern Loft", 4000.00m, 4.6m, "Standard" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_WeddingId",
                table: "Expenses",
                column: "WeddingId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_CateringId",
                table: "Services",
                column: "CateringId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_PhotographyId",
                table: "Services",
                column: "PhotographyId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_VenueId",
                table: "Services",
                column: "VenueId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_WeddingId",
                table: "Services",
                column: "WeddingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Caterings");

            migrationBuilder.DropTable(
                name: "Photographies");

            migrationBuilder.DropTable(
                name: "Venues");

            migrationBuilder.DropTable(
                name: "Weddings");
        }
    }
}
