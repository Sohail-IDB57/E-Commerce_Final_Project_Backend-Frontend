using Newtonsoft.Json;
using Solely_MAUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solely_MAUI.Services
{
    public class BrandService
    {
        private string baseUrl { get; set; }
        public BrandService()
        {
            baseUrl = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5000/api/Brand" : "http://localhost:5000/api/Brand";
        }

        public async Task<List<Brand>> GetAllBrands()
        {
            try
            {
                List<Brand> brandList = new List<Brand>();
                string url = baseUrl ;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(url);
                client.Timeout = TimeSpan.FromSeconds(30);
                HttpResponseMessage httpResponseMessage = await client.GetAsync("");
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    string contentMessage = await httpResponseMessage.Content.ReadAsStringAsync();
                    brandList = JsonConvert.DeserializeObject<List<Brand>>(contentMessage);
                }
                return await Task.FromResult(brandList.ToList());
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
