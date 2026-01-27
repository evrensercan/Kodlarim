/**
 * Module: Ürün Yönetim Modülü (v1.0 - Stable)
 * Description: Ürün listesini görüntüler ve yeni kayıt ekleme arayüzünü sunar.
 */

import { Grid, GridColumn as Column, GridToolbar } from '@progress/kendo-react-grid';
import { Dialog, DialogActionsBar } from '@progress/kendo-react-dialogs';
import '@progress/kendo-theme-default/dist/all.css';
import React, { useState } from 'react';

// --- Test Verisi ---
const ornekVeri = [
    { UrunId: 1, Adi: "Bilgisayar", Kodu: "BILG001", Fiyat: "48000" },
    { UrunId: 2, Adi: "Telefon", Kodu: "TEL002", Fiyat: "25000" },
    { UrunId: 3, Adi: "Tablet", Kodu: "TAB003", Fiyat: "15000" },
    { UrunId: 4, Adi: "Klavye", Kodu: "KLAV004", Fiyat: "500" },
    { UrunId: 5, Adi: "Fare", Kodu: "FAR005", Fiyat: "200" },
    { UrunId: 6, Adi: "Monitör", Kodu: "MONI006", Fiyat: "8000" },
    { UrunId: 7, Adi: "Yazıcı", Kodu: "YAZ007", Fiyat: "1200" },
    { UrunId: 8, Adi: "Kamera", Kodu: "KAM008", Fiyat: "3500" },
    { UrunId: 9, Adi: "Hoparlör", Kodu: "HOP009", Fiyat: "800" },
    { UrunId: 10, Adi: "USB Bellek", Kodu: "USB010", Fiyat: "400" }
];

export default function Urunler() {

    // --- State Yönetimi ---
    const [eklePenceresiAcikMi, setEklePenceresiAcikMi] = useState(false);

    // --- Olay Yönetimi ---
    const ekleButonunaBasildi = () => setEklePenceresiAcikMi(true);
    const vazgecBasildi = () => setEklePenceresiAcikMi(false);

    return (
        <div>
            <h1>📦 Ürünler</h1>

            <div>
                {/* Kendo Grid: Sadece listeleme ve filtreleme yapar */}
                <Grid
                    data={ornekVeri}
                    dataItemKey="ID"
                    pageable={true} // Sayfalama
                    sortable={true} // Sıralama
                    filterable={true} // Filtreleme
                    resizable={true} // Sütun boyutlandırma
                    style={{ height: "550px" }}
                >
                    {/* Üst Toolbar: Ekle Butonu */}
                    <GridToolbar>
                        <button
                            title="Yeni Müşteri Kaydı Oluştur"
                            className="k-button k-button-md k-rounded-md k-button-solid k-button-solid-primary"
                            onClick={ekleButonunaBasildi}
                        >
                            + Yeni Ürün Ekle
                        </button>
                    </GridToolbar>

                    {/* Sütunlar */}
                    <Column field="UrunId" title="ID" filterable={false} width="70px" />
                    <Column field="Adi" title="Ürün Adı" width="200px" />
                    <Column field="Kodu" title="Kodu" filterable={false} />
                    <Column field="Fiyat" title="Fiyatı (₺)" filterable={false} />

                </Grid>

                {/* --- Yeni Müşteri Ekleme Penceresi --- */}
                {eklePenceresiAcikMi && (
                    <Dialog title={"Yeni Müşteri Ekle"} onClose={vazgecBasildi} width={450}>

                        <form className="k-form">
                            <fieldset>
                                {/* Form Alanları */}
                                <div className="mb-3">
                                    <label>Adı Soyadı:</label>
                                    <input className="k-input k-rounded-md k-p-2" type="text" placeholder="Ad Soyad..." />
                                </div>

                                <div className="mb-3">
                                    <label>Adres:</label>
                                    <input className="k-input k-rounded-md k-p-2" type="text" placeholder="Adres..." />
                                </div>

                                <div className="mb-3">
                                    <label>Telefon No:</label>
                                    <input className="k-input k-rounded-md k-p-2" type="text" placeholder="555-xxx-xx-xx" />
                                </div>

                                <div className="mb-3">
                                    <label>E-Mail:</label>
                                    <input className="k-input k-rounded-md k-p-2" type="email" placeholder="mail@ornek.com" />
                                </div>
                            </fieldset>
                        </form>

                        <DialogActionsBar>
                            <button className="k-button k-button-md k-rounded-md k-button-solid k-button-solid-base" onClick={vazgecBasildi}>
                                Vazgeç
                            </button>
                            <button className="k-button k-button-md k-rounded-md k-button-solid k-button-solid-primary">
                                Kaydet
                            </button>
                        </DialogActionsBar>
                    </Dialog>
                )}
            </div>
        </div>
    );
}