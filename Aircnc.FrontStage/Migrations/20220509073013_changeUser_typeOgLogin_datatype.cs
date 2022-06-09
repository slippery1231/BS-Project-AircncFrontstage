using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aircnc.FrontStage.Migrations
{
    public partial class changeUser_typeOgLogin_datatype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BankVerification",
                keyColumn: "BankVerificationId",
                keyValue: 1,
                columns: new[] { "ApplyTime", "CertificationTime" },
                values: new object[] { new DateTime(2022, 5, 9, 15, 30, 11, 498, DateTimeKind.Local).AddTicks(96), new DateTime(2022, 5, 9, 15, 30, 11, 498, DateTimeKind.Local).AddTicks(457) });

            migrationBuilder.UpdateData(
                table: "BankVerification",
                keyColumn: "BankVerificationId",
                keyValue: 2,
                columns: new[] { "ApplyTime", "CertificationTime" },
                values: new object[] { new DateTime(2022, 5, 9, 15, 30, 11, 498, DateTimeKind.Local).AddTicks(1369), new DateTime(2022, 5, 9, 15, 30, 11, 498, DateTimeKind.Local).AddTicks(1374) });

            migrationBuilder.UpdateData(
                table: "BankVerification",
                keyColumn: "BankVerificationId",
                keyValue: 3,
                columns: new[] { "ApplyTime", "CertificationTime" },
                values: new object[] { new DateTime(2022, 5, 9, 15, 30, 11, 498, DateTimeKind.Local).AddTicks(1377), new DateTime(2022, 5, 9, 15, 30, 11, 498, DateTimeKind.Local).AddTicks(1379) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "MessageId",
                keyValue: 1,
                column: "SendTime",
                value: new DateTime(2022, 5, 9, 15, 30, 11, 499, DateTimeKind.Local).AddTicks(4400));

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "MessageId",
                keyValue: 2,
                column: "SendTime",
                value: new DateTime(2022, 5, 9, 15, 30, 11, 499, DateTimeKind.Local).AddTicks(4731));

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "MessageId",
                keyValue: 3,
                column: "SendTime",
                value: new DateTime(2022, 5, 9, 15, 30, 11, 499, DateTimeKind.Local).AddTicks(4736));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreateTime",
                value: new DateTime(2022, 5, 9, 15, 30, 11, 499, DateTimeKind.Local).AddTicks(771));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreateTime",
                value: new DateTime(2022, 5, 9, 15, 30, 11, 499, DateTimeKind.Local).AddTicks(2398));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreateTime",
                value: new DateTime(2022, 5, 9, 15, 30, 11, 499, DateTimeKind.Local).AddTicks(2495));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 4,
                column: "CreateTime",
                value: new DateTime(2022, 5, 9, 15, 30, 11, 499, DateTimeKind.Local).AddTicks(2504));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 5,
                column: "CreateTime",
                value: new DateTime(2022, 5, 9, 15, 30, 11, 499, DateTimeKind.Local).AddTicks(2508));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 6,
                column: "CreateTime",
                value: new DateTime(2022, 5, 9, 15, 30, 11, 499, DateTimeKind.Local).AddTicks(2513));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 7,
                column: "CreateTime",
                value: new DateTime(2022, 5, 9, 15, 30, 11, 499, DateTimeKind.Local).AddTicks(2517));

            migrationBuilder.UpdateData(
                table: "UserVerification",
                keyColumn: "UserVerificationId",
                keyValue: 1,
                columns: new[] { "ApplyTime", "CertificationTime" },
                values: new object[] { new DateTime(2022, 5, 9, 15, 30, 11, 496, DateTimeKind.Local).AddTicks(4720), new DateTime(2022, 5, 9, 15, 30, 11, 497, DateTimeKind.Local).AddTicks(5737) });

            migrationBuilder.UpdateData(
                table: "UserVerification",
                keyColumn: "UserVerificationId",
                keyValue: 2,
                columns: new[] { "ApplyTime", "CertificationTime" },
                values: new object[] { new DateTime(2022, 5, 9, 15, 30, 11, 497, DateTimeKind.Local).AddTicks(7152), new DateTime(2022, 5, 9, 15, 30, 11, 497, DateTimeKind.Local).AddTicks(7159) });

            migrationBuilder.UpdateData(
                table: "UserVerification",
                keyColumn: "UserVerificationId",
                keyValue: 3,
                columns: new[] { "ApplyTime", "CertificationTime" },
                values: new object[] { new DateTime(2022, 5, 9, 15, 30, 11, 497, DateTimeKind.Local).AddTicks(7163), new DateTime(2022, 5, 9, 15, 30, 11, 497, DateTimeKind.Local).AddTicks(7164) });

            migrationBuilder.UpdateData(
                table: "UserVerification",
                keyColumn: "UserVerificationId",
                keyValue: 4,
                columns: new[] { "ApplyTime", "CertificationTime" },
                values: new object[] { new DateTime(2022, 5, 9, 15, 30, 11, 497, DateTimeKind.Local).AddTicks(7168), new DateTime(2022, 5, 9, 15, 30, 11, 497, DateTimeKind.Local).AddTicks(7170) });

            migrationBuilder.UpdateData(
                table: "UserVerification",
                keyColumn: "UserVerificationId",
                keyValue: 5,
                columns: new[] { "ApplyTime", "CertificationTime" },
                values: new object[] { new DateTime(2022, 5, 9, 15, 30, 11, 497, DateTimeKind.Local).AddTicks(7172), new DateTime(2022, 5, 9, 15, 30, 11, 497, DateTimeKind.Local).AddTicks(7174) });

            migrationBuilder.UpdateData(
                table: "UserVerification",
                keyColumn: "UserVerificationId",
                keyValue: 6,
                columns: new[] { "ApplyTime", "CertificationTime" },
                values: new object[] { new DateTime(2022, 5, 9, 15, 30, 11, 497, DateTimeKind.Local).AddTicks(7176), new DateTime(2022, 5, 9, 15, 30, 11, 497, DateTimeKind.Local).AddTicks(7177) });

            migrationBuilder.UpdateData(
                table: "UserVerification",
                keyColumn: "UserVerificationId",
                keyValue: 7,
                columns: new[] { "ApplyTime", "CertificationTime" },
                values: new object[] { new DateTime(2022, 5, 9, 15, 30, 11, 497, DateTimeKind.Local).AddTicks(7179), new DateTime(2022, 5, 9, 15, 30, 11, 497, DateTimeKind.Local).AddTicks(7180) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
