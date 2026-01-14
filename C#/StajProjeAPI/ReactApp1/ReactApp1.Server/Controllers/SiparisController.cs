using Microsoft.AspNetCore.Mvc;
using ReactApp1.Server.Models;
using ReactApp1.Server.Services; // Servisi tanıması için gerekli

namespace ReactApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiparisController : ControllerBase
    {
        private readonly SiparisServis _siparisServis;

        public SiparisController(IConfiguration config)
        {
            _siparisServis = new SiparisServis(config);
        }

        //Create
        [HttpPost]
        public IActionResult Create([FromBody] Siparis siparis)
        {
            _siparisServis.Create(siparis);
            return Ok("Sipariş Başarıyla Oluşturuldu.");
        }


        //Delete
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {            
            _siparisServis.Delete(id);            
            return Ok(new { Message = "Siparis başarıyla silindi!" });
        }


        //Read
        [HttpGet]
        public IActionResult Get()
        {
            // Servis katmanından tüm müşterileri alma
            var siparisListesi = _siparisServis.GetSiparisler();

            return Ok(siparisListesi);

        }


        //Update
        [HttpPut]
        public IActionResult Update([FromBody] Siparis siparis)
        {
            // Servis katmanına güncellenecek müşteri bilgilerini gönderme
            _siparisServis.Update(siparis);

            // Başarılı işlem sonucu döndürme
            return Ok(new { Message = "Siparis başarıyla güncellendi!" });
        }
    }
}