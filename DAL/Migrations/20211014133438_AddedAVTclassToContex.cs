using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddedAVTclassToContex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AvaliableVisitTime_Doctors_DoctorId",
                table: "AvaliableVisitTime");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AvaliableVisitTime",
                table: "AvaliableVisitTime");

            migrationBuilder.RenameTable(
                name: "AvaliableVisitTime",
                newName: "AvaliableVisitTimes");

            migrationBuilder.RenameIndex(
                name: "IX_AvaliableVisitTime_DoctorId",
                table: "AvaliableVisitTimes",
                newName: "IX_AvaliableVisitTimes_DoctorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AvaliableVisitTimes",
                table: "AvaliableVisitTimes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AvaliableVisitTimes_Doctors_DoctorId",
                table: "AvaliableVisitTimes",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AvaliableVisitTimes_Doctors_DoctorId",
                table: "AvaliableVisitTimes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AvaliableVisitTimes",
                table: "AvaliableVisitTimes");

            migrationBuilder.RenameTable(
                name: "AvaliableVisitTimes",
                newName: "AvaliableVisitTime");

            migrationBuilder.RenameIndex(
                name: "IX_AvaliableVisitTimes_DoctorId",
                table: "AvaliableVisitTime",
                newName: "IX_AvaliableVisitTime_DoctorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AvaliableVisitTime",
                table: "AvaliableVisitTime",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AvaliableVisitTime_Doctors_DoctorId",
                table: "AvaliableVisitTime",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
