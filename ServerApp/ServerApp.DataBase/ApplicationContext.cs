using Microsoft.EntityFrameworkCore;
using ServerApp.Logic.Entities;

namespace ServerApp.DataBase;

public class ApplicationContext : DbContext {
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Hobby> Hobbies { get; set; } = null!;
    public DbSet<FriendsPair> FriendsPairs { get; set; } = null!;
    public DbSet<Role> Roles { get; set; } = null!;
    public DbSet<Activity> Activities { get; set; } = null!;
    public DbSet<ActivityType> ActivityTypes { get; set; } = null!;

    public ApplicationContext() {
        _ = Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        _ = modelBuilder.Entity<User>(
            eb => {
                _ = eb.Property(b => b.RegistrationDate).HasColumnType("timestamp(6)");
            });

        _ = modelBuilder.Entity<Activity>(
             eb => {
                 _ = eb.Property(b => b.WorkEnd).HasColumnType("timestamp(6)");
                 _ = eb.Property(b => b.WorkBegin).HasColumnType("timestamp(6)");
                 _ = eb.Property(b => b.CreationTime).HasColumnType("timestamp(6)");
             });

        _ = modelBuilder.Entity<FriendsPair>()
            .HasOne(fs => fs.Reciever)
            .WithMany(u => u.FriendSenders);

        _ = modelBuilder.Entity<FriendsPair>()
            .HasOne(fs => fs.Sender)
            .WithMany(u => u.FriendRecievers);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        _ = optionsBuilder.UseNpgsql(@"
            Host = localhost;
            Port = 5432;
            Database = usersdb;
            Username = postgres;
            Password = 12345
        ", x => x.UseNetTopologySuite());
    }
}
