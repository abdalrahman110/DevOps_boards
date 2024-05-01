//the file to connect to the database
using dotnetAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnetAPI.Context
{
    public class TeamLeaderDbContext : DbContext
    {
        //(Dbset) save every instance from the "project" model in this variable  
        public DbSet<Project> Projects { get; set; }

        public DbSet<Developer> Developers { get; set;}

        public DbSet<Models.Task> Tasks  { get; set;}


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //connection 
            optionsBuilder.UseSqlServer(@"data source=ABDALRAHMAN;Initial Catalog=devops_boards;Integrated Security=SSPI; TrustServerCertificate=true;");
            //connection string: data source="server name"; initial catalog="database name"; integrated security=true;TrustServerCertificate=true;"
            base.OnConfiguring(optionsBuilder);
        }
    }
}
