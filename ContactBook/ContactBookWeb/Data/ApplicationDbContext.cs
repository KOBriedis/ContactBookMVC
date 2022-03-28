using ContactBookWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactBookWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }

        public DbSet<Member> Members { get; set; }
    }
}
