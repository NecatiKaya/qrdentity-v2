using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Qrdentity.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class MFRegistrationRefactor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MultiFactorRegistrations",
                schema: "public");

            migrationBuilder.DropColumn(
                name: "UsedEmail",
                schema: "public",
                table: "MultiFactorRegistrationsHistory");

            migrationBuilder.DropColumn(
                name: "UsedMobileNumber",
                schema: "public",
                table: "MultiFactorRegistrationsHistory");

            migrationBuilder.DropColumn(
                name: "MultiFactorConfigurationId",
                schema: "public",
                table: "MultiFactorRegistrationSettings");

            migrationBuilder.RenameColumn(
                name: "MultiFactorRegistrationId",
                schema: "public",
                table: "MultiFactorRegistrationSettings",
                newName: "MultiFactorSettingId");

            migrationBuilder.AddColumn<string>(
                name: "MultiFactorSettingId",
                schema: "public",
                table: "MultiFactorRegistrationsHistory",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CodeToAuthenticate",
                schema: "public",
                table: "MultiFactorRegistrationSettings",
                type: "char(6)",
                maxLength: 6,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsAuthenticated",
                schema: "public",
                table: "MultiFactorRegistrationSettings",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "MultiFactorRegistrationGroupId",
                schema: "public",
                table: "MultiFactorRegistrationSettings",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Value",
                schema: "public",
                table: "MultiFactorRegistrationSettings",
                type: "varchar(100)",
                unicode: false,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "MultiFactorRegistrationGroups",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultiFactorRegistrationGroups", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MultiFactorRegistrationGroups",
                schema: "public");

            migrationBuilder.DropColumn(
                name: "MultiFactorSettingId",
                schema: "public",
                table: "MultiFactorRegistrationsHistory");

            migrationBuilder.DropColumn(
                name: "CodeToAuthenticate",
                schema: "public",
                table: "MultiFactorRegistrationSettings");

            migrationBuilder.DropColumn(
                name: "IsAuthenticated",
                schema: "public",
                table: "MultiFactorRegistrationSettings");

            migrationBuilder.DropColumn(
                name: "MultiFactorRegistrationGroupId",
                schema: "public",
                table: "MultiFactorRegistrationSettings");

            migrationBuilder.DropColumn(
                name: "Value",
                schema: "public",
                table: "MultiFactorRegistrationSettings");

            migrationBuilder.RenameColumn(
                name: "MultiFactorSettingId",
                schema: "public",
                table: "MultiFactorRegistrationSettings",
                newName: "MultiFactorRegistrationId");

            migrationBuilder.AddColumn<string>(
                name: "UsedEmail",
                schema: "public",
                table: "MultiFactorRegistrationsHistory",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsedMobileNumber",
                schema: "public",
                table: "MultiFactorRegistrationsHistory",
                type: "char(12)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MultiFactorConfigurationId",
                schema: "public",
                table: "MultiFactorRegistrationSettings",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "MultiFactorRegistrations",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CodeToAuthenticate = table.Column<string>(type: "char(6)", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    EmailToSendCode = table.Column<string>(type: "varchar(50)", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    IsAuthenticated = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    MobileNumberToSendCode = table.Column<string>(type: "char(12)", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultiFactorRegistrations", x => x.Id);
                });
        }
    }
}
