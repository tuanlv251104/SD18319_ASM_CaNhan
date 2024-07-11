using AppData.Models;

namespace AppData.Models
{
    public class HoaDon
    {
        public Guid Id { get; set; }
        public DateTime NgayMua { get; set; }
        public decimal Tien { get; set; }
        public string Username { get; set; }
        public int status { get; set; }
        public virtual List<HoaDonCT> HoaDonCTs { get; set; }
        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
