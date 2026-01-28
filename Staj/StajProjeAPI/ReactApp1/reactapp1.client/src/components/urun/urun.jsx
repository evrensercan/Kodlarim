import { Grid, GridColumn as Column, GridToolbar } from '@progress/kendo-react-grid';
import { Dialog, DialogActionsBar } from '@progress/kendo-react-dialogs';
import '@progress/kendo-theme-default/dist/all.css';
import React, { useState, useEffect } from 'react';
import { filterBy } from '@progress/kendo-data-query';

export default function Urunler() {

    // --- State Yönetimi ---
    const [eklePenceresiAcikMi, setEklePenceresiAcikMi] = useState(false);
    const [urunListesi, setUrunListesi] = useState([]);

    // DÜZELTME: İşte unuttuğumuz parça bu! Filtreleme hafızası.
    const [filter, setFilter] = useState(null);

    // --- API BAĞLANTISI ---
    useEffect(() => {
        fetch("https://localhost:7137/Urun")
            .then(response => response.json())
            .then(data => setUrunListesi(data))
            .catch(error => console.error("Hata:", error));
    }, []);

    // --- Olay Yönetimi ---
    const ekleButonunaBasildi = () => setEklePenceresiAcikMi(true);
    const vazgecBasildi = () => setEklePenceresiAcikMi(false);

    return (
        <div>
            <h1>📦 Ürünler (Canlı Veri)</h1>

            <div>
                <Grid
                    data={filterBy(urunListesi, filter)} // Filtrelenmiş veri
                    dataItemKey="UrunId"
                    pageable={true}
                    sortable={true}
                    filterable={true}
                    filter={filter} // Hafızayı buraya bağladık
                    onFilterChange={(e) => setFilter(e.filter)} // Değişince hafızayı güncelle
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

                    <Column field="urunId" title="ID" filterable={false} width="70px" />
                    <Column field="adi" title="Ürün Adı" width="200px" />
                    <Column field="kodu" title="Kodu" filterable={false} />
                    <Column field="fiyat" title="Fiyatı (₺)" filterable={false} />

                </Grid>

                {/* --- Yeni Ekleme Penceresi --- */}
                {eklePenceresiAcikMi && (
                    <Dialog title={"Yeni Ürün Ekle"} onClose={vazgecBasildi} width={450}>
                        <form className="k-form">
                            <p>Burası şimdilik süs, birazdan canlandıracağız.</p>
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