using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AbpPoc.Migrations
{
    /// <inheritdoc />
    public partial class Added_PartTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppParts",
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
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    partNumber = table.Column<string>(type: "text", nullable: false),
                    cageCode = table.Column<string>(type: "text", nullable: false),
                    toNumber = table.Column<string>(type: "text", nullable: false),
                    distributionStatement = table.Column<string>(type: "text", nullable: true),
                    smr = table.Column<string>(type: "text", nullable: true),
                    niin = table.Column<string>(type: "text", nullable: true),
                    fsc = table.Column<string>(type: "text", nullable: true),
                    wuc = table.Column<string>(type: "text", nullable: true),
                    uoc = table.Column<string>(type: "text", nullable: true),
                    uniqueId = table.Column<string>(type: "text", nullable: true),
                    nsn = table.Column<string>(type: "text", nullable: false),
                    imageUrl = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppParts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppPartTests",
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
                    partNumber = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    cageCode = table.Column<string>(type: "text", nullable: false),
                    distributionStatement = table.Column<string>(type: "text", nullable: false),
                    toNumber = table.Column<string>(type: "text", nullable: true),
                    smr = table.Column<string>(type: "text", nullable: true),
                    niin = table.Column<string>(type: "text", nullable: true),
                    fsc = table.Column<string>(type: "text", nullable: true),
                    wuc = table.Column<string>(type: "text", nullable: true),
                    uoc = table.Column<string>(type: "text", nullable: true),
                    uniqueId = table.Column<string>(type: "text", nullable: true),
                    nsn = table.Column<string>(type: "text", nullable: true),
                    imageUrl = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppPartTests", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppParts");

            migrationBuilder.DropTable(
                name: "AppPartTests");
        }
    }
}
