using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2_Group4.Models
{
    public class TaskDatabaseContext : DbContext
    {
        public TaskDatabaseContext(DbContextOptions<TaskDatabaseContext> options) : base(options)
        {

        }

        public DbSet<TaskModel> Tasks { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category
                {
                    CategoryID = 1,
                    CategoryName = "Home"
                },
                new Category
                {
                    CategoryID = 2,
                    CategoryName = "School"
                },
                new Category
                {
                    CategoryID = 3,
                    CategoryName = "Work"
                },
                new Category
                {
                    CategoryID = 4,
                    CategoryName = "Church"
                }
                );
        }
    }
}
