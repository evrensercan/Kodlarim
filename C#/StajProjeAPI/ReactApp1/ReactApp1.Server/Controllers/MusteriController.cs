using Microsoft.AspNetCore.Mvc;
using ReactApp1.Server.Models;
using ReactApp1.Server.Services;

namespace ReactApp1.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MusteriController : Controller
    {
        // Servis nesnesini tutan değişken
        private readonly MusteriServis _musteriServis;

        // Constructor: Servis sınıfını Dependency Injection ile alma
        public MusteriController(MusteriServis musteriServis)
        {
            // Servis bağımlılığını atama
            _musteriServis = musteriServis;
        }

        //************************************************************
        // 1) CREATE - Müşteri Ekleme
        //************************************************************

        [HttpPost]
        public IActionResult Create([FromBody] Musteri musteri)
        {
            // Servis katmanına müşteri bilgilerini gönderme
            _musteriServis.Create(musteri);

            // Başarılı işlem sonucu döndürme
            return Ok(new { Message = "Müşteri başarıyla veritabanına eklendi!" });
        }

        //************************************************************
        // 2) READ - Müşteri Listeleme
        //************************************************************

        [HttpGet]
        public IActionResult Get()
        {
            // Servis katmanından tüm müşterileri alma
            var musteriListesi = _musteriServis.GetMusteriler();

            return Ok(musteriListesi);
        }

        //************************************************************
        // 3) UPDATE - Müşteri Güncelleme
        //************************************************************

        [HttpPut]
        public IActionResult Update([FromBody] Musteri musteri)
        {
            // Servis katmanına güncellenecek müşteri bilgilerini gönderme
            _musteriServis.Update(musteri);

            // Başarılı işlem sonucu döndürme
            return Ok(new { Message = "Müşteri başarıyla güncellendi!" });
        }

        //************************************************************
        // 4) DELETE - Müşteri Silme
        //************************************************************

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Servis katmanına silinecek müşteri ID'sini gönderme
            _musteriServis.Delete(id);

            // Başarılı işlem sonucu döndürme
            return Ok(new { Message = "Müşteri başarıyla silindi!" });
        }
    }
}
