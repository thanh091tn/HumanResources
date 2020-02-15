using Microsoft.EntityFrameworkCore;
using BO.Models;

namespace DAL
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<EmployeeEntity> Employee { get; set; }
        public DbSet<CourseEntity> Course { get; set; }
        public DbSet<RoleEntity> Role { get; set; }
        public DbSet<StoreEntity> Store { get; set; }
        public DbSet<EmployeeProgramEntity> EmployeeProgram { get; set; }
        public DbSet<StoreEmployeeEntity> StoreEmployee { get; set; }
        public DbSet<UserEntity> User { get; set; }
        public DbSet<UserRoleEntity> UserRole { get; set; }
        public DbSet<CategoryEntity> Category { get; set; }
        public DbSet<CategorySkillEntity> CategorySkill { get; set; }
        public DbSet<SkillEnitity> Skill { get; set; }
        public DbSet<EmployeeSkillEntity> EmployeeSkill { get; set; }
        public DbSet<ProgramEntity> Program { get; set; }
        public DbSet<ProgramCourseEntity> ProgramCourse { get; set; }
        public DbSet<EmployeeRoleEntity> EmployeeRole { get; set; }
        public DbSet<AwAndPnEmployeeEntity> AndPnEmployee { get; set; }
        public DbSet<AwAndPnEntity> AwAndPn { get; set; }
        public DbSet<CityEntity> City { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    }

}
