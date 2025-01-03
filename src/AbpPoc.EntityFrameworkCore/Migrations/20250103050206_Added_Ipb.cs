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
            migrationBuilder.DropTable(
                name: "AppPartTests");

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
                    figureName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    figureNumber = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    toNumber = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    indentureLevel = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: true),
                    sourceId = table.Column<Guid>(type: "uuid", nullable: true),
                    relatedId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppIpbs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppIpbs_AppParts_relatedId",
                        column: x => x.relatedId,
                        principalTable: "AppParts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_AppIpbs_AppParts_sourceId",
                        column: x => x.sourceId,
                        principalTable: "AppParts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppIpbs_relatedId",
                table: "AppIpbs",
                column: "relatedId");

            migrationBuilder.CreateIndex(
                name: "IX_AppIpbs_sourceId",
                table: "AppIpbs",
                column: "sourceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppIpbs");

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
        }
    }
}
