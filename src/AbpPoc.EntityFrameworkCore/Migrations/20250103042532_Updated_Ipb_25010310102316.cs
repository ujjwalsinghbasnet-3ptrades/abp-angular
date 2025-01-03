using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AbpPoc.Migrations
{
    /// <inheritdoc />
    public partial class Updated_Ipb_25010310102316 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppIpbs_AppParts_relatedPart",
                table: "AppIpbs");

            migrationBuilder.DropForeignKey(
                name: "FK_AppIpbs_AppParts_sourcePart",
                table: "AppIpbs");

            migrationBuilder.DropIndex(
                name: "IX_AppIpbs_relatedPart",
                table: "AppIpbs");

            migrationBuilder.DropIndex(
                name: "IX_AppIpbs_sourcePart",
                table: "AppIpbs");

            migrationBuilder.DropColumn(
                name: "ipbIndex",
                table: "AppIpbs");

            migrationBuilder.DropColumn(
                name: "relatedPart",
                table: "AppIpbs");

            migrationBuilder.DropColumn(
                name: "sourcePart",
                table: "AppIpbs");

            migrationBuilder.AlterColumn<string>(
                name: "toNumber",
                table: "AppIpbs",
                type: "character varying(512)",
                maxLength: 512,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(32)",
                oldMaxLength: 32,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "sourceId",
                table: "AppIpbs",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<Guid>(
                name: "relatedId",
                table: "AppIpbs",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "figureNumber",
                table: "AppIpbs",
                type: "character varying(32)",
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256);

            migrationBuilder.CreateIndex(
                name: "IX_AppIpbs_relatedId",
                table: "AppIpbs",
                column: "relatedId");

            migrationBuilder.CreateIndex(
                name: "IX_AppIpbs_sourceId",
                table: "AppIpbs",
                column: "sourceId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppIpbs_AppParts_relatedId",
                table: "AppIpbs",
                column: "relatedId",
                principalTable: "AppParts",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_AppIpbs_AppParts_sourceId",
                table: "AppIpbs",
                column: "sourceId",
                principalTable: "AppParts",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppIpbs_AppParts_relatedId",
                table: "AppIpbs");

            migrationBuilder.DropForeignKey(
                name: "FK_AppIpbs_AppParts_sourceId",
                table: "AppIpbs");

            migrationBuilder.DropIndex(
                name: "IX_AppIpbs_relatedId",
                table: "AppIpbs");

            migrationBuilder.DropIndex(
                name: "IX_AppIpbs_sourceId",
                table: "AppIpbs");

            migrationBuilder.AlterColumn<string>(
                name: "toNumber",
                table: "AppIpbs",
                type: "character varying(32)",
                maxLength: 32,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(512)",
                oldMaxLength: 512,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "sourceId",
                table: "AppIpbs",
                type: "uuid",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "relatedId",
                table: "AppIpbs",
                type: "uuid",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "figureNumber",
                table: "AppIpbs",
                type: "character varying(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(32)",
                oldMaxLength: 32);

            migrationBuilder.AddColumn<string>(
                name: "ipbIndex",
                table: "AppIpbs",
                type: "character varying(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "relatedPart",
                table: "AppIpbs",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "sourcePart",
                table: "AppIpbs",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AppPartTests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ExtraProperties = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    cageCode = table.Column<string>(type: "text", nullable: false),
                    distributionStatement = table.Column<string>(type: "text", nullable: false),
                    fsc = table.Column<string>(type: "text", nullable: true),
                    imageUrl = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: false),
                    niin = table.Column<string>(type: "text", nullable: true),
                    nsn = table.Column<string>(type: "text", nullable: true),
                    partNumber = table.Column<string>(type: "text", nullable: false),
                    smr = table.Column<string>(type: "text", nullable: true),
                    toNumber = table.Column<string>(type: "text", nullable: true),
                    uniqueId = table.Column<string>(type: "text", nullable: true),
                    uoc = table.Column<string>(type: "text", nullable: true),
                    wuc = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppPartTests", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppIpbs_relatedPart",
                table: "AppIpbs",
                column: "relatedPart");

            migrationBuilder.CreateIndex(
                name: "IX_AppIpbs_sourcePart",
                table: "AppIpbs",
                column: "sourcePart");

            migrationBuilder.AddForeignKey(
                name: "FK_AppIpbs_AppParts_relatedPart",
                table: "AppIpbs",
                column: "relatedPart",
                principalTable: "AppParts",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_AppIpbs_AppParts_sourcePart",
                table: "AppIpbs",
                column: "sourcePart",
                principalTable: "AppParts",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
