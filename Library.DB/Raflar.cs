namespace Library.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Raflar")]
    public partial class Raflar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Raflar()
        {
            Kitaplars = new HashSet<Kitaplar>();
        }

        public int ID { get; set; }

        [Display(Name = "T�r ID")]
        public int? turID { get; set; }

        [StringLength(50)]
        [Display(Name ="Raf Ad�")]
        public string ad { get; set; }

        [Display(Name = "Raf Say�s�")]
        public int? rafSayisi { get; set; }

        [Display(Name = "Olu�turma Tarihi")]
        public DateTime? olusturmaTarihi { get; set; }

        public bool? isActive { get; set; }

        public virtual Turler Turler { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kitaplar> Kitaplars { get; set; }
    }
}
