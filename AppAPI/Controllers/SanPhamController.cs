using AppAPI.IRepository;
using AppData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        private readonly ISanPhamRepo _repo;
        AppDbContext _db = new AppDbContext();
        public SanPhamController(ISanPhamRepo repo)
        {
            _repo = repo;
        }
        [HttpGet("get_sp")]
        public IActionResult GetAllSanPham(SanPham sanPham)
        {
            return Ok(_db.sanPhams.ToList());
        }
        [HttpPost("create_sp")]
        public IActionResult CreateSanPham(SanPham sanPham)
        {
            try
            {
                _db.sanPhams.Add(sanPham);
                _db.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPut("update_sp")]
        public IActionResult UpdateSanPham(Guid id, SanPham sanPham)
        {
            try
            {
                var updateItem = _db.sanPhams.Find(sanPham.Id);
                updateItem.AnhSP = sanPham.AnhSP;
                updateItem.TenSP = sanPham.TenSP;
                updateItem.MoTa = sanPham.MoTa;
                updateItem.GiaSP = sanPham.GiaSP;
                updateItem.ChatLieu = sanPham.ChatLieu;
                updateItem.HangCungCap = sanPham.HangCungCap;
                updateItem.LoaiSP = sanPham.LoaiSP;
                updateItem.SoLuong = sanPham.SoLuong;
                _db.sanPhams.Update(updateItem);
                _db.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpDelete("delete_sp")]
        public IActionResult DeleteSanPham(Guid id)
        {
            try
            {
                var deleteItem = _db.sanPhams.Find(id);
                _db.Remove(deleteItem);
                _db.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("get_by_id_sp")]
        public IActionResult GeByIdSanPham(Guid id)
        {
            try
            {
                return Ok(_db.sanPhams.FirstOrDefault(p=> p.Id == id));
            }
            catch(Exception)
            {
                return BadRequest();
            }
        }
    }
}
