import { Grid, GridColumn as Column, GridToolbar } from '@progress/kendo-react-grid';
import { Dialog, DialogActionsBar } from '@progress/kendo-react-dialogs';
import '@progress/kendo-theme-default/dist/all.css';
import React, { useState, useEffect } from 'react'; // useEffect'i eklemeyi unutma!

export default function Urunler() {

    // --- State Yönetimi ---
    const [eklePenceresiAcikMi, setEklePenceresiAcikMi] = useState(false);

    const [urunListesi, setUrunListesi] = useState([]);

    // --- API BAĞLANTISI ---
    useEffect(() => {
        fetch("https://localhost:7137/Urun")
            .then(response => response.json())
            .then(data => {
                // API'den gelen veriyi buraya yüklüyoruz
                setUrunListesi(data);
            })
            .catch(error => console.error("Veri çekilirken hata:", error));
    }, []);

    // --- Olay Yönetimi ---
    const ekleButonunaBasildi = () => setEklePenceresiAcikMi(true);
    const vazgecBasildi = () => setEklePenceresiAcikMi(false);

    return (
        <div>
            <h1>📦 Ürünler (Canlı Veri)</h1>

            <div>
                <Grid
                    data={urunListesi} // Artık canlı listeyi kullanıyor
                    dataItemKey="UrunId"
                    pageable={true}
                    sortable={true}
                    filterable={true}
                    resizable={true}
                    style={{ height: "550px" }}
                >
                    <GridToolbar>
                        <button
                            title="Yeni Ürün Ekle"
                            className="k-button k-button-md k-rounded-md k-button-solid k-button-solid-primary"
                            onClick={ekleButonunaBasildi}
                        >
                            + Yeni Ürün Ekle
                        </button>
                    </GridToolbar>

                    {/* Sütun İsimlerinin API ile BİREBİR aynı olduğundan emin ol */}
                    <Column field="urunId" title="ID" filterable={false} width="70px" />
                    <Column field="adi" title="Ürün Adı" width="200px" />
                    <Column field="kodu" title="Kodu" filterable={false} />
                    <Column field="fiyat" title="Fiyatı (₺)" filterable={false} />

                </Grid>

                {/* --- Yeni Ekleme Penceresi (Şimdilik Görsel) --- */}
                {eklePenceresiAcikMi && (
                    <Dialog title={"Yeni Ürün Ekle"} onClose={vazgecBasildi} width={450}>
                        <form className="k-form">
                            <p>Burası şimdilik süs, sonra bağlayacağız.</p>
                        </form>
                        <DialogActionsBar>
                            <button className="k-button" onClick={vazgecBasildi}>Vazgeç</button>
                        </DialogActionsBar>
                    </Dialog>
                )}
            </div>
        </div>
    );
}