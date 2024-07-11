using AppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAPI.IRepository
{
    public interface ISanPhamRepo
    {
        IEnumerable<SanPham> GetSanPhams();
        SanPham GetById(Guid id);
        SanPham CreateSP(SanPham sp);
        SanPham UpdateSP(Guid id, SanPham sp);
        SanPham DeleteSP(Guid id);
    }
}
