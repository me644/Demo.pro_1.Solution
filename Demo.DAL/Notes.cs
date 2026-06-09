#region Notes

using Demo.DAL.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Collections.Specialized.BitVector32;
#region DI

////services.AddScoped<AppDbContext>();
////Internally, it does not create an AppDbContext yet. It basically:

////csharp
////Copy code
////services.Add(new ServiceDescriptor(
////    ServiceType: typeof(AppDbContext),
////    ImplementationType: typeof(AppDbContext),
////    Lifetime: ServiceLifetime.Scoped
////));
///  public class Program
//{
//        public static void Main(string[] args)
//{
//    var builder = WebApplication.CreateBuilder(args);

//    // Add services to the container.
//    builder.Services.AddControllersWithViews();


//    //📌Let`s inject life itme
//    ///
//    builder.Services.AddDbContext<APP_1>(option => option.UseSqlServer(



//                        //  builder.Configuration["ConnectionString=DefulatConnectionString"])

//                        builder.Configuration.GetConnectionString("DefaultConnectionString")


//    ));
//    var app = builder.Build();

//    // Configure the HTTP request pipeline.
//    if (!app.Environment.IsDevelopment())
//    {
//        app.UseExceptionHandler("/Home/Error");
//        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//        app.UseHsts();
//    }

//    app.UseHttpsRedirection();
//    app.UseStaticFiles();

//    app.UseRouting();

//    app.UseAuthorization();

//    app.MapControllerRoute(
//        name: "default",
//        pattern: "{controller=Home}/{action=Index}/{id?}");

//    app.Run();
//}
//    }
//}


#endregion


#endregion


//public partial class AlfaSetUpContext : DbContext
//{
//    public AlfaSetUpContext()
//    {
//    }

//    public AlfaSetUpContext(DbContextOptions<AlfaSetUpContext> options)
//        : base(options)
//    {
//    }

//    public virtual DbSet<Company> Companies { get; set; }

//    //public virtual DbSet<Depot> Depots { get; set; }

//    //public virtual DbSet<DepotsFarm> DepotsFarms { get; set; }

//    public virtual DbSet<Farm> Farms { get; set; }

//    public virtual DbSet<IrrigationSpot> IrrigationSpots { get; set; }

//    //   public virtual DbSet<IrrigationWell> IrrigationWells { get; set; }

//    public virtual DbSet<Irrigration> Irrigrations { get; set; }

//    public virtual DbSet<Line> Lines { get; set; }

//    // public virtual DbSet<Palm> Palms { get; set; }

//    public virtual DbSet<Section> Sections { get; set; }

//    public virtual DbSet<Spot> Spots { get; set; }

//    //public virtual DbSet<SpotPalm> SpotPalms { get; set; }

//    //  public virtual DbSet<Well> Wells { get; set; }

//    //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//    //            => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=alfa_SetUp;Username=postgres;Password=medo20049");

//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        modelBuilder.Entity<Company>(entity =>
//        {
//            entity.HasKey(e => e.CoId).HasName("farm_pkey");

//            entity.ToTable("company");

//            entity.Property(e => e.CoId)
//                .ValueGeneratedNever()
//                .HasColumnName("co_id");
//            entity.Property(e => e.CoName)
//                .HasMaxLength(12)
//                .HasColumnName("co_name");
//        });

//        modelBuilder.Entity<Irrigation_Commponent>(entity =>
//        {
//            entity.Property(e => e.CM_ID).ValueGeneratedNever();
//            entity.Property(e => e.CM_Name).HasColumnType("varchar(100)");
//            entity.Property(e => e.CM_Spec).HasColumnType("nvarchar(max)");



//        });
//        modelBuilder.Entity<Depot>(entity =>
//        {
//            entity.HasKey(e => e.DeId).HasName("depots_pkey");

//            entity.ToTable("depots");

//            entity.Property(e => e.DeId)
//                .ValueGeneratedNever()
//                .HasColumnName("de_id");
//            entity.Property(e => e.DeDis)
//                .HasMaxLength(30)
//                .HasColumnName("de_dis");
//            entity.Property(e => e.DeName)
//                .HasMaxLength(20)
//                .HasColumnName("de_name");
//        });

//        modelBuilder.Entity<DepotsFarm>(entity =>
//        {
//            entity.HasKey(e => new { e.FaId, e.DeId }).HasName("depots_farms_pkey");

//            entity.ToTable("depots_farms");

//            entity.HasIndex(e => e.DeId, "depots_farms_de_id_key").IsUnique();

//            entity.Property(e => e.FaId).HasColumnName("fa_id");
//            entity.Property(e => e.DeId).HasColumnName("de_id");
//            entity.Property(e => e.EndTime).HasColumnName("end_time");
//            entity.Property(e => e.StartTime).HasColumnName("start_time");

//            entity.HasOne(d => d.De).WithOne(p => p.DepotsFarm)
//                .HasForeignKey<DepotsFarm>(d => d.DeId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("depots_farms_de_id_fkey");

//            entity.HasOne(d => d.Fa).WithMany(p => p.DepotsFarms)
//                .HasForeignKey(d => d.FaId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("depots_farms_fa_id_fkey");
//        });

//        modelBuilder.Entity<Farm>(entity =>
//        {
//            entity.HasKey(e => e.FaId).HasName("field_pkey");

//            entity.ToTable("farms");

//            entity.Property(e => e.FaId)
//                .ValueGeneratedNever()
//                .HasColumnName("fa_id");
//            entity.Property(e => e.CoId).HasColumnName("co_id");
//            entity.Property(e => e.FiName)
//                .HasMaxLength(15)
//                .HasColumnName("fi_name");

//            entity.HasOne(d => d.Co).WithMany(p => p.Farms)
//                .HasForeignKey(d => d.CoId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("field_fa_id_fkey");
//        });

//        //modelBuilder.Entity<IrrigationSpot>(entity =>
//        {
//            entity.HasKey(e => new { e.IrItemId, e.SpId }).HasName("irrigation_spot_pkey");

//            entity.ToTable("irrigation_spot");

//            entity.HasIndex(e => e.SpId, "irrigation_spot_sp_id_key").IsUnique();

//            entity.Property(e => e.IrItemId).HasColumnName("ir_item_id");
//            entity.Property(e => e.SpId).HasColumnName("sp_id");
//            entity.Property(e => e.EndTime).HasColumnName("end_time");
//            entity.Property(e => e.StartTime).HasColumnName("start_time");

//            entity.HasOne(d => d.IrItem).WithMany(p => p.IrrigationSpots)
//                .HasForeignKey(d => d.IrItemId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("irrigation_spot_ir_item_id_fkey");

//            entity.HasOne(d => d.Sp).WithOne(p => p.IrrigationSpot)
//                .HasForeignKey<IrrigationSpot>(d => d.SpId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("irrigation_spot_sp_id_fkey");
//        });

//        modelBuilder.Entity<IrrigationWell>(entity =>
//        {
//            entity.HasKey(e => new { e.IrItemId, e.WeId }).HasName("irrigation_well_pkey");

//            entity.ToTable("irrigation_well");

//            entity.Property(e => e.IrItemId).HasColumnName("ir_item_id");
//            entity.Property(e => e.WeId).HasColumnName("we_id");
//            entity.Property(e => e.EndTime).HasColumnName("end_time");
//            entity.Property(e => e.StartTime).HasColumnName("start_time");

//            entity.HasOne(d => d.IrItem).WithMany(p => p.IrrigationWells)
//                .HasForeignKey(d => d.IrItemId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("irrigation_well_ir_item_id_fkey");

//            entity.HasOne(d => d.We).WithMany(p => p.IrrigationWells)
//                .HasForeignKey(d => d.WeId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("irrigation_well_we_id_fkey");
//        });

//        modelBuilder.Entity<Irrigration>(entity =>
//        {
//            entity.HasKey(e => e.IrItemId).HasName("irrigration_pkey");

//            entity.ToTable("irrigration");

//            entity.HasIndex(e => e.FkIrItemId, "irrigration2").IsUnique();

//            entity.Property(e => e.IrItemId)
//                .ValueGeneratedNever()
//                .HasColumnName("ir_item_id");
//            entity.Property(e => e.FkIrItemId).HasColumnName("fk_ir_item_id");
//            entity.Property(e => e.IrItemDesc)
//                .HasMaxLength(100)
//                .HasColumnName("ir_item_desc");
//            entity.Property(e => e.IrItemName)
//                .HasMaxLength(20)
//                .HasColumnName("ir_item_name");

//            entity.HasOne(d => d.FkIrItem).WithOne(p => p.InverseFkIrItem)
//                .HasForeignKey<Irrigration>(d => d.FkIrItemId)
//                .HasConstraintName("irrigration_fk_ir_item_id_fkey");


//            entity.HasOne(i => i.Irrigation_Commponent).WithOne(c => c.irrigration).HasForeignKey<Irrigation_Commponent>(i => i.CM_ID);
//        });

//        modelBuilder.Entity<Line>(entity =>
//        {
//            entity.HasKey(e => e.LiId).HasName("lines_pkey");

//            entity.ToTable("lines");

//            entity.Property(e => e.LiId)
//                .ValueGeneratedNever()
//                .HasColumnName("li_id");
//            entity.Property(e => e.ScId).HasColumnName("sc_id");

//            entity.HasOne(d => d.Sc).WithMany(p => p.Lines)
//                .HasForeignKey(d => d.ScId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("lines_sc_id_fkey");
//        });

//        modelBuilder.Entity<Palm>(entity =>
//        {
//            entity.HasKey(e => e.PaId).HasName("palm_pkey");

//            entity.ToTable("palm");

//            entity.Property(e => e.PaId)
//                .ValueGeneratedNever()
//                .HasColumnName("pa_id");
//            entity.Property(e => e.PaAge).HasColumnName("pa_age");
//            entity.Property(e => e.PaType)
//                .HasMaxLength(20)
//                .HasColumnName("pa_type");
//        });

//        modelBuilder.Entity<Section>(entity =>
//        {
//            entity.HasKey(e => e.ScId).HasName("sections_pkey");

//            entity.ToTable("sections");

//            entity.Property(e => e.ScId)
//                .ValueGeneratedNever()
//                .HasColumnName("sc_id");
//            entity.Property(e => e.FiId).HasColumnName("fi_id");

//            entity.HasOne(d => d.Fi).WithMany(p => p.Sections)
//                .HasForeignKey(d => d.FiId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("sections_fi_id_fkey");
//        });

//        modelBuilder.Entity<Spot>(entity =>
//        {
//            entity.HasKey(e => e.SpId).HasName("spot_pkey");

//            entity.ToTable("spot");

//            entity.Property(e => e.SpId)
//                .ValueGeneratedNever()
//                .HasColumnName("sp_id");
//            entity.Property(e => e.LiId).HasColumnName("li_id");

//            entity.HasOne(d => d.Li).WithMany(p => p.Spots)
//                .HasForeignKey(d => d.LiId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("spot_li_id_fkey");
//        });

//        modelBuilder.Entity<SpotPalm>(entity =>
//        {
//            entity.HasKey(e => new { e.PaId, e.SpId }).HasName("spot_palm_pkey");

//            entity.ToTable("spot_palm");

//            entity.HasIndex(e => e.PaId, "spot_palm_pa_id_key").IsUnique();

//            entity.HasIndex(e => e.SpId, "spot_palm_sp_id_key").IsUnique();

//            entity.Property(e => e.PaId).HasColumnName("pa_id");
//            entity.Property(e => e.SpId).HasColumnName("sp_id");
//            entity.Property(e => e.EndTime).HasColumnName("end_time");
//            entity.Property(e => e.StartTime).HasColumnName("start_time");

//            entity.HasOne(d => d.Pa).WithOne(p => p.SpotPalm)
//                .HasForeignKey<SpotPalm>(d => d.PaId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("spot_palm_pa_id_fkey");

//            entity.HasOne(d => d.Sp).WithOne(p => p.SpotPalm)
//                .HasForeignKey<SpotPalm>(d => d.SpId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("spot_palm_sp_id_fkey");
//        });

//        modelBuilder.Entity<Well>(entity =>
//        {
//            entity.HasKey(e => e.WeId).HasName("well_pkey");

//            entity.ToTable("well");

//            entity.Property(e => e.WeId)
//                .ValueGeneratedNever()
//                .HasColumnName("we_id");
//            entity.Property(e => e.WeDepth).HasColumnName("we_depth");
//            entity.Property(e => e.WeEul).HasColumnName("we_eul");
//        });

//        OnModelCreatingPartial(modelBuilder);
//    }

//    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
//}

//public class IrrigationSpot
//{
//}

