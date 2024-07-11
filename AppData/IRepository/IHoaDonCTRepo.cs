using AppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.IRepository
{
    public interface IHoaDonCTRepo
    {
        public List<HoaDonCT> GetAllHoaDonChiTiet();
    }
}
