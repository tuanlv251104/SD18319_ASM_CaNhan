using AppData.Models;
using AppData.Request;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopTrangSuc.IService;
using System.IO;
using System.Net.Http;

namespace ShopTrangSuc.Controllers
{
    public class SanPhamController : Controller
    {
        AppDbContext _db;
        ISanPhamService _service;
        HttpClient _httpClient;
        public SanPhamController(ISanPhamService service)
        {
            _db = new AppDbContext();
            _service = service;
            _httpClient = new HttpClient();
        }
        //Danh sách sản phẩm
        public IActionResult Index()
        {
            var data = _db.sanPhams.ToList();
            return View(data);
        }
        //Thêm mới sản phẩm
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(SanPham sanPham, IFormFile imgFile)
        {

            // Thực hiện tạo 1 đường dẫn để trỏ tới thư mục wwwroot - nơi chứa ảnh
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", imgFile.FileName);
            // vd kết quả thu được sẽ có dạng wwwroot/img/concho.png;
            // Copy ảnh tải lên vào thư mục root
            var stream = new FileStream(path, FileMode.Create);
            imgFile.CopyTo(stream); // Copy cái ảnh mà được các bạn chọn vào cái stream đó
                                    // Cập nhật đường dẫn ảnh 
            sanPham.AnhSP = imgFile.FileName;
            _db.sanPhams.Add(sanPham);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        //Sửa sản phẩm
        public IActionResult Edit(Guid id)
        {
            var editItem = _db.sanPhams.Find(id);
            return View(editItem);
        }
        [HttpPost]
        public IActionResult Edit(Guid id, SanPham sanPham)
        {
            var editItem = _db.sanPhams.Find(sanPham.Id);
            editItem.AnhSP = sanPham.AnhSP;
            editItem.TenSP = sanPham.TenSP;
            editItem.MoTa = sanPham.MoTa;
            editItem.GiaSP = sanPham.GiaSP;
            editItem.ChatLieu = sanPham.ChatLieu;
            editItem.HangCungCap = sanPham.HangCungCap;
            editItem.LoaiSP = sanPham.LoaiSP;
            editItem.SoLuong = sanPham.SoLuong;
            _db.sanPhams.Update(editItem);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        //Xóa sản phẩm
        public IActionResult Delete(Guid id)
        {
            var delete = _db.sanPhams.Find(id);
            _db.sanPhams.Remove(delete);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        //Thêm vào giỏ hàng
        public IActionResult AddtoCart(Guid id, int soLuong)
        {
            var check = HttpContext.Session.GetString("username");
            if (string.IsNullOrEmpty(check))
            {
                return RedirectToAction("Login", "TaiKhoan");
            }
            else
            {
                var cartItem = _db.GioHangCTs.FirstOrDefault(p => p.SanPhamId == id && p.Username == check);
                if (cartItem == null)
                {
                    GioHangCT gioHangCT = new GioHangCT()
                    {
                        Id = Guid.NewGuid(),
                        SanPhamId = id,
                        SoLuong = soLuong,
                        Status = 1,
                        Username = check
                    };
                    _db.GioHangCTs.Add(gioHangCT);
                    _db.SaveChanges();
                }
                else
                {
                    cartItem.SoLuong = cartItem.SoLuong + soLuong;
                    _db.GioHangCTs.Update(cartItem);
                    _db.SaveChanges();
                }
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
