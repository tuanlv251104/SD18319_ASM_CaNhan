using AppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.IRepository
{
    public interface IGioHangChiTietRepo
    {
        Task<IEnumerable<GioHangCT>> GetGioHangCT();
        Task<GioHangCT> CreateGioHangCT(GioHangCT gioHangCT);
        Task<GioHangCT> UpdateGioHangCTr(Guid id, GioHangCT gioHangCT);
        Task<GioHangCT> DeleteGioHangCT(Guid id);
    }
}
