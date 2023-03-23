using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete;

public class Context: IdentityDbContext<AppUser,AppRole,int>
{
    public Context()
    { }
    public Context(DbContextOptions opt) : base(options:opt) // migration için
    { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("server=.;database=CoreBlogDb;integrated security = true; Trust Server Certificate=true");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Message2>() //İlişki
            .HasOne(x => x.SenderUser)
            .WithMany(y => y.WriterSender)
            .HasForeignKey(z => z.SenderId)
            .OnDelete(DeleteBehavior.ClientSetNull);

        modelBuilder.Entity<Message2>()
            .HasOne(x => x.ReceiverUser)
            .WithMany(y => y.WriterReceiver)
            .HasForeignKey(z => z.ReceiverId)
            .OnDelete(DeleteBehavior.ClientSetNull);
        
        base.OnModelCreating(modelBuilder);
    }
    public DbSet<About> Abouts { get; set; }
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Writer> Writers { get; set; }
    public DbSet<NewsLetter> NewsLetters { get; set; }
    public DbSet<BlogRayting> BlogRaytings { get; set; }
    public DbSet<Notfication> Notfications { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Message2> Message2s { get; set; }
    public DbSet<Admin> Admins { get; set; }
} 