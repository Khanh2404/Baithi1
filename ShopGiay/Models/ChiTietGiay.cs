using System.ComponentModel.DataAnnotations;

namespace ShopGiay.Models
{
    public class ChiTietGiay
    {
        [Key] // Đánh dấu MaGiay là khóa chính
        public int MaGiay { get; set; }

        [Required]
        public string? TenGiay { get; set; }

        [Range(1, 50)]
        public int KichCo { get; set; }

        public string? MauSac { get; set; }

        [DataType(DataType.Currency)]
        public decimal Gia { get; set; }

        // Khóa ngoại liên kết với LoaiGiay
        public int MaLoaiGiay { get; set; }
        public LoaiGiay? LoaiGiay { get; set; }
    }
}
