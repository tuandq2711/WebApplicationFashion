using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using FashionGo.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using FashionGo.Migrations;

namespace FashionGo.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        [StringLength(256)]
        public string FullName { get; set; }

        public string Address { get; set; }

        public string DistrictId { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public virtual District District { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }

        public virtual DbSet<BannerPosition> BannerPositions { get; set; }
        public virtual DbSet<Banner> Banners { get; set; }
        public virtual DbSet<BannerType> BannerTypes { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<Faq> Faqs { get; set; }
        public virtual DbSet<Manufact> Manufacts { get; set; }
        public virtual DbSet<Meta> Metas { get; set; }
        public virtual DbSet<MetaType> MetaTypes { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Coupon> Coupons { get; set; }

        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderStatus> OrderStatus { get; set; }
        public virtual DbSet<Page> Pages { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<ProductMeta> ProductMetas { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductType> ProductTypes { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<Transporter> Transporters { get; set; }
        public virtual DbSet<Transport> Transports { get; set; }
        public virtual DbSet<TransportType> TransportTypes { get; set; }
        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<MenuLocation> MenuLocations { get; set; }
        public virtual DbSet<Slider> Sliders { get; set; }
        public virtual DbSet<Testimonial> Testimonials { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder); // This needs to go before the other rules!

            modelBuilder.Entity<IdentityUser>().ToTable("Users", "dbo");
            modelBuilder.Entity<ApplicationUser>().ToTable("Users", "dbo");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles", "dbo");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRoles", "dbo");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims", "dbo");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogins", "dbo");


            //Entity model
            modelBuilder.Entity<Category>()
                .HasMany(e => e.SubCategories)
                .WithOptional(e => e.ParentCategory)
                .HasForeignKey(e => e.ParentId);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Posts)
                .WithOptional(e => e.Category)
                .HasForeignKey(e => e.CatId);


            modelBuilder.Entity<Faq>()
                .Property(e => e.Content)
                .IsUnicode(false);

            modelBuilder.Entity<Manufact>()
                .Property(e => e.Logo)
                .IsUnicode(false);

            modelBuilder.Entity<Meta>()
                .Property(e => e.Options)
                .IsUnicode(false);

            modelBuilder.Entity<Meta>()
                .Property(e => e.Value)
                .IsUnicode(false);

            modelBuilder.Entity<Meta>()
                .HasMany(e => e.ProductMetas)
                .WithRequired(e => e.Meta)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MetaType>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<MetaType>()
                .Property(e => e.Note)
                .IsUnicode(false);

            modelBuilder.Entity<MetaType>()
                .HasMany(e => e.Metas)
                .WithOptional(e => e.MetaType)
                .HasForeignKey(e => e.TypeId);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrderStatus>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.OrderStatus)
                .HasForeignKey(e => e.StatusId);

            modelBuilder.Entity<ProductCategory>()
                .HasMany(e => e.SubCategories)
                .WithOptional(e => e.ParentCategory)
                .HasForeignKey(e => e.ParentId);

            modelBuilder.Entity<ProductMeta>()
                .Property(e => e.Value)
                .IsUnicode(false);

            modelBuilder.Entity<ProductMeta>()
                .Property(e => e.Note)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.FeaturedImage)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ProductMetas)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductType>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.ProductType)
                .HasForeignKey(e => e.TypeId);

            modelBuilder.Entity<Transporter>()
                .Property(e => e.Logo)
                .IsFixedLength();

            modelBuilder.Entity<Transporter>()
                .HasMany(e => e.Transports)
                .WithRequired(e => e.Transporter)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TransportType>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<TransportType>()
                .HasMany(e => e.Transports)
                .WithRequired(e => e.TransportType)
                .HasForeignKey(e => e.TransportTypeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PaymentMethod>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.PaymentMethod)
                .HasForeignKey(e => e.PaymentMethodId);

            modelBuilder.Entity<MenuLocation>()
                .HasMany(e => e.Menus)
                .WithOptional(e => e.MenuLocation)
                .HasForeignKey(e => e.LocationId);

            modelBuilder.Entity<District>()
                .HasMany(e => e.Transports)
                .WithOptional(e => e.District)
                .HasForeignKey(e => e.DistrictId);
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

    }
}