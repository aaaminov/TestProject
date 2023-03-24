using Microsoft.EntityFrameworkCore;

namespace TestProject.Models {
    public partial class TestProjectDBContext : DbContext {

        public static TestProjectDBContext Instance { get; set; } = new TestProjectDBContext();

        public TestProjectDBContext() { }

        public TestProjectDBContext(DbContextOptions<TestProjectDBContext> options) : base(options) { }

        public virtual DbSet<Brand_Car> brand_car { get; set; } = null!;
        public virtual DbSet<Model_Car> model_car { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            if (!optionsBuilder.IsConfigured) {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=db_cars;Username=postgres;Password=2232");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Brand_Car>(entity => {
                entity.HasKey(e => e.id)
                    .HasName("brand_car_pkey");

                entity.Property(e => e.id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");
            });

            modelBuilder.Entity<Model_Car>(entity => {
                entity.HasKey(e => e.id)
                    .HasName("model_car_pkey");

                entity.Property(e => e.id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.brand_id).HasColumnName("brand_id");

                entity.HasOne(d => d.brand)
                    .WithMany(p => p.models)
                    .HasForeignKey(d => d.brand_id)
                    .HasConstraintName("model_car_brand_id_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
