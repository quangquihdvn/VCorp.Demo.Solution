using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VCorp.Demo.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Zone",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ShortUrl = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    SortOrder = table.Column<int>(nullable: true),
                    ParentId = table.Column<int>(nullable: true),
                    Invisibled = table.Column<bool>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    AllowComment = table.Column<bool>(nullable: true),
                    Domain = table.Column<string>(maxLength: 200, nullable: true),
                    UseForFunnyNews = table.Column<bool>(nullable: false),
                    AvatarCover = table.Column<string>(maxLength: 500, nullable: true),
                    IsHot = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zone", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NewsContent",
                columns: table => new
                {
                    NewsId = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(maxLength: 250, nullable: true),
                    Sapo = table.Column<string>(nullable: true),
                    Avatar = table.Column<string>(maxLength: 500, nullable: true),
                    Avatar2 = table.Column<string>(maxLength: 500, nullable: true),
                    Avatar3 = table.Column<string>(maxLength: 500, nullable: true),
                    Avatar4 = table.Column<string>(maxLength: 500, nullable: true),
                    Avatar5 = table.Column<string>(maxLength: 500, nullable: true),
                    Body = table.Column<string>(type: "ntext", nullable: true),
                    PublishedDate = table.Column<DateTime>(nullable: false),
                    Source = table.Column<string>(maxLength: 100, nullable: true),
                    NewsRelation = table.Column<string>(nullable: true),
                    Tags = table.Column<string>(nullable: true),
                    Author = table.Column<string>(maxLength: 500, nullable: true),
                    TagPrimary = table.Column<string>(maxLength: 500, nullable: true),
                    Url = table.Column<string>(maxLength: 500, nullable: true),
                    ZoneId = table.Column<int>(nullable: false),
                    OriginalId = table.Column<long>(type: "bigint", nullable: false),
                    TagItem = table.Column<string>(maxLength: 1000, nullable: true),
                    SubTitle = table.Column<string>(maxLength: 250, nullable: true),
                    InitSapo = table.Column<string>(maxLength: 500, nullable: true),
                    InterviewId = table.Column<int>(nullable: true),
                    OriginalUrl = table.Column<string>(maxLength: 500, nullable: true),
                    Type = table.Column<int>(nullable: true),
                    AvatarDesc = table.Column<string>(maxLength: 500, nullable: true),
                    NewsType = table.Column<short>(nullable: true),
                    RollingNewsId = table.Column<int>(nullable: true),
                    AdStore = table.Column<bool>(nullable: true),
                    AdStoreUrl = table.Column<string>(maxLength: 500, nullable: true),
                    TagSubTitleId = table.Column<int>(nullable: true),
                    ThreadId = table.Column<int>(nullable: true),
                    Position = table.Column<int>(nullable: true),
                    PrPosition = table.Column<int>(nullable: true),
                    IsOnMobile = table.Column<bool>(nullable: true),
                    UseTemplate = table.Column<bool>(nullable: true),
                    LocationType = table.Column<int>(nullable: true),
                    ExpiredDate = table.Column<DateTime>(nullable: true),
                    SourceUrl = table.Column<string>(maxLength: 500, nullable: true),
                    ParentNewsId = table.Column<long>(type: "bigint", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsContent", x => x.NewsId);
                    table.ForeignKey(
                        name: "FK_NewsContent_Zone_ZoneId",
                        column: x => x.ZoneId,
                        principalTable: "Zone",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NewsExtension",
                columns: table => new
                {
                    NewsId = table.Column<long>(type: "bigint", nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsExtension", x => new { x.NewsId, x.Type });
                    table.ForeignKey(
                        name: "FK_NewsExtension_NewsContent_NewsId",
                        column: x => x.NewsId,
                        principalTable: "NewsContent",
                        principalColumn: "NewsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NewsContent_ZoneId",
                table: "NewsContent",
                column: "ZoneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewsExtension");

            migrationBuilder.DropTable(
                name: "NewsContent");

            migrationBuilder.DropTable(
                name: "Zone");
        }
    }
}
