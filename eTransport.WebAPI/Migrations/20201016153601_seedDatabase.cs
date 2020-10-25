using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.IO;

namespace eTransport.WebAPI.Migrations
{
    public partial class seedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sqlFile = Path.Combine(AppContext.BaseDirectory, @"script.sql");
            migrationBuilder.Sql(File.ReadAllText(sqlFile));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
