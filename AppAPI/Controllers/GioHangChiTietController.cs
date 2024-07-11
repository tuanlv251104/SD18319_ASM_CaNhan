using AppAPI.IRepository;
using AppData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GioHangChiTietController : ControllerBase
    {
        private readonly IGioHangChiTietRepo _repo;
        AppDbContext _db;
        public GioHangChiTietController(IGioHangChiTietRepo repo)
        {
            _repo = repo;
            _db = new AppDbContext();
        }
        [HttpGet("get_ghct")]
        public IActionResult GetAllGioHangCT()
        {
            return Ok(_db.GioHangCTs.ToList());
        }
        [HttpPost("get_ghct")]
        public IActionResult CreateGHCt(GioHangCT ghct)
        {
            try
            {
                _db.GioHangCTs.Add(ghct);
                _db.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        //[HttpPost("get_ghct")]
        //public IActionResult UpdateGHCT()
        //{
        //    return Ok(_repo.GetGioHangCT());
        //}
        //[HttpPost("get_ghct")]
        //public IActionResult DeleteGHCT()
        //{
        //    return Ok(_repo.GetGioHangCT());
        //}
    }
}
