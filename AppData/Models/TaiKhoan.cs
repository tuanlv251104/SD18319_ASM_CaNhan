using AppData.Models;

namespace AppData.Models
{
    public class TaiKhoan
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }

        public virtual GioHang GioHang { get; set; }
        public virtual List<HoaDon> HoaDons { get; set; }
    }
}
