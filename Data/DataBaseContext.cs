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

        public DbSet<NotificationModel> Notifications { get; set; }

        public DbSet<PoolModel> Pools { get; set; }

        public DbSet<GarageModel> Garages { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MessageModel>()
                .HasOne(m => m.Sender)
                .WithMany(u => u.SentMessages)
                .HasForeignKey(m => m.SenderId)
                .OnDelete(DeleteBehavior.Restrict); // avoid accidental cascade deletion

            modelBuilder.Entity<MessageModel>()
                .HasOne(m => m.Receiver)
                .WithMany(u => u.ReceivedMessages)
                .HasForeignKey(m => m.Receiver)
                .OnDelete(DeleteBehavior.Restrict);

        }

       
    }
}
