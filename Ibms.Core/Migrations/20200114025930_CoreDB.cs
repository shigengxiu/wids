using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ibms.Core.Migrations
{
    public partial class CoreDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApiModel",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Floor = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    IsControlArea = table.Column<bool>(nullable: false),
                    IsKeyArea = table.Column<bool>(nullable: false),
                    ParentAreaId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Area_Area_ParentAreaId",
                        column: x => x.ParentAreaId,
                        principalTable: "Area",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AuthGroup",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuthPermission",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    AuthorizeCode = table.Column<string>(nullable: true),
                    ResourceID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthPermission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuthUser",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    IsSuperuser = table.Column<bool>(nullable: false),
                    DateJoined = table.Column<DateTime>(nullable: false),
                    LastLogin = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    IsActived = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuthGroupPermission",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupId = table.Column<long>(nullable: true),
                    PermissionId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthGroupPermission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuthGroupPermission_AuthGroup_GroupId",
                        column: x => x.GroupId,
                        principalTable: "AuthGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AuthGroupPermission_AuthPermission_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "AuthPermission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AuthUserGroup",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(nullable: true),
                    GroupId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthUserGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuthUserGroup_AuthGroup_GroupId",
                        column: x => x.GroupId,
                        principalTable: "AuthGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AuthUserGroup_AuthUser_UserId",
                        column: x => x.UserId,
                        principalTable: "AuthUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AuthUserPermission",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(nullable: true),
                    PermissionId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthUserPermission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuthUserPermission_AuthPermission_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "AuthPermission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AuthUserPermission_AuthUser_UserId",
                        column: x => x.UserId,
                        principalTable: "AuthUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Area_ParentAreaId",
                table: "Area",
                column: "ParentAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthGroupPermission_GroupId",
                table: "AuthGroupPermission",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthGroupPermission_PermissionId",
                table: "AuthGroupPermission",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthUserGroup_GroupId",
                table: "AuthUserGroup",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthUserGroup_UserId",
                table: "AuthUserGroup",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthUserPermission_PermissionId",
                table: "AuthUserPermission",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthUserPermission_UserId",
                table: "AuthUserPermission",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApiModel");

            migrationBuilder.DropTable(
                name: "Area");

            migrationBuilder.DropTable(
                name: "AuthGroupPermission");

            migrationBuilder.DropTable(
                name: "AuthUserGroup");

            migrationBuilder.DropTable(
                name: "AuthUserPermission");

            migrationBuilder.DropTable(
                name: "AuthGroup");

            migrationBuilder.DropTable(
                name: "AuthPermission");

            migrationBuilder.DropTable(
                name: "AuthUser");
        }
    }
}
