using AIRBNB.Models.Entities;
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
                .HasOne(m => m.Property)
                .WithMany(p => p.Messages)
                .HasForeignKey(m => m.PropertyId)
                .OnDelete(DeleteBehavior.SetNull);
            
            modelBuilder.Entity<MessageModel>()
                .HasOne(m => m.Sender)
                .WithMany(u => u.SentMessages)
                .HasForeignKey(m => m.SenderId)
                .OnDelete(DeleteBehavior.Restrict); // avoid accidental cascade deletion

            modelBuilder.Entity<MessageModel>()
                .HasOne(m => m.Receiver)
                .WithMany(u => u.ReceivedMessages)
                .HasForeignKey(m => m.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MessageModel>()
                .HasOne(m => m.Reservation)
                .WithMany(r => r.Messages)
                .HasForeignKey(m => m.ReservationId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ReservationModel>()
                .HasOne(r => r.Payment)
                .WithOne(p => p.Reservation)
                .HasForeignKey<PaymentModel>(p => p.ReservationId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ReservationModel>()
                .HasOne(m => m.Guest)
                .WithMany(p => p.Reservations)
                .HasForeignKey(p => p.GuestId)
                .OnDelete(DeleteBehavior.Restrict); //not delete reservations if the user is removed

            modelBuilder.Entity<FavoriteModel>()
                .HasKey(f => new { f.GuestId, f.PropertyId });

            modelBuilder.Entity<FavoriteModel>()
                .HasOne(f => f.Property)
                .WithMany(p => p.Favorites)
                .HasForeignKey(f => f.PropertyId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<FavoriteModel>()
                .HasOne(f => f.User)
                .WithMany(u => u.Favorites)
                .HasForeignKey(f => f.GuestId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PropertyAmenityModel>()
                .HasKey(pa => new { pa.PropertyId, pa.AmenityId });




        }

       
    }
}
