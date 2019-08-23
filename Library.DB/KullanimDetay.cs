namespace Library.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KullanimDetay")]
    public partial class KullanimDetay
    {
        public int ID { get; set; }

        public int? kitapID { get; set; }

        public int? kullaniciID { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Verildiði Tarih")]
        public DateTime? teslimTarihi { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Ýade Alýnan Tarih")]
        public DateTime? iadeTarihi { get; set; }

        [Display(Name = "Gün Sayýsý")]
        public int? gunSayisi { get; set; }

        [Display(Name = "Ödenecek Miktar")]
        public decimal? ceza { get; set; }

        [Display(Name = "Oluþturma Tarihi")]
        public DateTime? olusturmaTarihi { get; set; }

        public bool? isActive { get; set; }

        public virtual Kitaplar Kitaplar { get; set; }

        public virtual Kullanicilar Kullanicilar { get; set; }
    }
}
