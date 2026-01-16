using Microsoft.AspNetCore.Mvc;
using ReactApp1.Server.Models;
using ReactApp1.Server.Services;

namespace ReactApp1.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UrunController : Controller
    {
        // Servis nesnesini tutan değişken
        private readonly UrunServis _urunServis;

        // Constructor: Servis sınıfını Dependency Injection ile alma
        public UrunController(UrunServis urunServis)
        {
            // Servis bağımlılığını atama
            _urunServis = urunServis;
        }

        //************************************************************
        // 1) CREATE - Ürün Ekleme
        //************************************************************

        [HttpPost]
        public IActionResult Create([FromBody] Urun urun)
        {
            // Servis katmanına ürünü göndererek veritabanına ekleme
            _urunServis.Create(urun);

            // Başarılı işlem sonucu döndürme
            return Ok(new { Message = "Ürün başarıyla veritabanına eklendi!" });
        }

        //************************************************************
        // 2) READ - Ürün Listeleme
        //************************************************************

        [HttpGet]
        public IActionResult Get()
        {
            // Servis katmanından tüm ürünleri alma
            var urunListesi = _urunServis.List();

            return Ok(urunListesi);
        }

        //************************************************************
        // 3) UPDATE - Ürün Güncelleme
        //************************************************************

        [HttpPut]
        public IActionResult Update([FromBody] Urun urun)
        {
            // Servis katmanına güncellenecek ürünü gönderme
            _urunServis.Update(urun);

            // Başarılı işlem sonucu döndürme
            return Ok(new { Message = "Ürün başarıyla güncellendi!" });
        }

        //************************************************************
        // 4) DELETE - Ürün Silme
        //************************************************************

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Servis katmanına silinecek ürün ID'sini gönderme
            _urunServis.Delete(id);

            // Başarılı işlem sonucu döndürme
            return Ok(new { Message = "Ürün başarıyla silindi!" });
        }

        //Id - İsim Eşleştirme
        [HttpGet("{id}")]
        public IActionResult Read(int id)
        {
            var urun = _urunServis.Read(id); //servisden ıd'yi getir

            if (urun == null)
            {
                return NotFound(new { Message = "Ürün bulunamadı!" });
            }
            return Ok(urun);
        }
    }
}
