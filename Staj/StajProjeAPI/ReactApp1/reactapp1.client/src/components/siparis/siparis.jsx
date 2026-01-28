/**
 * Module: Sipariş Yönetim Modülü (v1.0 - Stable)
 * Description: Sipariş listesini görüntüler ve yeni kayıt ekleme arayüzünü sunar.
 */

import { Grid, GridColumn as Column, GridToolbar } from '@progress/kendo-react-grid';
import { Dialog, DialogActionsBar } from '@progress/kendo-react-dialogs';
import '@progress/kendo-theme-default/dist/all.css';
import React, { useState, useEffect } from 'react';



export default function Siparisler() {

    // --- State Yönetimi ---
    const [eklePenceresiAcikMi, setEklePenceresiAcikMi] = useState(false);

    const [siparisListesi, setSiparisListesi] = useState([]);

    // --- API BAĞLANTISI ---
    useEffect(() => {
        fetch("https://localhost:7137/api/Siparis")
            .then(response => response.json())
            .then(data => {
                // API'den gelen veriyi buraya yüklüyoruz
                console.log("GELEN SİPARİŞ VERİSİ:", data);
                setSiparisListesi(data);
            })
            .catch(error => console.error("Veri çekilirken hata:", error));
    }, []);

    // --- Olay Yönetimi ---
    const ekleButonunaBasildi = () => setEklePenceresiAcikMi(true);
    const vazgecBasildi = () => setEklePenceresiAcikMi(false);

    return (
        <div>
            <h1>💰 Siparişler</h1>

            <div>
                {/* Kendo Grid: Sadece listeleme ve filtreleme yapar */}
                <Grid
                    data={siparisListesi}
                    dataItemKey="siparisId"
                    pageable={true} // Sayfalama
                    sortable={true} // Sıralama
                    filterable={true} // Filtreleme
                    resizable={true} // Sütun boyutlandırma
                    style={{ height: "550px" }}
                >
                    {/* Üst Toolbar: Ekle Butonu */}
                    <GridToolbar>
                        <button
                            title="Yeni Sipariş Kaydı Oluştur"
                            className="k-button k-button-md k-rounded-md k-button-solid k-button-solid-primary"
                            onClick={ekleButonunaBasildi}
                        >
                            + Yeni Sipariş Ekle
                        </button>
                    </GridToolbar>

                    {/* Sütunlar */}
                    <Column field="siparisId" title="ID" filterable={false} width="70px" />
                    <Column field="musteri.adSoyad" title="Müşteri Adı" />
                    <Column field="urun.adi" title="Ürün" />
                    <Column field="toplamTutar" title="Tutar (₺)" filterable={false} width="120px" />
                    <Column field="durum" title="Durum" width="130px" />
                </Grid>

                {/* --- Yeni Sipariş Ekleme Penceresi --- */}
                {eklePenceresiAcikMi && (
                    <Dialog title={"Yeni Sipariş Ekle"} onClose={vazgecBasildi} width={450}>

                        <form className="k-form">
                            <fieldset>
                                {/* Form Alanları */}
                                <div className="mb-3">
                                    <label>Sipariş No:</label>
                                    <input className="k-input k-rounded-md k-p-2" type="text" placeholder="SIP###" />
                                </div>

                                <div className="mb-3">
                                    <label>Müşteri Adı:</label>
                                    <input className="k-input k-rounded-md k-p-2" type="text" placeholder="Müşteri adı..." />
                                </div>

                                <div className="mb-3">
                                    <label>Ürün:</label>
                                    <input className="k-input k-rounded-md k-p-2" type="text" placeholder="Ürün adı..." />
                                </div>

                                <div className="mb-3">
                                    <label>Tarih:</label>
                                    <input className="k-input k-rounded-md k-p-2" type="date" />
                                </div>

                                <div className="mb-3">
                                    <label>Tutar:</label>
                                    <input className="k-input k-rounded-md k-p-2" type="number" placeholder="0" />
                                </div>

                                <div className="mb-3">
                                    <label>Durum:</label>
                                    <select className="k-input k-rounded-md k-p-2">
                                        <option>Bekleme</option>
                                        <option>Hazırlanıyor</option>
                                        <option>Kargo</option>
                                        <option>Tamamlandı</option>
                                    </select>
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