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

        public DbSet<AmenityModel> Amenities { get; set; }

        public DbSet<PropertyAmenityModel> PropertiesAmenities { get; set; }

        public DbSet<ReservationModel> Reservations { get; set; }

        public DbSet<PhotoModel> Photos { get; set; }

        public DbSet<ReviewModel> Reviews { get; set; }

        public DbSet<FavoriteModel> Favorites { get; set; }

        public DbSet<PaymentModel> Payments { get; set; }

        public DbSet<MessageModel> Messages { get; set; }

       
    }
}
