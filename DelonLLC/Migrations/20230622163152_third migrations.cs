using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DelonLLC.Migrations
{
    public partial class thirdmigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "customer_cards",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "mobile_number",
                table: "customer_cards",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "mobile_network",
                table: "customer_cards",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "expiry_date",
                table: "customer_cards",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "country",
                table: "customer_cards",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying");

            migrationBuilder.AlterColumn<string>(
                name: "card_type",
                table: "customer_cards",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying");

            migrationBuilder.AlterColumn<string>(
                name: "card_number",
                table: "customer_cards",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "card_holder",
                table: "customer_cards",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "card_description",
                table: "customer_cards",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "bank_name",
                table: "customer_cards",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "customer_cards",
                type: "character varying",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "mobile_number",
                table: "customer_cards",
                type: "character varying",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "mobile_network",
                table: "customer_cards",
                type: "character varying",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "expiry_date",
                table: "customer_cards",
                type: "character varying",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "country",
                table: "customer_cards",
                type: "character varying",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "card_type",
                table: "customer_cards",
                type: "character varying",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "card_number",
                table: "customer_cards",
                type: "character varying",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "card_holder",
                table: "customer_cards",
                type: "character varying",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "card_description",
                table: "customer_cards",
                type: "character varying",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "bank_name",
                table: "customer_cards",
                type: "character varying",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
