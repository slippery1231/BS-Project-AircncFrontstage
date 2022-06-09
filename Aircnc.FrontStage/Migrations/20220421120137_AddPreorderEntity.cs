using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aircnc.FrontStage.Migrations
{
    public partial class AddPreorderEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PreOrders",
                columns: table => new
                {
                    PreOrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    RoomName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CkeckIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CkeckOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuestCount = table.Column<int>(type: "int", nullable: false),
                    OriginalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreOrders", x => x.PreOrderId);
                });

            migrationBuilder.UpdateData(
                table: "BankVerification",
                keyColumn: "BankVerificationId",
                keyValue: 1,
                columns: new[] { "ApplyTime", "CertificationTime" },
                values: new object[] { new DateTime(2022, 4, 21, 20, 1, 35, 855, DateTimeKind.Local).AddTicks(8030), new DateTime(2022, 4, 21, 20, 1, 35, 855, DateTimeKind.Local).AddTicks(8344) });

            migrationBuilder.UpdateData(
                table: "BankVerification",
                keyColumn: "BankVerificationId",
                keyValue: 2,
                columns: new[] { "ApplyTime", "CertificationTime" },
                values: new object[] { new DateTime(2022, 4, 21, 20, 1, 35, 855, DateTimeKind.Local).AddTicks(9154), new DateTime(2022, 4, 21, 20, 1, 35, 855, DateTimeKind.Local).AddTicks(9159) });

            migrationBuilder.UpdateData(
                table: "BankVerification",
                keyColumn: "BankVerificationId",
                keyValue: 3,
                columns: new[] { "ApplyTime", "CertificationTime" },
                values: new object[] { new DateTime(2022, 4, 21, 20, 1, 35, 855, DateTimeKind.Local).AddTicks(9162), new DateTime(2022, 4, 21, 20, 1, 35, 855, DateTimeKind.Local).AddTicks(9163) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "MessageId",
                keyValue: 1,
                column: "SendTime",
                value: new DateTime(2022, 4, 21, 20, 1, 35, 857, DateTimeKind.Local).AddTicks(1413));

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "MessageId",
                keyValue: 2,
                column: "SendTime",
                value: new DateTime(2022, 4, 21, 20, 1, 35, 857, DateTimeKind.Local).AddTicks(1716));

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "MessageId",
                keyValue: 3,
                column: "SendTime",
                value: new DateTime(2022, 4, 21, 20, 1, 35, 857, DateTimeKind.Local).AddTicks(1721));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreateTime",
                value: new DateTime(2022, 4, 21, 20, 1, 35, 856, DateTimeKind.Local).AddTicks(8146));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreateTime",
                value: new DateTime(2022, 4, 21, 20, 1, 35, 856, DateTimeKind.Local).AddTicks(9613));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreateTime",
                value: new DateTime(2022, 4, 21, 20, 1, 35, 856, DateTimeKind.Local).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 4,
                column: "CreateTime",
                value: new DateTime(2022, 4, 21, 20, 1, 35, 856, DateTimeKind.Local).AddTicks(9631));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 5,
                column: "CreateTime",
                value: new DateTime(2022, 4, 21, 20, 1, 35, 856, DateTimeKind.Local).AddTicks(9635));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 6,
                column: "CreateTime",
                value: new DateTime(2022, 4, 21, 20, 1, 35, 856, DateTimeKind.Local).AddTicks(9697));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 7,
                column: "CreateTime",
                value: new DateTime(2022, 4, 21, 20, 1, 35, 856, DateTimeKind.Local).AddTicks(9701));

            migrationBuilder.UpdateData(
                table: "UserVerification",
                keyColumn: "UserVerificationId",
                keyValue: 1,
                columns: new[] { "ApplyTime", "CertificationTime" },
                values: new object[] { new DateTime(2022, 4, 21, 20, 1, 35, 854, DateTimeKind.Local).AddTicks(2966), new DateTime(2022, 4, 21, 20, 1, 35, 855, DateTimeKind.Local).AddTicks(4161) });

            migrationBuilder.UpdateData(
                table: "UserVerification",
                keyColumn: "UserVerificationId",
                keyValue: 2,
                columns: new[] { "ApplyTime", "CertificationTime" },
                values: new object[] { new DateTime(2022, 4, 21, 20, 1, 35, 855, DateTimeKind.Local).AddTicks(5472), new DateTime(2022, 4, 21, 20, 1, 35, 855, DateTimeKind.Local).AddTicks(5479) });

            migrationBuilder.UpdateData(
                table: "UserVerification",
                keyColumn: "UserVerificationId",
                keyValue: 3,
                columns: new[] { "ApplyTime", "CertificationTime" },
                values: new object[] { new DateTime(2022, 4, 21, 20, 1, 35, 855, DateTimeKind.Local).AddTicks(5482), new DateTime(2022, 4, 21, 20, 1, 35, 855, DateTimeKind.Local).AddTicks(5483) });

            migrationBuilder.UpdateData(
                table: "UserVerification",
                keyColumn: "UserVerificationId",
                keyValue: 4,
                columns: new[] { "ApplyTime", "CertificationTime" },
                values: new object[] { new DateTime(2022, 4, 21, 20, 1, 35, 855, DateTimeKind.Local).AddTicks(5485), new DateTime(2022, 4, 21, 20, 1, 35, 855, DateTimeKind.Local).AddTicks(5486) });

            migrationBuilder.UpdateData(
                table: "UserVerification",
                keyColumn: "UserVerificationId",
                keyValue: 5,
                columns: new[] { "ApplyTime", "CertificationTime" },
                values: new object[] { new DateTime(2022, 4, 21, 20, 1, 35, 855, DateTimeKind.Local).AddTicks(5488), new DateTime(2022, 4, 21, 20, 1, 35, 855, DateTimeKind.Local).AddTicks(5489) });

            migrationBuilder.UpdateData(
                table: "UserVerification",
                keyColumn: "UserVerificationId",
                keyValue: 6,
                columns: new[] { "ApplyTime", "CertificationTime" },
                values: new object[] { new DateTime(2022, 4, 21, 20, 1, 35, 855, DateTimeKind.Local).AddTicks(5494), new DateTime(2022, 4, 21, 20, 1, 35, 855, DateTimeKind.Local).AddTicks(5495) });

            migrationBuilder.UpdateData(
                table: "UserVerification",
                keyColumn: "UserVerificationId",
                keyValue: 7,
                columns: new[] { "ApplyTime", "CertificationTime" },
                values: new object[] { new DateTime(2022, 4, 21, 20, 1, 35, 855, DateTimeKind.Local).AddTicks(5497), new DateTime(2022, 4, 21, 20, 1, 35, 855, DateTimeKind.Local).AddTicks(5498) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PreOrders");

            migrationBuilder.UpdateData(
                table: "BankVerification",
                keyColumn: "BankVerificationId",
                keyValue: 1,
                columns: new[] { "ApplyTime", "CertificationTime" },
                values: new object[] { new DateTime(2022, 4, 13, 19, 50, 45, 208, DateTimeKind.Local).AddTicks(8931), new DateTime(2022, 4, 13, 19, 50, 45, 208, DateTimeKind.Local).AddTicks(9167) });

            migrationBuilder.UpdateData(
                table: "BankVerification",
                keyColumn: "BankVerificationId",
                keyValue: 2,
                columns: new[] { "ApplyTime", "CertificationTime" },
                values: new object[] { new DateTime(2022, 4, 13, 19, 50, 45, 208, DateTimeKind.Local).AddTicks(9773), new DateTime(2022, 4, 13, 19, 50, 45, 208, DateTimeKind.Local).AddTicks(9777) });

            migrationBuilder.UpdateData(
                table: "BankVerification",
                keyColumn: "BankVerificationId",
                keyValue: 3,
                columns: new[] { "ApplyTime", "CertificationTime" },
                values: new object[] { new DateTime(2022, 4, 13, 19, 50, 45, 208, DateTimeKind.Local).AddTicks(9779), new DateTime(2022, 4, 13, 19, 50, 45, 208, DateTimeKind.Local).AddTicks(9780) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "MessageId",
                keyValue: 1,
                column: "SendTime",
                value: new DateTime(2022, 4, 13, 19, 50, 45, 210, DateTimeKind.Local).AddTicks(440));

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "MessageId",
                keyValue: 2,
                column: "SendTime",
                value: new DateTime(2022, 4, 13, 19, 50, 45, 210, DateTimeKind.Local).AddTicks(666));

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "MessageId",
                keyValue: 3,
                column: "SendTime",
                value: new DateTime(2022, 4, 13, 19, 50, 45, 210, DateTimeKind.Local).AddTicks(670));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreateTime",
                value: new DateTime(2022, 4, 13, 19, 50, 45, 209, DateTimeKind.Local).AddTicks(8030));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreateTime",
                value: new DateTime(2022, 4, 13, 19, 50, 45, 209, DateTimeKind.Local).AddTicks(9255));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreateTime",
                value: new DateTime(2022, 4, 13, 19, 50, 45, 209, DateTimeKind.Local).AddTicks(9262));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 4,
                column: "CreateTime",
                value: new DateTime(2022, 4, 13, 19, 50, 45, 209, DateTimeKind.Local).AddTicks(9265));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 5,
                column: "CreateTime",
                value: new DateTime(2022, 4, 13, 19, 50, 45, 209, DateTimeKind.Local).AddTicks(9268));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 6,
                column: "CreateTime",
                value: new DateTime(2022, 4, 13, 19, 50, 45, 209, DateTimeKind.Local).AddTicks(9271));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 7,
                column: "CreateTime",
                value: new DateTime(2022, 4, 13, 19, 50, 45, 209, DateTimeKind.Local).AddTicks(9275));

            migrationBuilder.UpdateData(
                table: "UserVerification",
                keyColumn: "UserVerificationId",
                keyValue: 1,
                columns: new[] { "ApplyTime", "CertificationTime" },
                values: new object[] { new DateTime(2022, 4, 13, 19, 50, 45, 207, DateTimeKind.Local).AddTicks(9959), new DateTime(2022, 4, 13, 19, 50, 45, 208, DateTimeKind.Local).AddTicks(6049) });

            migrationBuilder.UpdateData(
                table: "UserVerification",
                keyColumn: "UserVerificationId",
                keyValue: 2,
                columns: new[] { "ApplyTime", "CertificationTime" },
                values: new object[] { new DateTime(2022, 4, 13, 19, 50, 45, 208, DateTimeKind.Local).AddTicks(6937), new DateTime(2022, 4, 13, 19, 50, 45, 208, DateTimeKind.Local).AddTicks(6942) });

            migrationBuilder.UpdateData(
                table: "UserVerification",
                keyColumn: "UserVerificationId",
                keyValue: 3,
                columns: new[] { "ApplyTime", "CertificationTime" },
                values: new object[] { new DateTime(2022, 4, 13, 19, 50, 45, 208, DateTimeKind.Local).AddTicks(6944), new DateTime(2022, 4, 13, 19, 50, 45, 208, DateTimeKind.Local).AddTicks(6945) });

            migrationBuilder.UpdateData(
                table: "UserVerification",
                keyColumn: "UserVerificationId",
                keyValue: 4,
                columns: new[] { "ApplyTime", "CertificationTime" },
                values: new object[] { new DateTime(2022, 4, 13, 19, 50, 45, 208, DateTimeKind.Local).AddTicks(6946), new DateTime(2022, 4, 13, 19, 50, 45, 208, DateTimeKind.Local).AddTicks(6947) });

            migrationBuilder.UpdateData(
                table: "UserVerification",
                keyColumn: "UserVerificationId",
                keyValue: 5,
                columns: new[] { "ApplyTime", "CertificationTime" },
                values: new object[] { new DateTime(2022, 4, 13, 19, 50, 45, 208, DateTimeKind.Local).AddTicks(6948), new DateTime(2022, 4, 13, 19, 50, 45, 208, DateTimeKind.Local).AddTicks(6949) });

            migrationBuilder.UpdateData(
                table: "UserVerification",
                keyColumn: "UserVerificationId",
                keyValue: 6,
                columns: new[] { "ApplyTime", "CertificationTime" },
                values: new object[] { new DateTime(2022, 4, 13, 19, 50, 45, 208, DateTimeKind.Local).AddTicks(6950), new DateTime(2022, 4, 13, 19, 50, 45, 208, DateTimeKind.Local).AddTicks(6951) });

            migrationBuilder.UpdateData(
                table: "UserVerification",
                keyColumn: "UserVerificationId",
                keyValue: 7,
                columns: new[] { "ApplyTime", "CertificationTime" },
                values: new object[] { new DateTime(2022, 4, 13, 19, 50, 45, 208, DateTimeKind.Local).AddTicks(6953), new DateTime(2022, 4, 13, 19, 50, 45, 208, DateTimeKind.Local).AddTicks(6954) });
        }
    }
}
