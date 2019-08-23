namespace Library.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Turler")]
    public partial class Turler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Turler()
        {
            Kitaplars = new HashSet<Kitaplar>();
            Raflars = new HashSet<Raflar>();
        }

        public int ID { get; set; }

        [StringLength(50)]
        [Display(Name = "Tür Adý")]
        public string ad { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kitaplar> Kitaplars { get; set; }
        public virtual ICollection<Raflar> Raflars { get; set; }
    }
}
