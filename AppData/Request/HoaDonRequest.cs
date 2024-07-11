using AppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Request
{
    public class HoaDonRequest
    {
        public Guid Id { get; set; }
        public DateTime? NgayMua { get; set; }
        public decimal? Tien { get; set; }
        public string? Username { get; set; }
        public int? status { get; set; }
        public virtual List<HoaDonCT>? HoaDonCTs { get; set; }
        public virtual TaiKhoan? TaiKhoan { get; set; }
    }
}
