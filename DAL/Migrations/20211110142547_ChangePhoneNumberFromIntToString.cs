using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class ChangePhoneNumberFromIntToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "visitType",
                table: "Visits",
                newName: "VisitType");

            migrationBuilder.RenameColumn(
                name: "dateTime",
                table: "Visits",
                newName: "DateTime");

            migrationBuilder.RenameColumn(
                name: "gender",
                table: "Patients",
                newName: "Gender");

            migrationBuilder.RenameColumn(
                name: "gender",
                table: "Doctors",
                newName: "Gender");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VisitType",
                table: "Visits",
                newName: "visitType");

            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Visits",
                newName: "dateTime");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "Patients",
                newName: "gender");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "Doctors",
                newName: "gender");

            migrationBuilder.AlterColumn<int>(
                name: "PhoneNumber",
                table: "Patients",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PhoneNumber",
                table: "Doctors",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
