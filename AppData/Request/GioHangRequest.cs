using AppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Request
{
    public class GioHangRequest
    {
        public string? Username { get; set; }
        public int? Status { get; set; }
        public virtual TaiKhoan? TaiKhoan { get; set; }
        public virtual List<GioHangCT>? GioHangCTs { get; set; }
    }
}
