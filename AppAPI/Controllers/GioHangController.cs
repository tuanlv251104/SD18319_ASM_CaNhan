using AppAPI.IRepository;
using AppData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GioHangController : ControllerBase
    {
        private readonly IGioHangRepo _repo;
        AppDbContext _db;
        public GioHangController(IGioHangRepo repo)
        {
            _repo = repo;
            _db = new AppDbContext();
        }
        [HttpGet("get_gh")]
        public IActionResult GetAll()
        {
            return Ok(_db.gioHang.ToList());
        }
    }
}
