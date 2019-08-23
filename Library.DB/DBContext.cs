namespace Library.DB
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Z.EntityFramework.Plus;

    public partial class DBContext : DbContext
    {
        public DBContext()
            : base("name=DBContext")
        {
            QueryFilterManager.Filter<Kitaplar>(c => c.Where(x => x.isActive == true));
            QueryFilterManager.Filter<KullanimDetay>(c => c.Where(x => x.isActive == true));
            QueryFilterManager.Filter<Raflar>(c => c.Where(x => x.isActive == true));
            QueryFilterManager.Filter<Yorumlar>(c => c.Where(x => x.isActive == true));
            QueryFilterManager.InitilizeGlobalFilter(this);
        }

        public virtual DbSet<iller> iller { get; set; }
        public virtual DbSet<Kitaplar> Kitaplar { get; set; }
        public virtual DbSet<Kullanicilar> Kullanicilar { get; set; }
        public virtual DbSet<KullanimDetay> KullanimDetay { get; set; }
        public virtual DbSet<Raflar> Raflar { get; set; }
        public virtual DbSet<Roller> Roller { get; set; }
        public virtual DbSet<Turler> Turler { get; set; }
        public virtual DbSet<Yazarlar> Yazarlar { get; set; }
        public virtual DbSet<Yorumlar> Yorumlar { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<iller>()
                .HasMany(e => e.Kullanicilars)  //1->n
                .WithOptional(e => e.iller)     //Nullable
                .HasForeignKey(e => e.sehirId); //Foreign Key

            modelBuilder.Entity<Kitaplar>()
                .HasMany(e => e.KullanimDetays)
                .WithOptional(e => e.Kitaplar)
                .HasForeignKey(e => e.kitapID);

            modelBuilder.Entity<Kitaplar>()
                .HasMany(e => e.Yorumlars) 
                .WithOptional(e => e.Kitaplar)
                .HasForeignKey(e => e.kitapID);

            modelBuilder.Entity<Kullanicilar>()
                .HasMany(e => e.KullanimDetays)
                .WithOptional(e => e.Kullanicilar)
                .HasForeignKey(e => e.kullaniciID);

            modelBuilder.Entity<Kullanicilar>()
                .HasMany(e => e.Yorumlars)
                .WithOptional(e => e.Kullanicilar)
                .HasForeignKey(e => e.kullaniciID);

            modelBuilder.Entity<KullanimDetay>()
                .Property(e => e.ceza)
                .HasPrecision(18, 4);

            modelBuilder.Entity<Raflar>()
                .HasMany(e => e.Kitaplars)
                .WithRequired(e => e.Raflar)
                .HasForeignKey(e => e.rafId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Roller>()
                .HasMany(e => e.Kullanicilars)
                .WithRequired(e => e.Roller)
                .HasForeignKey(e => e.rolID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Turler>()
                .HasMany(e => e.Kitaplars)
                .WithRequired(e => e.Turler)
                .HasForeignKey(e => e.turId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Turler>()
                .HasMany(e => e.Raflars)
                .WithRequired(e => e.Turler)
                .HasForeignKey(e => e.turID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Yazarlar>()
                .HasMany(e => e.Kitaplars)
                .WithRequired(e => e.Yazarlar)
                .HasForeignKey(e => e.yazarID)
                .WillCascadeOnDelete(false);
        }
        public override int SaveChanges()
        {
            foreach (var entry in this.ChangeTracker.Entries().Where(c =>
                 c.Entity.GetType().GetProperty("isActive") != null &&
                 c.State == EntityState.Added))
            {
                entry.Property("isActive").CurrentValue = true;
                entry.Property("olusturmaTarihi").CurrentValue = DateTime.Now;
            }

            foreach (var entry in this.ChangeTracker.Entries().Where(
                e =>
                    e.Entity.GetType().GetProperty("isActive") != null &&
                    e.State == EntityState.Deleted))
            {
                entry.Property("isActive").CurrentValue = false;
                entry.State = EntityState.Modified;
            }
            return base.SaveChanges();
        }
    }
}
