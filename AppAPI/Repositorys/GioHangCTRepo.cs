using AppAPI.IRepository;
using AppData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Repositorys
{
    internal class GioHangCTRepo : IGioHangChiTietRepo
    {
        private AppDbContext _db;
        public GioHangCTRepo(AppDbContext db)
        {
            _db = db;
        }
        public Task<GioHangCT> CreateGioHangCT(GioHangCT gioHangCT)
        {
            throw new NotImplementedException();
        }

        public Task<GioHangCT> DeleteGioHangCT(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<GioHangCT>> GetGioHangCT()
        {
            return await _db.GioHangCTs.ToListAsync();
        }

        public Task<GioHangCT> UpdateGioHangCTr(Guid id, GioHangCT gioHangCT)
        {
            throw new NotImplementedException();
        }
    }
}
