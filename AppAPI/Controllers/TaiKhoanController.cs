using AppAPI.IRepository;
using AppData.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaiKhoanController : ControllerBase
    {
        private readonly ITaiKhoanRepo _repo;
        AppDbContext _db;
        public TaiKhoanController(ITaiKhoanRepo taiKhoanRepo)
        {
            _repo = taiKhoanRepo;
            _db = new AppDbContext();
        }
        [HttpGet("get-tk")]
        public IActionResult GetAll()
        {
            return Ok(_db.taiKhoans.ToList());
        }
        [HttpGet("get-byid-tk")]
        public IActionResult GetById(string username)
        {
            try
            {
                return Ok(_db.taiKhoans.FirstOrDefault(p=> p.Username == username));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost("create-tk")]
        public IActionResult CreateTaiKhoan(TaiKhoan taiKhoan)
        {
            try
            {
                _db.taiKhoans.Add(taiKhoan);
                _db.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPut("update-tk")]
        public IActionResult UpdateTaiKhoan(string username, TaiKhoan taiKhoan)
        {
            try
            {
                var updateItem = _db.taiKhoans.Find(taiKhoan.Username);
                updateItem.Password = taiKhoan.Password;
                updateItem.SoDienThoai = taiKhoan.SoDienThoai;
                updateItem.DiaChi = taiKhoan.DiaChi;
                updateItem.Email = taiKhoan.Email;
                _db.Update(updateItem);
                _db.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpDelete("delete-tk")]
        public IActionResult DeleteTaiKhoan(string username)
        {
            try
            {
                var deleteItem = _db.taiKhoans.Find(username);
                _db.Remove(deleteItem);
                _db.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
