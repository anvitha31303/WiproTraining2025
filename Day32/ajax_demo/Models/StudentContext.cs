using Microsoft.EntityFrameworkCore;
using ajax_demo.Models;
namespace ajax_demo.Models;


    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
    }
