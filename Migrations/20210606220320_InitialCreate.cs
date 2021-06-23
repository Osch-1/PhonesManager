using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PhonesManager.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up( MigrationBuilder migrationBuilder )
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<int>( type: "int", nullable: false )
                        .Annotation( "SqlServer:Identity", "1, 1" ),
                    Name = table.Column<string>( type: "nvarchar(50)", maxLength: 50, nullable: false ),
                    Surname = table.Column<string>( type: "nvarchar(70)", maxLength: 70, nullable: true ),
                    Address = table.Column<string>( type: "nvarchar(100)", maxLength: 100, nullable: true ),
                    DateOfBirth = table.Column<DateTime>( type: "datetime2", nullable: false )
                },
                constraints: table =>
                {
                    table.PrimaryKey( "PK_Client", x => x.Id );
                } );

            migrationBuilder.CreateTable(
                name: "Package",
                columns: table => new
                {
                    Id = table.Column<int>( type: "int", nullable: false )
                        .Annotation( "SqlServer:Identity", "1, 1" ),
                    Name = table.Column<string>( type: "nvarchar(50)", maxLength: 50, nullable: false ),
                    IsActive = table.Column<bool>( type: "bit", nullable: false ),
                    Description = table.Column<string>( type: "nvarchar(300)", maxLength: 300, nullable: true ),
                    Price = table.Column<decimal>( type: "money", nullable: false )
                },
                constraints: table =>
                {
                    table.PrimaryKey( "PK_Package", x => x.Id );
                } );

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    Id = table.Column<int>( type: "int", nullable: false )
                        .Annotation( "SqlServer:Identity", "1, 1" ),
                    Name = table.Column<string>( type: "nvarchar(50)", maxLength: 50, nullable: false ),
                    IsActive = table.Column<bool>( type: "bit", nullable: false ),
                    Description = table.Column<string>( type: "nvarchar(300)", maxLength: 300, nullable: true ),
                    Price = table.Column<decimal>( type: "money", nullable: false )
                },
                constraints: table =>
                {
                    table.PrimaryKey( "PK_Service", x => x.Id );
                } );

            migrationBuilder.CreateTable(
                name: "Phone",
                columns: table => new
                {
                    Id = table.Column<int>( type: "int", nullable: false )
                        .Annotation( "SqlServer:Identity", "1, 1" ),
                    Number = table.Column<string>( type: "nvarchar(50)", maxLength: 50, nullable: false ),
                    ClientId = table.Column<int>( type: "int", nullable: false ),
                    ActivationDate = table.Column<DateTime>( type: "datetime2", nullable: false ),
                    DeactivationDate = table.Column<DateTime>( type: "datetime2", nullable: false )
                },
                constraints: table =>
                {
                    table.PrimaryKey( "PK_Phone", x => x.Id );
                    table.ForeignKey(
                        name: "FK_Phone_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade );
                } );

            migrationBuilder.CreateTable(
                name: "PackageService",
                columns: table => new
                {
                    PackagesId = table.Column<int>( type: "int", nullable: false ),
                    ServicesId = table.Column<int>( type: "int", nullable: false )
                },
                constraints: table =>
                {
                    table.PrimaryKey( "PK_PackageService", x => new { x.PackagesId, x.ServicesId } );
                    table.ForeignKey(
                        name: "FK_PackageService_Package_PackagesId",
                        column: x => x.PackagesId,
                        principalTable: "Package",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade );
                    table.ForeignKey(
                        name: "FK_PackageService_Service_ServicesId",
                        column: x => x.ServicesId,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade );
                } );

            migrationBuilder.CreateTable(
                name: "PackagePhone",
                columns: table => new
                {
                    PackagesId = table.Column<int>( type: "int", nullable: false ),
                    PhonesId = table.Column<int>( type: "int", nullable: false )
                },
                constraints: table =>
                {
                    table.PrimaryKey( "PK_PackagePhone", x => new { x.PackagesId, x.PhonesId } );
                    table.ForeignKey(
                        name: "FK_PackagePhone_Package_PackagesId",
                        column: x => x.PackagesId,
                        principalTable: "Package",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade );
                    table.ForeignKey(
                        name: "FK_PackagePhone_Phone_PhonesId",
                        column: x => x.PhonesId,
                        principalTable: "Phone",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade );
                } );

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    Id = table.Column<int>( type: "int", nullable: false )
                        .Annotation( "SqlServer:Identity", "1, 1" ),
                    PhoneId = table.Column<int>( type: "int", nullable: false ),
                    Date = table.Column<DateTime>( type: "datetime2", nullable: false ),
                    Worth = table.Column<decimal>( type: "money", nullable: false )
                },
                constraints: table =>
                {
                    table.PrimaryKey( "PK_Payment", x => x.Id );
                    table.ForeignKey(
                        name: "FK_Payment_Phone_PhoneId",
                        column: x => x.PhoneId,
                        principalTable: "Phone",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade );
                } );

            migrationBuilder.CreateTable(
                name: "PhoneService",
                columns: table => new
                {
                    PhonesId = table.Column<int>( type: "int", nullable: false ),
                    ServicesId = table.Column<int>( type: "int", nullable: false )
                },
                constraints: table =>
                {
                    table.PrimaryKey( "PK_PhoneService", x => new { x.PhonesId, x.ServicesId } );
                    table.ForeignKey(
                        name: "FK_PhoneService_Phone_PhonesId",
                        column: x => x.PhonesId,
                        principalTable: "Phone",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade );
                    table.ForeignKey(
                        name: "FK_PhoneService_Service_ServicesId",
                        column: x => x.ServicesId,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade );
                } );

            migrationBuilder.CreateIndex(
                name: "IX_PackagePhone_PhonesId",
                table: "PackagePhone",
                column: "PhonesId" );

            migrationBuilder.CreateIndex(
                name: "IX_PackageService_ServicesId",
                table: "PackageService",
                column: "ServicesId" );

            migrationBuilder.CreateIndex(
                name: "IX_Payment_PhoneId",
                table: "Payment",
                column: "PhoneId" );

            migrationBuilder.CreateIndex(
                name: "IX_Phone_ClientId",
                table: "Phone",
                column: "ClientId" );

            migrationBuilder.CreateIndex(
                name: "IX_PhoneService_ServicesId",
                table: "PhoneService",
                column: "ServicesId" );
        }

        protected override void Down( MigrationBuilder migrationBuilder )
        {
            migrationBuilder.DropTable(
                name: "PackagePhone" );

            migrationBuilder.DropTable(
                name: "PackageService" );

            migrationBuilder.DropTable(
                name: "Payment" );

            migrationBuilder.DropTable(
                name: "PhoneService" );

            migrationBuilder.DropTable(
                name: "Package" );

            migrationBuilder.DropTable(
                name: "Phone" );

            migrationBuilder.DropTable(
                name: "Service" );

            migrationBuilder.DropTable(
                name: "Client" );
        }
    }
}
