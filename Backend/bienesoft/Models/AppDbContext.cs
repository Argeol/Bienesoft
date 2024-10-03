using Bienesoft.Models;
using Microsoft.EntityFrameworkCore;

namespace bienesoft.Models
{
    public class AppDbContext: DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext>options) :base (options) { }

        public DbSet<LearnerModel> Learner { get; set; }
        public DbSet<DepartmentModel> department{ get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=localhost;Database= bienesoft;User=root;Password=argeol1234;Port=3306",
                    new MySqlServerVersion(new Version(8, 0, 39)));
            }
        }
    }
}
