using AppData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaDonController : ControllerBase
    {
        //private readonly AppDbContext _db;
        AppDbContext _db;
        public HoaDonController(AppDbContext db)
        {
            _db = new AppDbContext();
        }
        [HttpGet("get_hd")]
        public IActionResult GetAllHoaDon()
        {
            return Ok(_db.hoaDons.ToList());
        }
    }
}
