using AppAPI.IRepository;
using AppData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAPI.Repositorys
{
    internal class GiaHanngRepo : IGioHangRepo
    {
        private AppDbContext _db;
        public GiaHanngRepo(AppDbContext db)
        {
            _db = db;
        }
        public Task<GioHang> CreateGioHang(GioHang gioHang)
        {
            throw new NotImplementedException();
        }

        public Task<GioHang> DeleteGioHang(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<GioHang>> GetGioHang()
        {
            var get = await _db.gioHang.ToListAsync();
            return get;
        }

        public Task<GioHang> UpdateGioHang(Guid id, GioHang gioHang)
        {
            throw new NotImplementedException();
        }
    }
}
