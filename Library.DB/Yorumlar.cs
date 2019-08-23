namespace Library.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Yorumlar")]
    public partial class Yorumlar
    {
        public int ID { get; set; }

        public int? kitapID { get; set; }

        [Display(Name = "Kullan�c� Ad�")]
        public int? kullaniciID { get; set; }

        [Display(Name = "Yorum")]
        public string yorum { get; set; }

        [Display(Name = "Olu�turma Tarihi")]
        public DateTime? olusturmaTarihi { get; set; }

        public bool? isActive { get; set; }

        public virtual Kitaplar Kitaplar { get; set; }

        public virtual Kullanicilar Kullanicilar { get; set; }
    }
}
