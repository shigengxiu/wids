using Microsoft.EntityFrameworkCore.Migrations;

namespace Ibms.Core.Migrations
{
    public partial class AddDeviceType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "TypeId",
                table: "BaseDevices",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DeviceType",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaseDevices_TypeId",
                table: "BaseDevices",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseDevices_DeviceType_TypeId",
                table: "BaseDevices",
                column: "TypeId",
                principalTable: "DeviceType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseDevices_DeviceType_TypeId",
                table: "BaseDevices");

            migrationBuilder.DropTable(
                name: "DeviceType");

            migrationBuilder.DropIndex(
                name: "IX_BaseDevices_TypeId",
                table: "BaseDevices");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "BaseDevices");
        }
    }
}
