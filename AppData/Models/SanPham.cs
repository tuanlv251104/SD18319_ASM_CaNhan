using AppData.Models;

namespace AppData.Models
{
    public class SanPham
    {
        public Guid Id { get; set; }
        
        public string AnhSP { get; set; }
        public string TenSP { get; set; }
        public string MoTa { get; set; }
        public decimal GiaSP { get; set; }
        public string ChatLieu { get; set; }
        public string HangCungCap { get; set; }
        public string LoaiSP { get; set; }
        public int SoLuong { get; set; }
        public virtual List<HoaDonCT> HoaDonCTs { get; set; }
        public virtual List<GioHangCT> GioHangCTs { get; set; }
    }
}
