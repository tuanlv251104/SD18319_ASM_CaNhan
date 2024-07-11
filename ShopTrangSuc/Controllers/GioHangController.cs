using AppData.Models;
using Microsoft.AspNetCore.Mvc;
using AppData.IRepository;

namespace ShopTrangSuc.Controllers
{
    public class GioHangController : Controller
    {
        AppDbContext _db;
        public GioHangController()
        {
            _db = new AppDbContext();
        }
        public IActionResult Index()
        {
            var check = HttpContext.Session.GetString("username");
            if (string.IsNullOrEmpty(check))
            {
                return RedirectToAction("Login", "TaiKhoan");
            }
            else
            {
                var cartItem = _db.GioHangCTs.Where(p => p.Username == check).ToList();
                return View(cartItem);
            }
        }
        //
        public IActionResult AddHoaDon(Guid id)
        {
            var check = HttpContext.Session.GetString("username");
            if (string.IsNullOrEmpty(check))
            {
                return RedirectToAction("Login", "TaiKhoan");
            }
            else
            {
                var billItem = _db.GioHangCTs.FirstOrDefault(p => p.Username == check);
                if (billItem == null) return Content("Không có sản phẩm trong giỏ hàng");
                else
                {
                    decimal TongTien = 0;
                    foreach (var item in _db.GioHangCTs.Where(p => p.Username == check).ToList())
                    {
                        var sanPham = _db.sanPhams.FirstOrDefault(p => p.Id == item.SanPhamId);
                        if (sanPham != null)
                        {
                            TongTien += sanPham.GiaSP * item.SoLuong;
                        }
                    }
                    HoaDon hoaDon = new HoaDon()
                    {
                        Id = Guid.NewGuid(),
                        status = 1,
                        Username = check,
                        NgayMua = DateTime.Today,
                        Tien = TongTien,
                    };
                    _db.hoaDons.Add(hoaDon);
                    _db.SaveChanges();
                    foreach (var item in _db.GioHangCTs.Where(p => p.Username == check).ToList())
                    {
                        HoaDonCT hoaDonCT = new HoaDonCT()
                        {
                            Id = Guid.NewGuid(),
                            HoaDonId = hoaDon.Id,
                            SanPhamId = item.SanPham.Id,
                            SoLuong = item.SoLuong,
                            status = 1,
                        };
                        var data = _db.sanPhams.FirstOrDefault(p => p.Id == hoaDonCT.SanPhamId);
                        data.SoLuong = data.SoLuong - hoaDonCT.SoLuong;
                        _db.hoaDonsCTs.Add(hoaDonCT);
                        _db.GioHangCTs.Remove(item);
                    }
                    _db.SaveChanges();
                }
            }
            return RedirectToAction("Index", "HoaDon");
        }
        //
        public IActionResult Delete(Guid id)
        {
            var cart = _db.GioHangCTs.Find(id);
            _db.GioHangCTs.Remove(cart);
            return RedirectToAction("Index");
        }
    }
}
