namespace Library.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Roller")]
    public partial class Roller
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Roller()
        {
            Kullanicilars = new HashSet<Kullanicilar>();
        }

        public int ID { get; set; }

        [StringLength(50)]
        [Display(Name = "Rol Adý")]
        public string rolAdi { get; set; }

        [StringLength(250)]
        [Display(Name = "Açýklama")]
        public string aciklama { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kullanicilar> Kullanicilars { get; set; }
    }
}
