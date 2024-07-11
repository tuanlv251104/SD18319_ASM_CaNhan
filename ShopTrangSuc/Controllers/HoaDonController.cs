using AppData.Models;
using Microsoft.AspNetCore.Mvc;

namespace ShopTrangSuc.Controllers
{
    public class HoaDonController : Controller
    {
        AppDbContext _db;
        public HoaDonController()
        {
            _db = new AppDbContext();
        }
        public IActionResult Index()
        {
            //check xem đã đăng nhập chưa
                        var check = HttpContext.Session.GetString("username");
            if (string.IsNullOrEmpty(check))//
            {
                return RedirectToAction("Login", "TaiKhoan");
            }
            else
            {
                var Billitem = _db.hoaDons.Where(p => p.Username == check).ToList();
                return View(Billitem);
            }
        }
        //
        public IActionResult Details(Guid id)
        {
            var data = _db.hoaDonsCTs.Where(p => p.HoaDonId == id).ToList();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        //
        public IActionResult Update(Guid id)
        {
            var hoadonDelete = _db.hoaDons.Find(id);
            hoadonDelete.status = 100;
            _db.hoaDons.Update(hoadonDelete);
            var hoaDonCT = _db.hoaDonsCTs.Where(P => P.HoaDonId == id).ToList();
            foreach (var item in hoaDonCT)
            {
                item.status = 100;
                _db.hoaDonsCTs.Update(item);
                var sanPham = _db.sanPhams.Find(item.SanPhamId);
                sanPham.SoLuong += item.SoLuong;
                _db.sanPhams.Update(sanPham);
            }
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(HoaDon hoaDon)
        {
            try
            {
                var Update = _db.hoaDons.Find(hoaDon.Id);
                Update.status = hoaDon.status;
                Update.NgayMua = hoaDon.NgayMua;
                _db.hoaDons.Update(Update);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
