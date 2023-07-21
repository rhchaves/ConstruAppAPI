using Microsoft.EntityFrameworkCore;

namespace ConstruAppAPI.Models
{
    public partial class ModelContext : DbContext
    {
        public ModelContext(DbContextOptions<ModelContext> options) : base(options)
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public virtual DbSet<PurchaseOrderItem> PurchaseOrderItems { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<UserAdmin> UserAdmins { get; set; }
        public virtual DbSet<UserClient> UserClients { get; set; }
        public virtual DbSet<UserSeller> UserSellers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("User Id=CONSTRUAPP;Password=construapp;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=XEPDB1)))");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("CONSTRUAPP")
                .UseCollation("USING_NLS_COMP");

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.Property(e => e.Id).HasPrecision(10);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.AccessFailedCount).HasPrecision(10);

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.EmailConfirmed).HasPrecision(1);

                entity.Property(e => e.LockoutEnabled).HasPrecision(1);

                entity.Property(e => e.LockoutEnd).HasPrecision(7);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.PhoneNumberConfirmed).HasPrecision(1);

                entity.Property(e => e.TwoFactorEnabled).HasPrecision(1);

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "AspNetUserRole",
                        l => l.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                        r => r.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId");

                            j.ToTable("AspNetUserRoles");

                            j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                        });
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.Property(e => e.Id).HasPrecision(10);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("CATEGORIES");

                entity.HasIndex(e => e.Name, "SYS_C0013047")
                    .IsUnique();

                entity.HasIndex(e => e.Label, "SYS_C0013048")
                    .IsUnique();

                entity.Property(e => e.CategoryId)
                    .HasPrecision(10)
                    .HasColumnName("CATEGORY_ID");

                entity.Property(e => e.CreateRegister)
                    .HasPrecision(7)
                    .HasColumnName("CREATE_REGISTER")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP ");

                entity.Property(e => e.DeletedRegister)
                    .HasPrecision(7)
                    .HasColumnName("DELETED_REGISTER");

                entity.Property(e => e.ImageUri)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE_URI");

                entity.Property(e => e.Label)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LABEL");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Status)
                    .HasPrecision(1)
                    .HasColumnName("STATUS")
                    .HasDefaultValueSql("0 ");

                entity.Property(e => e.UpdateRegister)
                    .HasPrecision(7)
                    .HasColumnName("UPDATE_REGISTER")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP ");

                entity.Property(e => e.UpdateStatus)
                    .HasPrecision(7)
                    .HasColumnName("UPDATE_STATUS")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP ");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("PRODUCTS");

                entity.HasIndex(e => e.Name, "SYS_C0013065")
                    .IsUnique();

                entity.HasIndex(e => e.Label, "SYS_C0013066")
                    .IsUnique();

                entity.Property(e => e.ProductId)
                    .HasPrecision(10)
                    .HasColumnName("PRODUCT_ID");

                entity.Property(e => e.CategoryId)
                    .HasPrecision(10)
                    .HasColumnName("CATEGORY_ID");

                entity.Property(e => e.CreateRegister)
                    .HasPrecision(7)
                    .HasColumnName("CREATE_REGISTER")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP ");

                entity.Property(e => e.DeletedRegister)
                    .HasPrecision(7)
                    .HasColumnName("DELETED_REGISTER");

                entity.Property(e => e.Description)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.ImageUri)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE_URI");

                entity.Property(e => e.Label)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("LABEL");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Price)
                    .HasColumnType("NUMBER(10,2)")
                    .HasColumnName("PRICE");

                entity.Property(e => e.ProductMark)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("PRODUCT_MARK");

                entity.Property(e => e.SoldQtd)
                    .HasPrecision(10)
                    .HasColumnName("SOLD_QTD");

                entity.Property(e => e.Status)
                    .HasPrecision(1)
                    .HasColumnName("STATUS")
                    .HasDefaultValueSql("0 ");

                entity.Property(e => e.StockQtd)
                    .HasPrecision(10)
                    .HasColumnName("STOCK_QTD");

                entity.Property(e => e.UpdateRegister)
                    .HasPrecision(7)
                    .HasColumnName("UPDATE_REGISTER")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP ");

                entity.Property(e => e.UpdateStatus)
                    .HasPrecision(7)
                    .HasColumnName("UPDATE_STATUS")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP ");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_PRODUCTS_CATEGORIES");
            });

            modelBuilder.Entity<PurchaseOrder>(entity =>
            {
                entity.ToTable("PURCHASE_ORDERS");

                entity.Property(e => e.PurchaseOrderId)
                    .HasPrecision(10)
                    .HasColumnName("PURCHASE_ORDER_ID");

                entity.Property(e => e.CreateRegister)
                    .HasPrecision(7)
                    .HasColumnName("CREATE_REGISTER")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP ");

                entity.Property(e => e.DeletedRegister)
                    .HasPrecision(7)
                    .HasColumnName("DELETED_REGISTER");

                entity.Property(e => e.Status)
                    .HasPrecision(1)
                    .HasColumnName("STATUS")
                    .HasDefaultValueSql("0 ");

                entity.Property(e => e.TotalPrice)
                    .HasColumnType("NUMBER(12,2)")
                    .HasColumnName("TOTAL_PRICE");

                entity.Property(e => e.UpdateRegister)
                    .HasPrecision(7)
                    .HasColumnName("UPDATE_REGISTER")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP ");

                entity.Property(e => e.UpdateStatus)
                    .HasPrecision(7)
                    .HasColumnName("UPDATE_STATUS")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP ");

                entity.Property(e => e.UserClientId)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("USER_CLIENT_ID");

                entity.Property(e => e.UserSellerId)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("USER_SELLER_ID");

                entity.HasOne(d => d.UserClient)
                    .WithMany(p => p.PurchaseOrders)
                    .HasForeignKey(d => d.UserClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PURCHASE_ORDER_USER_CLIENT_ID");

                entity.HasOne(d => d.UserSeller)
                    .WithMany(p => p.PurchaseOrders)
                    .HasForeignKey(d => d.UserSellerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PURCHASE_ORDER_USER_SELLER_ID");
            });

            modelBuilder.Entity<PurchaseOrderItem>(entity =>
            {
                entity.ToTable("PURCHASE_ORDER_ITEMS");

                entity.Property(e => e.PurchaseOrderItemId)
                    .HasPrecision(10)
                    .HasColumnName("PURCHASE_ORDER_ITEM_ID");

                entity.Property(e => e.CreateRegister)
                    .HasPrecision(7)
                    .HasColumnName("CREATE_REGISTER")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP ");

                entity.Property(e => e.DeletedRegister)
                    .HasPrecision(7)
                    .HasColumnName("DELETED_REGISTER");

                entity.Property(e => e.ProductId)
                    .HasPrecision(10)
                    .HasColumnName("PRODUCT_ID");

                entity.Property(e => e.ProductPrice)
                    .HasColumnType("NUMBER(10,2)")
                    .HasColumnName("PRODUCT_PRICE");

                entity.Property(e => e.PurchaseOrderId)
                    .HasPrecision(10)
                    .HasColumnName("PURCHASE_ORDER_ID");

                entity.Property(e => e.Quantity)
                    .HasPrecision(10)
                    .HasColumnName("QUANTITY");

                entity.Property(e => e.Status)
                    .HasPrecision(1)
                    .HasColumnName("STATUS")
                    .HasDefaultValueSql("0 ");

                entity.Property(e => e.TotalPrice)
                    .HasColumnType("NUMBER(12,2)")
                    .HasColumnName("TOTAL_PRICE");

                entity.Property(e => e.UpdateRegister)
                    .HasPrecision(7)
                    .HasColumnName("UPDATE_REGISTER")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP ");

                entity.Property(e => e.UpdateStatus)
                    .HasPrecision(7)
                    .HasColumnName("UPDATE_STATUS")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP ");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.PurchaseOrderItems)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_PURCHASE_ORDER_PRODUCT_ID");

                entity.HasOne(d => d.PurchaseOrder)
                    .WithMany(p => p.PurchaseOrderItems)
                    .HasForeignKey(d => d.PurchaseOrderId)
                    .HasConstraintName("FK_PURCHASE_ORDER_ID");
            });

            modelBuilder.Entity<ShoppingCart>(entity =>
            {
                entity.ToTable("SHOPPING_CARTS");

                entity.Property(e => e.ShoppingCartId)
                    .HasPrecision(10)
                    .HasColumnName("SHOPPING_CART_ID");

                entity.Property(e => e.CreateRegister)
                    .HasPrecision(7)
                    .HasColumnName("CREATE_REGISTER")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP ");

                entity.Property(e => e.DeletedRegister)
                    .HasPrecision(7)
                    .HasColumnName("DELETED_REGISTER");

                entity.Property(e => e.Payment)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PAYMENT");

                entity.Property(e => e.ProductId)
                    .HasPrecision(10)
                    .HasColumnName("PRODUCT_ID");

                entity.Property(e => e.QtdProduct)
                    .HasPrecision(10)
                    .HasColumnName("QTD_PRODUCT");

                entity.Property(e => e.Status)
                    .HasPrecision(1)
                    .HasColumnName("STATUS")
                    .HasDefaultValueSql("0 ");

                entity.Property(e => e.UpdateRegister)
                    .HasPrecision(7)
                    .HasColumnName("UPDATE_REGISTER")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP ");

                entity.Property(e => e.UpdateStatus)
                    .HasPrecision(7)
                    .HasColumnName("UPDATE_STATUS")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP ");

                entity.Property(e => e.UserClientId)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("USER_CLIENT_ID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ShoppingCarts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SHOPPING_CART_PRODUCT_ID");

                entity.HasOne(d => d.UserClient)
                    .WithMany(p => p.ShoppingCarts)
                    .HasForeignKey(d => d.UserClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SHOPPING_CART_USER_CLIENT_ID");
            });

            modelBuilder.Entity<UserAdmin>(entity =>
            {
                entity.ToTable("USER_ADMINS");

                entity.HasIndex(e => e.FullName, "SYS_C0013077")
                    .IsUnique();

                entity.HasIndex(e => e.Cpf, "SYS_C0013078")
                    .IsUnique();

                entity.Property(e => e.UserAdminId)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("USER_ADMIN_ID");

                entity.Property(e => e.Cpf)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("CPF");

                entity.Property(e => e.CreateRegister)
                    .HasPrecision(7)
                    .HasColumnName("CREATE_REGISTER")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP ");

                entity.Property(e => e.DeletedRegister)
                    .HasPrecision(7)
                    .HasColumnName("DELETED_REGISTER");

                entity.Property(e => e.FullName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FULL_NAME");

                entity.Property(e => e.Status)
                    .HasPrecision(1)
                    .HasColumnName("STATUS")
                    .HasDefaultValueSql("0 ");

                entity.Property(e => e.UpdateRegister)
                    .HasPrecision(7)
                    .HasColumnName("UPDATE_REGISTER")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP ");

                entity.Property(e => e.UpdateStatus)
                    .HasPrecision(7)
                    .HasColumnName("UPDATE_STATUS")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP ");

                entity.Property(e => e.UserId)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("USER_ID");
            });

            modelBuilder.Entity<UserClient>(entity =>
            {
                entity.ToTable("USER_CLIENTS");

                entity.HasIndex(e => e.FullName, "SYS_C0013094")
                    .IsUnique();

                entity.HasIndex(e => e.Cpf, "SYS_C0013095")
                    .IsUnique();

                entity.Property(e => e.UserClientId)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("USER_CLIENT_ID");

                entity.Property(e => e.AddressNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS_NUMBER");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CITY");

                entity.Property(e => e.Complement)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("COMPLEMENT");

                entity.Property(e => e.Cpf)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("CPF");

                entity.Property(e => e.CreateRegister)
                    .HasPrecision(7)
                    .HasColumnName("CREATE_REGISTER")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP ");

                entity.Property(e => e.DeletedRegister)
                    .HasPrecision(7)
                    .HasColumnName("DELETED_REGISTER");

                entity.Property(e => e.District)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DISTRICT");

                entity.Property(e => e.FullName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FULL_NAME");

                entity.Property(e => e.State)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("STATE");

                entity.Property(e => e.Status)
                    .HasPrecision(1)
                    .HasColumnName("STATUS")
                    .HasDefaultValueSql("0 ");

                entity.Property(e => e.Street)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STREET");

                entity.Property(e => e.UpdateRegister)
                    .HasPrecision(7)
                    .HasColumnName("UPDATE_REGISTER")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP ");

                entity.Property(e => e.UpdateStatus)
                    .HasPrecision(7)
                    .HasColumnName("UPDATE_STATUS")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP ");

                entity.Property(e => e.UserId)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("USER_ID");

                entity.Property(e => e.ZipCode)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ZIP_CODE");
            });

            modelBuilder.Entity<UserSeller>(entity =>
            {
                entity.ToTable("USER_SELLERS");

                entity.HasIndex(e => e.FantasyName, "SYS_C0013111")
                    .IsUnique();

                entity.HasIndex(e => e.Cnpj, "SYS_C0013112")
                    .IsUnique();

                entity.Property(e => e.UserSellerId)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("USER_SELLER_ID");

                entity.Property(e => e.AddressNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS_NUMBER");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CITY");

                entity.Property(e => e.Cnpj)
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("CNPJ");

                entity.Property(e => e.Complement)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("COMPLEMENT");

                entity.Property(e => e.CreateRegister)
                    .HasPrecision(7)
                    .HasColumnName("CREATE_REGISTER")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP ");

                entity.Property(e => e.DeletedRegister)
                    .HasPrecision(7)
                    .HasColumnName("DELETED_REGISTER");

                entity.Property(e => e.District)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DISTRICT");

                entity.Property(e => e.FantasyName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FANTASY_NAME");

                entity.Property(e => e.State)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("STATE");

                entity.Property(e => e.Status)
                    .HasPrecision(1)
                    .HasColumnName("STATUS")
                    .HasDefaultValueSql("0 ");

                entity.Property(e => e.Street)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STREET");

                entity.Property(e => e.UpdateRegister)
                    .HasPrecision(7)
                    .HasColumnName("UPDATE_REGISTER")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP ");

                entity.Property(e => e.UpdateStatus)
                    .HasPrecision(7)
                    .HasColumnName("UPDATE_STATUS")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP ");

                entity.Property(e => e.UserId)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("USER_ID");

                entity.Property(e => e.ZipCode)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ZIP_CODE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
