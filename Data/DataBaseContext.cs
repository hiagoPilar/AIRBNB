using AIRBNB.Models;
using Microsoft.EntityFrameworkCore;

namespace AIRBNB.Data
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }

        public DbSet<UserModel> Users { get; set; }

        public DbSet<PropertyModel> Properties { get; set; }

    }
}
