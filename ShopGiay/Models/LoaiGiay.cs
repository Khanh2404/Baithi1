using System.ComponentModel.DataAnnotations;

namespace ShopGiay.Models
{
    public class LoaiGiay
    {
        [Key] // Đánh dấu MaLoai là khóa chính
        public int MaLoai { get; set; }

        [Required]
        public string? TenLoai { get; set; }

        public string? MoTa { get; set; }
    }
}
