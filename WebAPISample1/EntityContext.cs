using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using WebAPISample1.Models;

namespace WebAPISample1
{
    public class EntityContext : DbContext
    {
        public EntityContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
    }
}
