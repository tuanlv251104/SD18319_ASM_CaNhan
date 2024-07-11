using AppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Request
{
    public class TaiKhoanRequest
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? SoDienThoai { get; set; }
        public string? Email { get; set; }
        public string? DiaChi { get; set; }

        public virtual GioHang? GioHang { get; set; }
        public virtual List<HoaDon>? HoaDons { get; set; }
    }
}
