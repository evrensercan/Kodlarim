import React, { useState, useEffect } from 'react';
import { Grid, GridColumn, GridToolbar } from '@progress/kendo-react-grid';
import { Dialog, DialogActionsBar } from '@progress/kendo-react-dialogs';
import { filterBy } from '@progress/kendo-data-query';
import '@progress/kendo-theme-default/dist/all.css';

// --- Varsayılan Boş Sipariş Şablonu ---
const varsayilanYeniSiparis = {
    siparisNo: `SIP-${Math.floor(Math.random() * 10000)}`,
    musteriId: 0,
    urunId: 0,
    adet: 1,
    toplamTutar: 0,
    durum: "Bekliyor",
    tarih: new Date().toISOString().split('T')[0]
};

export default function Siparisler() {
    // --- State (Hafıza) ---
    const [siparisListesi, setSiparisListesi] = useState([]);
    const [musteriListesi, setMusteriListesi] = useState([]);
    const [urunListesi, setUrunListesi] = useState([]);

    const [yeniSiparis, setYeniSiparis] = useState(varsayilanYeniSiparis);
    const [pencereAcik, setPencereAcik] = useState(false);
    const [filter, setFilter] = useState(null);

    // --- API'den Verileri Çekme ---
    const listeleriGetir = async () => {
        try {
            const [siparisData, musteriData, urunData] = await Promise.all([
                // DİKKAT: Sipariş için /api/Siparis, diğerleri için normal yol
                fetch("https://localhost:7137/api/Siparis").then(res => res.json()),
                fetch("https://localhost:7137/Musteri").then(res => res.json()),
                fetch("https://localhost:7137/Urun").then(res => res.json())
            ]);

            setSiparisListesi(siparisData);
            setMusteriListesi(musteriData);
            setUrunListesi(urunData);
        } catch (error) {
            console.error("Veri çekme hatası:", error);
        }
    };

    useEffect(() => {
        listeleriGetir();
    }, []);

    // --- ÖZEL ÇEVİRMEN HÜCRELERİ (ID -> İsim) ---
    // --- GÜNCELLENMİŞ ÇEVİRMEN HÜCRELERİ ---
    const MusteriCell = (props) => {
        // 1. Gelen veride ID'yi bulmaya çalış (Büyük/Küçük harf fark etmeksizin)
        const veri = props.dataItem;
        const arananId = veri.musteriId || veri.MusteriId || veri.MusteriID;

        // 2. Listem boşsa (henüz yüklenmediyse) bekle
        if (!musteriListesi || musteriListesi.length === 0) return <td>Yükleniyor...</td>;

        // 3. Eşleşmeyi Bul (Hem ID hem string/number kontrolü)
        const bulunan = musteriListesi.find(m =>
            (m.musteriId == arananId) || (m.MusteriId == arananId) || (m.ID == arananId)
        );

        // 4. İsim mi AdSoyad mı? Onu da iki türlü dene.
        const isim = bulunan ? (bulunan.adSoyad || bulunan.AdSoyad) : `Bulunamadı (${arananId})`;

        return <td>{isim}</td>;
    };

    const UrunCell = (props) => {
        const veri = props.dataItem;
        const arananId = veri.urunId || veri.UrunId || veri.UrunID;

        if (!urunListesi || urunListesi.length === 0) return <td>Yükleniyor...</td>;

        const bulunan = urunListesi.find(u =>
            (u.urunId == arananId) || (u.UrunId == arananId) || (u.ID == arananId)
        );

        const urunAdi = bulunan ? (bulunan.adi || bulunan.Adi || bulunan.UrunAdi) : `Bulunamadı (${arananId})`;

        return <td>{urunAdi}</td>;
    };

    // --- İşlemler ---
    const acPencere = () => {
        setYeniSiparis({
            ...varsayilanYeniSiparis,
            siparisNo: `SIP-${Math.floor(Math.random() * 10000)}`
        });
        setPencereAcik(true);
    };

    const kapatPencere = () => setPencereAcik(false);

    const handleChange = (e) => {
        const { name, value } = e.target;
        const isNumber = name === "musteriId" || name === "urunId" || name === "adet";
        const parsedValue = isNumber ? Number(value) : value;

        let guncelKayit = { ...yeniSiparis, [name]: parsedValue };

        if (name === "urunId" || name === "adet") {
            const secilenUrun = urunListesi.find(u => u.urunId === guncelKayit.urunId);
            if (secilenUrun) {
                guncelKayit.toplamTutar = secilenUrun.fiyat * guncelKayit.adet;
            }
        }
        setYeniSiparis(guncelKayit);
    };

    const kaydetBasildi = async (e) => {
        e.preventDefault();
        const response = await fetch("https://localhost:7137/api/Siparis", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(yeniSiparis)
        });

        if (response.ok) {
            alert("Sipariş Başarıyla Eklendi! ✅");
            kapatPencere();
            listeleriGetir();
        } else {
            alert("Kaydederken hata oluştu ❌");
        }
    };

    return (
        <div>
            <h1>💰 Sipariş Yönetimi</h1>

            <Grid
                data={filterBy(siparisListesi, filter)}
                dataItemKey="siparisId"
                pageable={true}
                sortable={true}
                filterable={true}
                filter={filter}
                onFilterChange={(e) => setFilter(e.filter)}
                style={{ height: "600px" }}
            >
                <GridToolbar>
                    <button className="k-button k-button-md k-rounded-md k-button-solid k-button-solid-primary" onClick={acPencere}>
                        + Yeni Sipariş Ekle
                    </button>
                </GridToolbar>

                <GridColumn field="siparisId" title="ID" width="60px" filterable={false} />
                <GridColumn field="siparisNo" title="Sipariş No" width="120px" />

                {/* BURASI SİHİRLİ KISIM: cell={MusteriCell} diyerek çevirmeni çağırdık */}
                <GridColumn field="musteri.adSoyad" title="Müşteri" cell={MusteriCell} />
                <GridColumn field="urun.adi" title="Ürün" cell={UrunCell} />

                <GridColumn field="adet" title="Adet" width="80px" filterable={false} />
                <GridColumn field="toplamTutar" title="Tutar" width="120px" filterable={false} />
                <GridColumn field="durum" title="Durum" width="120px" />
            </Grid>

            {pencereAcik && (
                <Dialog title={"Yeni Sipariş"} onClose={kapatPencere} width={500}>
                    <form className="k-form">
                        <fieldset>
                            <div className="mb-3">
                                <label>Sipariş No:</label>
                                <input className="k-input k-rounded-md k-p-2" value={yeniSiparis.siparisNo} readOnly disabled />
                            </div>

                            <div className="mb-3">
                                <label>Müşteri Seç:</label>
                                <select name="musteriId" value={yeniSiparis.musteriId} onChange={handleChange} className="k-input k-rounded-md k-p-2">
                                    <option value="0">Seçiniz...</option>
                                    {musteriListesi.map(m => (
                                        <option key={m.musteriId} value={m.musteriId}>{m.adSoyad}</option>
                                    ))}
                                </select>
                            </div>

                            <div className="mb-3">
                                <label>Ürün Seç:</label>
                                <select name="urunId" value={yeniSiparis.urunId} onChange={handleChange} className="k-input k-rounded-md k-p-2">
                                    <option value="0">Seçiniz...</option>
                                    {urunListesi.map(u => (
                                        <option key={u.urunId} value={u.urunId}>{u.adi} - {u.fiyat} ₺</option>
                                    ))}
                                </select>
                            </div>

                            <div className="mb-3">
                                <label>Adet:</label>
                                <input type="number" name="adet" value={yeniSiparis.adet} onChange={handleChange} className="k-input k-rounded-md k-p-2" min="1" />
                            </div>

                            <div className="mb-3">
                                <label>Toplam Tutar (₺):</label>
                                <input value={yeniSiparis.toplamTutar} readOnly className="k-input k-rounded-md k-p-2" style={{ backgroundColor: "#f0f0f0" }} />
                            </div>
                        </fieldset>
                    </form>

                    <DialogActionsBar>
                        <button className="k-button" onClick={kapatPencere}>Vazgeç</button>
                        <button className="k-button k-button-solid-primary" onClick={kaydetBasildi}>Kaydet</button>
                    </DialogActionsBar>
                </Dialog>
            )}
        </div>
    );
}