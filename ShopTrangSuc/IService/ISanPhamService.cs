using AppData.Request;

namespace ShopTrangSuc.IService
{
    public interface ISanPhamService
    {
        List<SanPhamRequest> GetAll();
        SanPhamRequest GetById(Guid id);
        bool CreateSanPham(SanPhamRequest spr);
        bool UpdateSanPham(Guid id, SanPhamRequest spr);
        bool DeleteSanPham(Guid id);
    }
}
