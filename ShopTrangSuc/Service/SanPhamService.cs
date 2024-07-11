using AppData.Request;
using ShopTrangSuc.IService;
using Newtonsoft.Json;

namespace ShopTrangSuc.Service
{
    public class SanPhamService : ISanPhamService
    {
        HttpClient _httpClient;
        public SanPhamService()
        {
            _httpClient = new HttpClient();
        }
        public bool CreateSanPham(SanPhamRequest spr)
        {
            string requestURL = "https://localhost:7079/api/SanPham/create_sp";
            var respones = _httpClient.PostAsJsonAsync(requestURL, spr).Result;
            if (respones.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public bool DeleteSanPham(Guid id)
        {
            string requestURL = "https://localhost:7079/api/SanPham/delete_sp?id={id}";
            var respones = _httpClient.DeleteAsync(requestURL).Result;
            if(respones.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public List<SanPhamRequest> GetAll()
        {
            string requestURL = "https://localhost:7079/api/SanPham/get_sp";
            var respones = _httpClient.GetStringAsync(requestURL).Result;
            var data = JsonConvert.DeserializeObject<List<SanPhamRequest>>(respones);
            return data;
        }

        public SanPhamRequest GetById(Guid id)
        {
            string requestURL = "https://localhost:7079/api/SanPham/get_by_id_sp?id={id}";
            var respones = _httpClient.GetStringAsync(requestURL).Result;
            var data = JsonConvert.DeserializeObject<SanPhamRequest>(respones);
            return data;
        }

        public bool UpdateSanPham(Guid id, SanPhamRequest spr)
        {
            string requestURL = "https://localhost:7079/api/SanPham/update_sp?id={id}";
            var respones = _httpClient.PutAsJsonAsync(requestURL, spr).Result;
            if(respones.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
