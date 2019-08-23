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
        [Display(Name = "Verildi�i Tarih")]
        public DateTime? teslimTarihi { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "�ade Al�nan Tarih")]
        public DateTime? iadeTarihi { get; set; }

        [Display(Name = "G�n Say�s�")]
        public int? gunSayisi { get; set; }

        [Display(Name = "�denecek Miktar")]
        public decimal? ceza { get; set; }

        [Display(Name = "Olu�turma Tarihi")]
        public DateTime? olusturmaTarihi { get; set; }

        public bool? isActive { get; set; }

        public virtual Kitaplar Kitaplar { get; set; }

        public virtual Kullanicilar Kullanicilar { get; set; }
    }
}
