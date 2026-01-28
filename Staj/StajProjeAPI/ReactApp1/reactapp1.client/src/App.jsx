import { useState } from 'react' //A-) Hafıza yönetimi için useState özelliği içe aktarılıyor
import './App.css' // Stil dosyası içe aktarılıyor

import AnaSayfa from './components/anasayfa/anasayfa.jsx'
import Urunler from './components/urun/urun.jsx'
import Müsteriler from './components/musteri/musteri.jsx'
import Siparisler from './components/siparis/siparis.jsx'
import Raporlar from './components/rapor/rapor.jsx'


export default function App() { // B-) App bileşeni tanımlanıyor ve dışa aktarılıyor
  const [aktifSayfa, setAktifSayfa] = useState("AnaSayfa")

  const butonStili = (sayfa) => aktifSayfa === sayfa ? { backgroundColor: "lightblue" } : {};

  return (
    <div className='ana-sayfa'>

      {/* Yan Menü */}
      <div className='yan-menu'>
        <h3>Menü</h3>
        <button style={butonStili("AnaSayfa")} onClick={() => setAktifSayfa("AnaSayfa")}>AnaSayfa</button>
        <button style={butonStili("Urunler")} onClick={() => setAktifSayfa("Urunler")}>Ürünler</button>
        <button style={butonStili("Müsteriler")} onClick={() => setAktifSayfa("Müsteriler")}>Müsteriler</button>
        <button style={butonStili("Siparisler")} onClick={() => setAktifSayfa("Siparisler")}>Siparişler</button>
        <button style={butonStili("Raporlar")} onClick={() => setAktifSayfa("Raporlar")}>Raporlar</button>
      </div>

      {/* İçerik Alanı */}
      <div className='panel' >
        {aktifSayfa === "AnaSayfa" && <AnaSayfa />}
        {aktifSayfa === "Urunler" && <Urunler />}
        {aktifSayfa === "Müsteriler" && <Müsteriler />}
        {aktifSayfa === "Siparisler" && <Siparisler />}
        {aktifSayfa === "Raporlar" && <Raporlar />}
      </div>

    </div>
  )
}