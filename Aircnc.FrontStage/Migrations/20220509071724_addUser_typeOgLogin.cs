using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aircnc.FrontStage.Migrations
{
    public partial class addUser_typeOgLogin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeOfLogin",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "BankVerification",
                keyColumn: "BankVerificationId",
                keyValue: 1,
                columns: new[] { "ApplyTime", "CertificationTime" },
                values: new object[] { new DateTime(2022, 5, 9, 15, 17, 22, 748, DateTimeKind.Local).AddTicks(2876), new DateTime(2022, 5, 9, 15, 17, 22, 748, DateTimeKind.Local).AddTicks(3220) });

            migrationBuilder.UpdateData(
                table: "BankVerification",
                keyColumn: "BankVerificationId",
                keyValue: 2,
                columns: new[] { "ApplyTime", "CertificationTime" },
                values: new object[] { new DateTime(2022, 5, 9, 15, 17, 22, 748, DateTimeKind.Local).AddTicks(4067), new DateTime(2022, 5, 9, 15, 17, 22, 748, DateTimeKind.Local).AddTicks(4071) });

            migrationBuilder.UpdateData(
                table: "BankVerification",
                keyColumn: "BankVerificationId",
                keyValue: 3,
                columns: new[] { "ApplyTime", "CertificationTime" },
                values: new object[] { new DateTime(2022, 5, 9, 15, 17, 22, 748, DateTimeKind.Local).AddTicks(4074), new DateTime(2022, 5, 9, 15, 17, 22, 748, DateTimeKind.Local).AddTicks(4075) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "MessageId",
                keyValue: 1,
                column: "SendTime",
                value: new DateTime(2022, 5, 9, 15, 17, 22, 749, DateTimeKind.Local).AddTicks(6346));

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "MessageId",
                keyValue: 2,
                column: "SendTime",
                value: new DateTime(2022, 5, 9, 15, 17, 22, 749, DateTimeKind.Local).AddTicks(6693));

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "MessageId",
                keyValue: 3,
                column: "SendTime",
                value: new DateTime(2022, 5, 9, 15, 17, 22, 749, DateTimeKind.Local).AddTicks(6698));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreateTime",
                value: new DateTime(2022, 5, 9, 15, 17, 22, 749, DateTimeKind.Local).AddTicks(2879));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreateTime",
                value: new DateTime(2022, 5, 9, 15, 17, 22, 749, DateTimeKind.Local).AddTicks(4378));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreateTime",
                value: new DateTime(2022, 5, 9, 15, 17, 22, 749, DateTimeKind.Local).AddTicks(4470));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 4,
                column: "CreateTime",
                value: new DateTime(2022, 5, 9, 15, 17, 22, 749, DateTimeKind.Local).AddTicks(4477));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 5,
                column: "CreateTime",
                value: new DateTime(2022, 5, 9, 15, 17, 22, 749, DateTimeKind.Local).AddTicks(4482));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 6,
                column: "CreateTime",
                value: new DateTime(2022, 5, 9, 15, 17, 22, 749, DateTimeKind.Local).AddTicks(4486));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 7,
                column: "CreateTime",
                value: new DateTime(2022, 5, 9, 15, 17, 22, 749, DateTimeKind.Local).AddTicks(4491));

            migrationBuilder.UpdateData(
                table: "UserVerification",
                keyColumn: "UserVerificationId",
                keyValue: 1,
                columns: new[] { "ApplyTime", "CertificationTime" },
                values: new object[] { new DateTime(2022, 5, 9, 15, 17, 22, 745, DateTimeKind.Local).AddTicks(6126), new DateTime(2022, 5, 9, 15, 17, 22, 747, DateTimeKind.Local).AddTicks(8767) });

            migrationBuilder.UpdateData(
                table: "UserVerification",
                keyColumn: "UserVerificationId",
                keyValue: 2,
                columns: new[] { "ApplyTime", "CertificationTime" },
                values: new object[] { new DateTime(2022, 5, 9, 15, 17, 22, 748, DateTimeKind.Local).AddTicks(235), new DateTime(2022, 5, 9, 15, 17, 22, 748, DateTimeKind.Local).AddTicks(241) });

            migrationBuilder.UpdateData(
                table: "UserVerification",
                keyColumn: "UserVerificationId",
                keyValue: 3,
                columns: new[] { "ApplyTime", "CertificationTime" },
                values: new object[] { new DateTime(2022, 5, 9, 15, 17, 22, 748, DateTimeKind.Local).AddTicks(245), new DateTime(2022, 5, 9, 15, 17, 22, 748, DateTimeKind.Local).AddTicks(247) });

            migrationBuilder.UpdateData(
                table: "UserVerification",
                keyColumn: "UserVerificationId",
                keyValue: 4,
                columns: new[] { "ApplyTime", "CertificationTime" },
                values: new object[] { new DateTime(2022, 5, 9, 15, 17, 22, 748, DateTimeKind.Local).AddTicks(250), new DateTime(2022, 5, 9, 15, 17, 22, 748, DateTimeKind.Local).AddTicks(251) });

            migrationBuilder.UpdateData(
                table: "UserVerification",
                keyColumn: "UserVerificationId",
                keyValue: 5,
                columns: new[] { "ApplyTime", "CertificationTime" },
                values: new object[] { new DateTime(2022, 5, 9, 15, 17, 22, 748, DateTimeKind.Local).AddTicks(253), new DateTime(2022, 5, 9, 15, 17, 22, 748, DateTimeKind.Local).AddTicks(255) });

            migrationBuilder.UpdateData(
                table: "UserVerification",
                keyColumn: "UserVerificationId",
                keyValue: 6,
                columns: new[] { "ApplyTime", "CertificationTime" },
                values: new object[] { new DateTime(2022, 5, 9, 15, 17, 22, 748, DateTimeKind.Local).AddTicks(257), new DateTime(2022, 5, 9, 15, 17, 22, 748, DateTimeKind.Local).AddTicks(258) });

            migrationBuilder.UpdateData(
                table: "UserVerification",
                keyColumn: "UserVerificationId",
                keyValue: 7,
                columns: new[] { "ApplyTime", "CertificationTime" },
                values: new object[] { new DateTime(2022, 5, 9, 15, 17, 22, 748, DateTimeKind.Local).AddTicks(261), new DateTime(2022, 5, 9, 15, 17, 22, 748, DateTimeKind.Local).AddTicks(262) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeOfLogin",
                table: "User");

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
    }
}
