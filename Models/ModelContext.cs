using Microsoft.EntityFrameworkCore;

namespace ConstruAppAPI.Models
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; } = null!;
        public virtual DbSet<PurchaseOrderItem> PurchaseOrderItems { get; set; } = null!;
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; } = null!;
        public virtual DbSet<UserAdmin> UserAdmins { get; set; } = null!;
        public virtual DbSet<UserClient> UserClients { get; set; } = null!;
        public virtual DbSet<UserSeller> UserSellers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("User Id=CONSTRUAPP;Password=construapp;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=XEPDB1)))");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("CONSTRUAPP")
                .UseCollation("USING_NLS_COMP");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("CATEGORIES");

                entity.HasIndex(e => e.Name, "SYS_C0010968")
                    .IsUnique();

                entity.HasIndex(e => e.Label, "SYS_C0010969")
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

                entity.HasIndex(e => e.Name, "SYS_C0010986")
                    .IsUnique();

                entity.HasIndex(e => e.Label, "SYS_C0010987")
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

                entity.HasIndex(e => e.FullName, "SYS_C0010998")
                    .IsUnique();

                entity.HasIndex(e => e.Cpf, "SYS_C0010999")
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

                entity.HasIndex(e => e.FullName, "SYS_C0011015")
                    .IsUnique();

                entity.HasIndex(e => e.Cpf, "SYS_C0011016")
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

                entity.HasIndex(e => e.FantasyName, "SYS_C0011032")
                    .IsUnique();

                entity.HasIndex(e => e.Cnpj, "SYS_C0011033")
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

            modelBuilder.HasSequence("CATEGORYSEQ");

            modelBuilder.HasSequence("PRODUCTSEQ");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
