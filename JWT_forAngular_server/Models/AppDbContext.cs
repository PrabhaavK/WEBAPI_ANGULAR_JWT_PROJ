
namespace JWT_forAngular_server.Models{


  public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){ }
        public DbSet<User> Users{ get; set;}
        public DbSet<Course> Courses{ get; set;}
        // public Dbset<LoginModel> loginmodel { get;set;}
    }

}
 