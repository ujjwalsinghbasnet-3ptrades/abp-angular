using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AbpPoc.Migrations
{
    /// <inheritdoc />
    public partial class Added_Ipb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppIpbs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ExtraProperties = table.Column<string>(type: "text", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ipbIndex = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: false),
                    figureName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    figureNumber = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    toNumber = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    indentureLevel = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: true),
                    sourceId = table.Column<string>(type: "text", nullable: false),
                    relatedId = table.Column<string>(type: "text", nullable: false),
                    sourcePart = table.Column<Guid>(type: "uuid", nullable: true),
                    relatedPart = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppIpbs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppIpbs_AppParts_relatedPart",
                        column: x => x.relatedPart,
                        principalTable: "AppParts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_AppIpbs_AppParts_sourcePart",
                        column: x => x.sourcePart,
                        principalTable: "AppParts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppIpbs_relatedPart",
                table: "AppIpbs",
                column: "relatedPart");

            migrationBuilder.CreateIndex(
                name: "IX_AppIpbs_sourcePart",
                table: "AppIpbs",
                column: "sourcePart");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppIpbs");
        }
    }
}
