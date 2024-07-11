using AppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Request
{
    public class HoaDonCTRequest
    {
        public Guid Id { get; set; }
        public Guid? SanPhamId { get; set; }
        public Guid? HoaDonId { get; set; }
        public int? SoLuong { get; set; }
        public decimal? TongTien { get; set; }
        public int? status { get; set; }
        public virtual SanPham? SanPham { get; set; }
        public virtual HoaDon? HoaDon { get; set; }
    }
}
