using Microsoft.AspNetCore.Mvc;
using ReactApp1.Server.Models;
using ReactApp1.Server.Services;

namespace ReactApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiparisController : ControllerBase
    {
        
        private readonly SiparisServis _siparisServis;

        
        public SiparisController(SiparisServis siparisServis)
        {
            _siparisServis = siparisServis;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Siparis siparis)
        {
            _siparisServis.Create(siparis);
            return Ok(new { Message = "Sipariş Başarıyla Oluşturuldu." });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _siparisServis.Delete(id);
            return Ok(new { Message = "Sipariş başarıyla silindi!" });
        }

        [HttpGet]
        public IActionResult Get()
        {
            var siparisListesi = _siparisServis.GetSiparisler();
            return Ok(siparisListesi);
        }

        [HttpPut]
        public IActionResult Update([FromBody] Siparis siparis)
        {
            _siparisServis.Update(siparis);
            return Ok(new { Message = "Sipariş başarıyla güncellendi!" });
        }
    }
}