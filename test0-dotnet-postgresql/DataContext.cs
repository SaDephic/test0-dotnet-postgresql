using Microsoft.EntityFrameworkCore;
namespace test0_dotnet_postgresql
{
    public class DataContext : DbContext
    {
        public DbSet<Department> department { get; set; }
        public DbSet<Employee> employee { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "D1" },
                new Department { Id = 2, Name = "D2" },
                new Department { Id = 3, Name = "D3" }
                );
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 2, Department_id = 1, Chief_id = 5, Name = "Misha", Salary = 600 },
                new Employee { Id = 3, Department_id = 2, Chief_id = 6, Name = "Eugen", Salary = 300 },
                new Employee { Id = 5, Department_id = 3, Chief_id = 7, Name = "Stepan", Salary = 500 },
                new Employee { Id = 4, Department_id = 2, Chief_id = 6, Name = "Tolya", Salary = 400 },
                new Employee { Id = 6, Department_id = 3, Chief_id = 7, Name = "Alex", Salary = 1000 },
                new Employee { Id = 7, Department_id = 3, Chief_id = null, Name = "Ivan", Salary = 1100 },
                new Employee { Id = 1, Department_id = 1, Chief_id = 5, Name = "John", Salary = 100 }
            );
        }
    }
}
