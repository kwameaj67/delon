using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DelonLLC.Migrations
{
    public partial class firstmigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customer_cards",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    customer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    status = table.Column<string>(type: "character varying", nullable: true),
                    card_type = table.Column<string>(type: "character varying", nullable: false),
                    card_number = table.Column<string>(type: "character varying", nullable: true),
                    card_description = table.Column<string>(type: "character varying", nullable: true),
                    card_holder = table.Column<string>(type: "character varying", nullable: true),
                    security_code = table.Column<int>(type: "integer", nullable: true),
                    expiry_date = table.Column<string>(type: "character varying", nullable: true),
                    mobile_network = table.Column<string>(type: "character varying", nullable: true),
                    mobile_number = table.Column<string>(type: "character varying", nullable: true),
                    bank_name = table.Column<string>(type: "character varying", nullable: true),
                    country = table.Column<string>(type: "character varying", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer_cards", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customer_cards");
        }
    }
}
