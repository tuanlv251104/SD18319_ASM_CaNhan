using AppData.Models;
using AppData.Request;
using Newtonsoft.Json;
using ShopTrangSuc.IService;

namespace ShopTrangSuc.Service
{
    public class TaiKhoanService : ITaiKhoanService
    {
        HttpClient _httpClient;
        public TaiKhoanService()
        {
            _httpClient = new HttpClient();
        }


        public bool CreateTaiKhoan(TaiKhoanRequest request)
        {
            throw new NotImplementedException();
        }

       

        public bool DeleteTaiKhoan(string username)
        {
            throw new NotImplementedException();
        }

        

        public List<TaiKhoanRequest> GetAlltk()
        {
            string requestURL = "https://localhost:7079/api/TaiKhoan/get-tk";
            var response = _httpClient.GetStringAsync(requestURL).Result;
            var data = JsonConvert.DeserializeObject<List<TaiKhoanRequest>>(response);
            return data;
        }

       

        public TaiKhoanRequest GetById(string username)
        {
            throw new NotImplementedException();
        }

        public bool Login(TaiKhoanRequest request)
        {
            throw new NotImplementedException();
        }

        public bool UpdateSanPham(Guid id, SanPhamRequest spr)
        {
            throw new NotImplementedException();
        }

        public bool UpdateTaiKhoan(string username, TaiKhoanRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
