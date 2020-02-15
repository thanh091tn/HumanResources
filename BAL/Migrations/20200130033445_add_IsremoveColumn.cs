using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class add_IsremoveColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategorySkill_SkillEnitities_SkillId",
                table: "CategorySkill");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeSkill_SkillEnitities_skillId",
                table: "EmployeeSkill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SkillEnitities",
                table: "SkillEnitities");

            migrationBuilder.RenameTable(
                name: "SkillEnitities",
                newName: "Skill");

            migrationBuilder.AddColumn<bool>(
                name: "IsRemove",
                table: "EmployeeProgram",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRemove",
                table: "AndPnEmployee",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Skill",
                table: "Skill",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategorySkill_Skill_SkillId",
                table: "CategorySkill",
                column: "SkillId",
                principalTable: "Skill",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSkill_Skill_skillId",
                table: "EmployeeSkill",
                column: "skillId",
                principalTable: "Skill",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategorySkill_Skill_SkillId",
                table: "CategorySkill");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeSkill_Skill_skillId",
                table: "EmployeeSkill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Skill",
                table: "Skill");

            migrationBuilder.DropColumn(
                name: "IsRemove",
                table: "EmployeeProgram");

            migrationBuilder.DropColumn(
                name: "IsRemove",
                table: "AndPnEmployee");

            migrationBuilder.RenameTable(
                name: "Skill",
                newName: "SkillEnitities");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SkillEnitities",
                table: "SkillEnitities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategorySkill_SkillEnitities_SkillId",
                table: "CategorySkill",
                column: "SkillId",
                principalTable: "SkillEnitities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSkill_SkillEnitities_skillId",
                table: "EmployeeSkill",
                column: "skillId",
                principalTable: "SkillEnitities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
