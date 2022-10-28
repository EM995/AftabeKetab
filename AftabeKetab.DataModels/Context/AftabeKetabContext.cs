using AftabeKetab.DataModels.Sales;
using System.Data.Entity;

namespace AftabeKetab.DataModels
{
    public class AftabeKetabContext : DbContext
    {
        public AftabeKetabContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            Database.SetInitializer(new AftabeKetabDbInitializer());
        }

        // Sales schema
        public DbSet<EntityUser>? Users { get; set; }
        public DbSet<EntityAddress>? Addresses { get; set; }
        public DbSet<EntityOrder>? Orders { get; set; }
        public DbSet<EntityOrderItems>? OrderItems { get; set; }
        // Book schema
        public DbSet<EntityBook>? Books { get; set; }
        public DbSet<EntityAuthor>? Authors { get; set; }
        public DbSet<EntityCategory>? Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EntityUser>().ToTable("users", "sales");
            modelBuilder.Entity<EntityAddress>().ToTable("addresses", "sales");
            modelBuilder.Entity<EntityOrder>().ToTable("orders", "sales");
            modelBuilder.Entity<EntityOrderItems>().ToTable("order_items", "sales");
            modelBuilder.Entity<EntityBook>().ToTable("books", "book");
            modelBuilder.Entity<EntityAuthor>().ToTable("authors", "book");
            modelBuilder.Entity<EntityCategory>().ToTable("categories", "book");

            // Configure Primary-Key and Foreign-Keys.
            // Configure Relationships between entities.
            //
            // User and Address
            modelBuilder.Entity<EntityUser>()
                .HasKey(u => u.Id)
                .HasRequired<EntityAddress>(u => u.ShippingAddress)
                .WithMany(a => a.Users)
                .HasForeignKey(u => u.AddressId);
            // Order and Seller
            modelBuilder.Entity<EntityOrder>()
                .HasKey(o => o.Id)
                .HasRequired<EntityUser>(o => o.Seller)
                .WithMany(u => u.OrdersAsSeller)
                .HasForeignKey(o => o.SellerId);
            // Order and Buyer
            modelBuilder.Entity<EntityOrder>()
                .HasRequired<EntityUser>(o => o.Buyer)
                .WithMany(u => u.OrdersAsBuyer)
                .HasForeignKey(o => o.BuyerId);
            // Order and OrderItems
            modelBuilder.Entity<EntityOrder>()
                .HasOptional<EntityOrderItems>(o => o.Items)
                .WithOptionalDependent(i => i.Order)
                .Map(o => o.MapKey("ItemsId"));
            modelBuilder.Entity<EntityOrderItems>()
                .HasOptional<EntityOrder>(i => i.Order)
                .WithOptionalDependent(o => o.Items)
                .Map(i => i.MapKey("OrderId"));
            // Book and User
            modelBuilder.Entity<EntityBook>()
                .HasKey(b => b.Id)
                .HasRequired<EntityUser>(b => b.Owner)
                .WithMany(u => u.Books)
                .HasForeignKey(b => b.OwnerId);
            // Book and OrderItems
            modelBuilder.Entity<EntityBook>()
                .HasOptional<EntityOrderItems>(b => b.OrderItem)
                .WithMany(i => i.Books)
                .HasForeignKey(b => b.OrderItemId);
            // Book and Category
            modelBuilder.Entity<EntityBook>()
                .HasMany<EntityCategory>(b => b.Categories)
                .WithMany(c => c.Books);
            // Book and Author
            modelBuilder.Entity<EntityBook>()
                .HasRequired<EntityAuthor>(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId);
        }
    }
}
