namespace CMCS.Models
{
    public class ApplicationDbContext : DbContextOptions, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public ISet<Lecturer> Lecturers { get; set; }
        public ISet<Claim> Claims { get; set; }
    }

    public class DbContextOptions
    {
        public DbContextOptions(DbContextOptions<ApplicationDbContext> options)
        {
        }
    }

    public class DbContextOptions<T>
    {
    }
}
