using Microsoft.AspNetCore.Mvc;
using ReactApp1.Server.Models;
using ReactApp1.Server.Services;

namespace ReactApp1.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class UrunController : Controller
    {
        // Servis Bağımlılığı
        private readonly UrunServis _urunServis;

        // Yapıcı Metod
        public UrunController(UrunServis urunServis)
        {
            // Bağımlılık Enjeksiyonu
            _urunServis = urunServis;
        }

        // Ürün Oluşturma Metodu
        [HttpPost]
        public IActionResult Create([FromBody] Urun urun)
        {
            // Ürünü veritabanına ekle
            _urunServis.Create(urun);

            // Başarılı yanıt döndür
            return Ok(new { Message = "Ürün başarıyla veritabanına eklendi!" });
        }

    }
}
