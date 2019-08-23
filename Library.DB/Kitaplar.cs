namespace Library.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kitaplar")]
    public partial class Kitaplar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kitaplar()
        {
            KullanimDetays = new HashSet<KullanimDetay>();
            Yorumlars = new HashSet<Yorumlar>();
        }

        public int ID { get; set; }

        public int turId { get; set; }

        public int yazarID { get; set; }

        public int rafId { get; set; }

        [StringLength(50)]
        public string ISBN { get; set; }

        [StringLength(50)]
        [Display(Name = "Kitap Adý")]
        public string ad { get; set; }

        [StringLength(50)]
        [Display(Name = "Yayýnevi")]
        public string yayinevi { get; set; }

        [StringLength(50)]
        [Display(Name = "Çevirmen")]
        public string cevirmen { get; set; }

        [StringLength(4)]
        [Display(Name = "Basým Yýlý")]
        public string basimYili { get; set; }

        [Display(Name = "Oluþturma Tarihi")]
        public DateTime olusturmaTarihi { get; set; }

        public bool? isActive { get; set; }

        public virtual Raflar Raflar { get; set; }

        public virtual Turler Turler { get; set; }

        public virtual Yazarlar Yazarlar { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KullanimDetay> KullanimDetays { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Yorumlar> Yorumlars { get; set; }
    }
}
