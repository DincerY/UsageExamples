using Microsoft.EntityFrameworkCore;

namespace UnitOfWorkDesignPattern;

public class Order
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public string OrderNo { get; set; }
    public DateTime OrderedDate { get; set; }
    public Customer Customer { get; set; }
}

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public ICollection<Order> Orders { get; set; }  
}





public class ApplicationDbContext : DbContext
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<Customer> Customers { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=(localdb)\\MSSQLLocalDB;Database=UnitOfWorkDb;Trusted_Connection=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>()
            .HasOne<Customer>()
            .WithMany(o => o.Orders)
            .HasForeignKey(o => o.CustomerId);
    }
}


