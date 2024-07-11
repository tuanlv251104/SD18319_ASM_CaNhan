using AppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAPI.IRepository
{
    public interface IGioHangRepo
    {
        Task<IEnumerable<GioHang>> GetGioHang();
        Task<GioHang> CreateGioHang(GioHang gioHang);
        Task<GioHang> UpdateGioHang(Guid id, GioHang gioHang);
        Task<GioHang> DeleteGioHang(Guid id);
    }
}
