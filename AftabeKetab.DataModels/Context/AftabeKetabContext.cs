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
        public DbSet<UserEntity>? Users { get; set; }
        public DbSet<AddressEntity>? Addresses { get; set; }
        public DbSet<OrderEntity>? Orders { get; set; }
        public DbSet<OrderItemsEntity>? OrderItems { get; set; }
        // Book schema
        public DbSet<BookEntity>? Books { get; set; }
        public DbSet<AuthorEntity>? Authors { get; set; }
        public DbSet<CategoryEntity>? Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().ToTable("users", "sales");
            modelBuilder.Entity<AddressEntity>().ToTable("addresses", "sales");
            modelBuilder.Entity<OrderEntity>().ToTable("orders", "sales");
            modelBuilder.Entity<OrderItemsEntity>().ToTable("order_items", "sales");
            modelBuilder.Entity<BookEntity>().ToTable("books", "book");
            modelBuilder.Entity<AuthorEntity>().ToTable("authors", "book");
            modelBuilder.Entity<CategoryEntity>().ToTable("categories", "book");

            // Configure Primary-Key and Foreign-Keys.
            // Configure Relationships between entities.
            //
            // User and Address
            modelBuilder.Entity<UserEntity>()
                .HasKey(u => u.Id)
                .HasRequired<AddressEntity>(u => u.ShippingAddress)
                .WithMany(a => a.Users)
                .HasForeignKey(u => u.AddressId);
            // Order and Seller
            modelBuilder.Entity<OrderEntity>()
                .HasKey(o => o.Id)
                .HasRequired<UserEntity>(o => o.Seller)
                .WithMany(u => u.OrdersAsSeller)
                .HasForeignKey(o => o.SellerId);
            // Order and Buyer
            modelBuilder.Entity<OrderEntity>()
                .HasRequired<UserEntity>(o => o.Buyer)
                .WithMany(u => u.OrdersAsBuyer)
                .HasForeignKey(o => o.BuyerId);
            // Order and OrderItems
            modelBuilder.Entity<OrderEntity>()
                .HasOptional<OrderItemsEntity>(o => o.Items)
                .WithOptionalDependent(i => i.Order)
                .Map(o => o.MapKey("ItemsId"));
            modelBuilder.Entity<OrderItemsEntity>()
                .HasOptional<OrderEntity>(i => i.Order)
                .WithOptionalDependent(o => o.Items)
                .Map(i => i.MapKey("OrderId"));
            // Book and User
            modelBuilder.Entity<BookEntity>()
                .HasKey(b => b.Id)
                .HasRequired<UserEntity>(b => b.Owner)
                .WithMany(u => u.Books)
                .HasForeignKey(b => b.OwnerId);
            // Book and OrderItems
            modelBuilder.Entity<BookEntity>()
                .HasOptional<OrderItemsEntity>(b => b.OrderItem)
                .WithMany(i => i.Books)
                .HasForeignKey(b => b.OrderItemId);
            // Book and Category
            modelBuilder.Entity<BookEntity>()
                .HasMany<CategoryEntity>(b => b.Categories)
                .WithMany(c => c.Books);
            // Book and Author
            modelBuilder.Entity<BookEntity>()
                .HasRequired<AuthorEntity>(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId);
        }
    }
}
