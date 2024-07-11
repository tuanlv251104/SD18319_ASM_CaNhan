using AppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.IRepository
{
    public interface ITaiKhoanRepo
    {
        Task<List<TaiKhoan>> GetAllUser();
        Task<TaiKhoan> GetById(string username);
        Task<TaiKhoan> CreateUser(TaiKhoan taiKhoan);
        Task<TaiKhoan> UpdateUser(string username, TaiKhoan taiKhoan);
        Task<TaiKhoan> DeleteUser(string username);
        Task<bool> UserExists(string username);
    }
}
