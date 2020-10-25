using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eTransport.WebAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    CountryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Acronym = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.CountryID);
                });

            migrationBuilder.CreateTable(
                name: "VehicleDetails",
                columns: table => new
                {
                    VehicleDetailsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaxHeight = table.Column<double>(nullable: false),
                    MaxWeight = table.Column<double>(nullable: false),
                    MaxLength = table.Column<double>(nullable: false),
                    MaxWidth = table.Column<double>(nullable: false),
                    Price_per_km = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleDetails", x => x.VehicleDetailsID);
                });

            migrationBuilder.CreateTable(
                name: "VehicleModel",
                columns: table => new
                {
                    VehicleModelID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleModel", x => x.VehicleModelID);
                });

            migrationBuilder.CreateTable(
                name: "VehicleType",
                columns: table => new
                {
                    VehicleTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleType", x => x.VehicleTypeID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    PostalNumber = table.Column<string>(nullable: true),
                    CountryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.CityID);
                    table.ForeignKey(
                        name: "FK_City_Country_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Country",
                        principalColumn: "CountryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CityID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressID);
                    table.ForeignKey(
                        name: "FK_Address_City_CityID",
                        column: x => x.CityID,
                        principalTable: "City",
                        principalColumn: "CityID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    AddressID = table.Column<int>(nullable: true),
                    SignalRToken = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    LastActiveAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Address_AddressID",
                        column: x => x.AddressID,
                        principalTable: "Address",
                        principalColumn: "AddressID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carrier",
                columns: table => new
                {
                    CarrierID = table.Column<int>(nullable: false),
                    CarrierName = table.Column<string>(nullable: true),
                    CarrierBusinessEmail = table.Column<string>(nullable: true),
                    DriverLicenceNumber = table.Column<string>(nullable: true),
                    BusinessNumber = table.Column<string>(nullable: true),
                    StartupPrice = table.Column<decimal>(nullable: false),
                    Image = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrier", x => x.CarrierID);
                    table.ForeignKey(
                        name: "FK_Carrier_AspNetUsers_CarrierID",
                        column: x => x.CarrierID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ClientID = table.Column<int>(nullable: false),
                    JMBG = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClientID);
                    table.ForeignKey(
                        name: "FK_Client_AspNetUsers_ClientID",
                        column: x => x.ClientID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MessageHeader",
                columns: table => new
                {
                    MessageHeaderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromID = table.Column<int>(nullable: false),
                    ToID = table.Column<int>(nullable: false),
                    Sent = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageHeader", x => x.MessageHeaderID);
                    table.ForeignKey(
                        name: "FK_MessageHeader_AspNetUsers_FromID",
                        column: x => x.FromID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MessageHeader_AspNetUsers_ToID",
                        column: x => x.ToID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ExtraServices",
                columns: table => new
                {
                    ExtraServicesID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    CarrierID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtraServices", x => x.ExtraServicesID);
                    table.ForeignKey(
                        name: "FK_ExtraServices_Carrier_CarrierID",
                        column: x => x.CarrierID,
                        principalTable: "Carrier",
                        principalColumn: "CarrierID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    VehicleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicencePlate = table.Column<string>(nullable: true),
                    YearOfManufacture = table.Column<DateTime>(nullable: false),
                    SeatingCapacity = table.Column<int>(nullable: false),
                    TrunkVolume = table.Column<double>(nullable: false),
                    Image = table.Column<byte[]>(nullable: true),
                    CarrierID = table.Column<int>(nullable: false),
                    VehicleTypeID = table.Column<int>(nullable: false),
                    VehicleModelID = table.Column<int>(nullable: false),
                    VehicleDetailsID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.VehicleID);
                    table.ForeignKey(
                        name: "FK_Vehicle_Carrier_CarrierID",
                        column: x => x.CarrierID,
                        principalTable: "Carrier",
                        principalColumn: "CarrierID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicle_VehicleDetails_VehicleDetailsID",
                        column: x => x.VehicleDetailsID,
                        principalTable: "VehicleDetails",
                        principalColumn: "VehicleDetailsID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vehicle_VehicleModel_VehicleModelID",
                        column: x => x.VehicleModelID,
                        principalTable: "VehicleModel",
                        principalColumn: "VehicleModelID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicle_VehicleType_VehicleTypeID",
                        column: x => x.VehicleTypeID,
                        principalTable: "VehicleType",
                        principalColumn: "VehicleTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cargo",
                columns: table => new
                {
                    CargoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Weight = table.Column<double>(nullable: false),
                    MaxHeight = table.Column<double>(nullable: false),
                    MaxWidth = table.Column<double>(nullable: false),
                    Image = table.Column<byte[]>(nullable: true),
                    IsUsed = table.Column<bool>(nullable: false),
                    ClientID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargo", x => x.CargoID);
                    table.ForeignKey(
                        name: "FK_Cargo_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RatingCarrier",
                columns: table => new
                {
                    RatingCarrierID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<float>(nullable: false),
                    ClientID = table.Column<int>(nullable: false),
                    CarrierID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RatingCarrier", x => x.RatingCarrierID);
                    table.ForeignKey(
                        name: "FK_RatingCarrier_Carrier_CarrierID",
                        column: x => x.CarrierID,
                        principalTable: "Carrier",
                        principalColumn: "CarrierID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RatingCarrier_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    MessageID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(nullable: true),
                    SendAt = table.Column<DateTime>(nullable: false),
                    MessageHeaderID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.MessageID);
                    table.ForeignKey(
                        name: "FK_Message_MessageHeader_MessageHeaderID",
                        column: x => x.MessageHeaderID,
                        principalTable: "MessageHeader",
                        principalColumn: "MessageHeaderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Freight",
                columns: table => new
                {
                    FreightID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AcceptDate = table.Column<DateTime>(nullable: true),
                    TransportDate = table.Column<DateTime>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Distance = table.Column<double>(nullable: true),
                    Finished = table.Column<bool>(nullable: true),
                    IsRated = table.Column<bool>(nullable: true),
                    IsPayed = table.Column<bool>(nullable: true),
                    ClientAccepted = table.Column<bool>(nullable: true),
                    CarrierID = table.Column<int>(nullable: false),
                    VehicleID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Freight", x => x.FreightID);
                    table.ForeignKey(
                        name: "FK_Freight_Carrier_CarrierID",
                        column: x => x.CarrierID,
                        principalTable: "Carrier",
                        principalColumn: "CarrierID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Freight_Vehicle_VehicleID",
                        column: x => x.VehicleID,
                        principalTable: "Vehicle",
                        principalColumn: "VehicleID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CargoReservation",
                columns: table => new
                {
                    CargoReservationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartLocation = table.Column<string>(nullable: true),
                    EndLocation = table.Column<string>(nullable: true),
                    Accepted = table.Column<bool>(nullable: false),
                    StartDateTransport = table.Column<DateTime>(nullable: false),
                    EndDateTransport = table.Column<DateTime>(nullable: false),
                    ClientID = table.Column<int>(nullable: false),
                    FreightID = table.Column<int>(nullable: true),
                    ExtraServicesID = table.Column<int>(nullable: true),
                    CargoID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargoReservation", x => x.CargoReservationID);
                    table.ForeignKey(
                        name: "FK_CargoReservation_Cargo_CargoID",
                        column: x => x.CargoID,
                        principalTable: "Cargo",
                        principalColumn: "CargoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CargoReservation_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CargoReservation_ExtraServices_ExtraServicesID",
                        column: x => x.ExtraServicesID,
                        principalTable: "ExtraServices",
                        principalColumn: "ExtraServicesID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CargoReservation_Freight_FreightID",
                        column: x => x.FreightID,
                        principalTable: "Freight",
                        principalColumn: "FreightID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CommentRating",
                columns: table => new
                {
                    CommentRatingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<float>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    ClientID = table.Column<int>(nullable: false),
                    FreightID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentRating", x => x.CommentRatingID);
                    table.ForeignKey(
                        name: "FK_CommentRating_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommentRating_Freight_FreightID",
                        column: x => x.FreightID,
                        principalTable: "Freight",
                        principalColumn: "FreightID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_CityID",
                table: "Address",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AddressID",
                table: "AspNetUsers",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cargo_ClientID",
                table: "Cargo",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_CargoReservation_CargoID",
                table: "CargoReservation",
                column: "CargoID");

            migrationBuilder.CreateIndex(
                name: "IX_CargoReservation_ClientID",
                table: "CargoReservation",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_CargoReservation_ExtraServicesID",
                table: "CargoReservation",
                column: "ExtraServicesID");

            migrationBuilder.CreateIndex(
                name: "IX_CargoReservation_FreightID",
                table: "CargoReservation",
                column: "FreightID");

            migrationBuilder.CreateIndex(
                name: "IX_City_CountryID",
                table: "City",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_CommentRating_ClientID",
                table: "CommentRating",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_CommentRating_FreightID",
                table: "CommentRating",
                column: "FreightID");

            migrationBuilder.CreateIndex(
                name: "IX_ExtraServices_CarrierID",
                table: "ExtraServices",
                column: "CarrierID");

            migrationBuilder.CreateIndex(
                name: "IX_Freight_CarrierID",
                table: "Freight",
                column: "CarrierID");

            migrationBuilder.CreateIndex(
                name: "IX_Freight_VehicleID",
                table: "Freight",
                column: "VehicleID");

            migrationBuilder.CreateIndex(
                name: "IX_Message_MessageHeaderID",
                table: "Message",
                column: "MessageHeaderID");

            migrationBuilder.CreateIndex(
                name: "IX_MessageHeader_FromID",
                table: "MessageHeader",
                column: "FromID");

            migrationBuilder.CreateIndex(
                name: "IX_MessageHeader_ToID",
                table: "MessageHeader",
                column: "ToID");

            migrationBuilder.CreateIndex(
                name: "IX_RatingCarrier_CarrierID",
                table: "RatingCarrier",
                column: "CarrierID");

            migrationBuilder.CreateIndex(
                name: "IX_RatingCarrier_ClientID",
                table: "RatingCarrier",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_CarrierID",
                table: "Vehicle",
                column: "CarrierID");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_VehicleDetailsID",
                table: "Vehicle",
                column: "VehicleDetailsID");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_VehicleModelID",
                table: "Vehicle",
                column: "VehicleModelID");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_VehicleTypeID",
                table: "Vehicle",
                column: "VehicleTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CargoReservation");

            migrationBuilder.DropTable(
                name: "CommentRating");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "RatingCarrier");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Cargo");

            migrationBuilder.DropTable(
                name: "ExtraServices");

            migrationBuilder.DropTable(
                name: "Freight");

            migrationBuilder.DropTable(
                name: "MessageHeader");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "Carrier");

            migrationBuilder.DropTable(
                name: "VehicleDetails");

            migrationBuilder.DropTable(
                name: "VehicleModel");

            migrationBuilder.DropTable(
                name: "VehicleType");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
