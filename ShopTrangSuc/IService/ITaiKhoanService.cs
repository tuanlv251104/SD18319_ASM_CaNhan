using AppData.Request;

namespace ShopTrangSuc.IService
{
    public interface ITaiKhoanService
    {
        List<TaiKhoanRequest> GetAlltk();
        bool CreateTaiKhoan(TaiKhoanRequest request);
        bool UpdateTaiKhoan(string username, TaiKhoanRequest request);
        bool DeleteTaiKhoan(string username);
        bool Login(TaiKhoanRequest request);
        TaiKhoanRequest GetById(string username);
    }
}
