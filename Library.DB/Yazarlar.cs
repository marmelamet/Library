namespace Library.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Yazarlar")]
    public partial class Yazarlar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Yazarlar()
        {
            Kitaplars = new HashSet<Kitaplar>();
        }

        public int ID { get; set; }

        [StringLength(50)]
        [Display(Name = "Yazar Adý")]
        public string ad { get; set; }

        [StringLength(50)]
        [Display(Name = "Yazar Soyadý")]
        public string soyad { get; set; }

        [Display(Name = "Oluþturma Tarihi")]
        public DateTime? olusturmaTarihi { get; set; }

        public bool? isActive { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kitaplar> Kitaplars { get; set; }
    }
}
