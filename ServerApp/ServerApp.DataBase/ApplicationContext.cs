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
    public DbSet<Visit> Visites { get; set; } = null!;
    public DbSet<Route> Routes { get; set; } = null!;

    // public ApplicationContext() {
    //     _ = Database.EnsureCreated();
    // }

    public ApplicationContext(DbContextOptions<ApplicationContext> options)
    : base(options) {

        _ = Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        _ = modelBuilder.Entity<Activity>(
            builder => {
                _ = builder.ComplexProperty(activity => activity.ActivityInfo);
            });

        _ = modelBuilder.Entity<User>(
            builder => {
                _ = builder.ComplexProperty(user => user.AuthInfo);
            });

        _ = modelBuilder.Entity<User>(
                builder => {
                    _ = builder.ComplexProperty(user => user.UserInfo);
                });

        _ = modelBuilder.Entity<User>(
            builder => {
                _ = builder.Property(b => b.RegistrationDate).HasColumnType("timestamp(6)");
            });

        _ = modelBuilder.Entity<Reviews>(
            builder => {
                _ = builder.Property(b => b.CreationTime).HasColumnType("timestamp(6)");
            });

        _ = modelBuilder.Entity<Visit>(
            builder => {
                _ = builder.Property(b => b.VisitTime).HasColumnType("timestamp(6)");
            });

        _ = modelBuilder.Entity<Route>(
            builder => {
                _ = builder.Property(b => b.CreationDate).HasColumnType("timestamp(6)");
                _ = builder.Property(b => b.StartTime).HasColumnType("timestamp(6)");
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

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
    //     _ = optionsBuilder.UseNpgsql(@"
    //         Host = hackatonspring2024-postgres-1;
    //         Port = 5432;
    //         Database = usersdb;
    //         Username = postgres;
    //         Password = 12345
    //     ", x => x.UseNetTopologySuite());
    // }
}
