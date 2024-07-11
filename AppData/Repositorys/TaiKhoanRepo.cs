using AppData.IRepository;
using AppData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Repositorys
{
    public class TaiKhoanRepo : ITaiKhoanRepo
    {
        private AppDbContext _db;
        public TaiKhoanRepo(AppDbContext db)
        {
            _db = db;
        }
        public async Task<TaiKhoan> CreateUser(TaiKhoan taiKhoan)
        {
            TaiKhoan tk = new TaiKhoan()
            {
                Username = taiKhoan.Username,
                Password = taiKhoan.Password,
                SoDienThoai = taiKhoan.SoDienThoai,
                DiaChi = taiKhoan.DiaChi,
                Email = taiKhoan.Email,
            };
            var gh = new GioHang()
            {
                Username = tk.Username,
            };
            _db.taiKhoans.Add(taiKhoan);
            _db.gioHang.Add(gh);
            await _db.SaveChangesAsync();
            return tk;
        }

        public async Task<TaiKhoan> DeleteUser(string username)
        {
            var item = await _db.taiKhoans.FirstOrDefaultAsync(x => x.Username == username);
            _db.taiKhoans.Remove(item);
            await _db.SaveChangesAsync();
            return item;
        }

        public async Task<List<TaiKhoan>> GetAllUser()
        {
            var data = await _db.taiKhoans.ToListAsync();
            return data;
        }

        public async Task<TaiKhoan> GetById(string username)
        {
            var get = await _db.taiKhoans.FindAsync(username);
            return get;
        }

        public async Task<TaiKhoan> UpdateUser(string username, TaiKhoan taiKhoan)
        {
            try
            {
                var item = await _db.taiKhoans.FirstOrDefaultAsync(p => p.Username == username);
                item.Username = taiKhoan.Username;
                item.Password = taiKhoan.Password;
                item.SoDienThoai = taiKhoan.SoDienThoai;
                item.DiaChi = taiKhoan.DiaChi;
                item.Email = taiKhoan.Email;
                _db.taiKhoans.Update(item);
                await _db.SaveChangesAsync();
                return item;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UserExists(string username)
        {
            return await _db.taiKhoans.AnyAsync(p=> p.Username == username);
        }
    }
}
