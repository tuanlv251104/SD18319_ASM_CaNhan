﻿using AppData.Models;

namespace AppData.Models
{
    public class GioHangCT
    {
        public Guid Id { get; set; }
        public Guid SanPhamId { get; set; }
        public string Username { get; set; }
        public int SoLuong { get; set; }
        public int Status { get; set; }
        public virtual GioHang GioHang { get; set; }
        public virtual SanPham SanPham { get; set; }
    }
}
