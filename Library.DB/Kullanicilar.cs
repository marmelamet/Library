namespace Library.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kullanicilar")]
    public partial class Kullanicilar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kullanicilar()
        {
            KullanimDetays = new HashSet<KullanimDetay>();
            Yorumlars = new HashSet<Yorumlar>();
        }

        public int ID { get; set; }

        [Display(Name = "Rolü")]
        public int rolID { get; set; }

        [Required]
        [StringLength(11)]
        [Display(Name = "TC Kimlik No")]
        public string TCKimlik { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Kullanýcý Adý")]
        public string kullaniciAdi { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Þifre")]
        public string sifre { get; set; }

        [StringLength(50)]
        [Display(Name = "Ad")]
        public string ad { get; set; }

        [StringLength(50)]
        [Display(Name = "Soyad")]
        public string soyad { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "E-Posta")]
        public string email { get; set; }

        [Display(Name = "Þehir")]
        public int? sehirId { get; set; }

        [StringLength(500)]
        [Display(Name = "Adres")]
        public string adres { get; set; }

        [Display(Name = "Oluþturma Tarihi")]
        public DateTime? olusturmaTarihi { get; set; }

        public bool? isActive { get; set; }

        public virtual iller iller { get; set; }

        public virtual Roller Roller { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KullanimDetay> KullanimDetays { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Yorumlar> Yorumlars { get; set; }
    }
}
