using AppData.IRepository;
using AppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Repositorys
{
    internal class SanPhamRepo : ISanPhamRepo
    {
        private readonly AppDbContext _db;
        public SanPhamRepo(AppDbContext db)
        {
            _db = db;
        }
        public SanPham CreateSP(SanPham sp)
        {
            SanPham sanPham = new SanPham()
            {
                Id = Guid.NewGuid(),
                AnhSP = sp.AnhSP,
                TenSP = sp.TenSP,
                MoTa = sp.MoTa,
                GiaSP = sp.GiaSP,
                ChatLieu = sp.ChatLieu,
                HangCungCap = sp.HangCungCap,
                LoaiSP = sp.LoaiSP,
                SoLuong = sp.SoLuong,
            };
            _db.sanPhams.Add(sanPham);
            _db.SaveChanges();
            return sanPham;

        }

        public SanPham DeleteSP(Guid id)
        {
            var deleteItem = _db.sanPhams.Find(id);
            _db.sanPhams.Remove(deleteItem);
            _db.SaveChanges();
            return deleteItem;
        }

        public SanPham GetById(Guid id)
        {
            var getId = _db.sanPhams.Find(id);
            return getId;
        }

        public IEnumerable<SanPham> GetSanPhams()
        {
            var getsp = _db.sanPhams.ToList();
            return getsp;
        }

        public SanPham UpdateSP(Guid id, SanPham sp)
        {
            var updateSP = _db.sanPhams.FirstOrDefault(p=> p.Id == id);
            if(updateSP == null)
            {
                return null;
            }
            updateSP.TenSP = sp.TenSP;
            updateSP.AnhSP = sp.AnhSP;
            updateSP.MoTa = sp.MoTa;
            updateSP.GiaSP = sp.GiaSP;
            updateSP.ChatLieu = sp.ChatLieu;
            updateSP.HangCungCap = sp.HangCungCap;
            updateSP.LoaiSP = sp.LoaiSP;
            updateSP.SoLuong = sp.SoLuong;
            _db.sanPhams.Update(sp);
            _db.SaveChanges();
            return updateSP;
        }
    }
}
