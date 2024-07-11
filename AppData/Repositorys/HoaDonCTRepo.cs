using AppData.IRepository;
using AppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Repositorys
{
    internal class HoaDonCTRepo : IHoaDonCTRepo
    {
        AppDbContext _db;
        public HoaDonCTRepo(AppDbContext db)
        {
            _db = db;
        }
        public List<HoaDonCT> GetAllHoaDonChiTiet()
        {
            var get = _db.hoaDonsCTs.ToList();
            return get;
        }
    }
}
