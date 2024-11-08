using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hx.Abp.WeekDay.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HXWEEKDAYS",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    YEAR = table.Column<int>(type: "integer", precision: 4, nullable: false),
                    MONTH = table.Column<int>(type: "integer", precision: 2, nullable: false),
                    DAY = table.Column<int>(type: "integer", precision: 2, nullable: false),
                    ADJUSTMENTDATE = table.Column<DateTime>(type: "date", nullable: false),
                    DESCRIPTION = table.Column<string>(type: "text", precision: 200, nullable: true),
                    ADJUSTMENTTYPE = table.Column<int>(type: "integer", precision: 1, nullable: false),
                    ADJUSTMENTORGANIZATION = table.Column<int>(type: "integer", precision: 1, nullable: false),
                    CREATIONTIME = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CREATORID = table.Column<Guid>(type: "uuid", nullable: true),
                    LASTMODIFICATIONTIME = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LASTMODIFIERID = table.Column<Guid>(type: "uuid", nullable: true),
                    ISDELETED = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DELETERID = table.Column<Guid>(type: "uuid", nullable: true),
                    DELETIONTIME = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HXWEEKDAYS", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HXWEEKDAYS");
        }
    }
}
