/**
 * Module: Sipariş Yönetim Modülü (v1.0 - Stable)
 * Description: Sipariş listesini görüntüler ve yeni kayıt ekleme arayüzünü sunar.
 */

import { Grid, GridColumn as Column, GridToolbar } from '@progress/kendo-react-grid';
import { Dialog, DialogActionsBar } from '@progress/kendo-react-dialogs';
import '@progress/kendo-theme-default/dist/all.css';
import React, { useState } from 'react';

// --- Test Verisi (10 Siparişlik Liste) ---
const ornekVeri = [
    { SiparisId: 1, SiparisNo: "SIP001", MusteriAdi: "Evren Sercan", Ürün: "Bilgisayar", Tarih: "2026-01-15", Tutar: "48000", Durum: "Tamamlandı" },
    { SiparisId: 2, SiparisNo: "SIP002", MusteriAdi: "Ahmet Yılmaz", Ürün: "Telefon", Tarih: "2026-01-16", Tutar: "25000", Durum: "Kargo" },
    { SiparisId: 3, SiparisNo: "SIP003", MusteriAdi: "Michael Brown", Ürün: "Tablet", Tarih: "2026-01-17", Tutar: "15000", Durum: "Hazırlanıyor" },
    { SiparisId: 4, SiparisNo: "SIP004", MusteriAdi: "Emily Davis", Ürün: "Klavye", Tarih: "2026-01-18", Tutar: "500", Durum: "Tamamlandı" },
    { SiparisId: 5, SiparisNo: "SIP005", MusteriAdi: "Daniel Wilson", Ürün: "Fare", Tarih: "2026-01-19", Tutar: "200", Durum: "Bekleme" },
    { SiparisId: 6, SiparisNo: "SIP006", MusteriAdi: "Sophia Taylor", Ürün: "Monitör", Tarih: "2026-01-20", Tutar: "8000", Durum: "Kargo" },
    { SiparisId: 7, SiparisNo: "SIP007", MusteriAdi: "James Anderson", Ürün: "Yazıcı", Tarih: "2026-01-21", Tutar: "1200", Durum: "Tamamlandı" },
    { SiparisId: 8, SiparisNo: "SIP008", MusteriAdi: "Olivia Martinez", Ürün: "Kamera", Tarih: "2026-01-22", Tutar: "3500", Durum: "Hazırlanıyor" },
    { SiparisId: 9, SiparisNo: "SIP009", MusteriAdi: "William Thompson", Ürün: "Hoparlör", Tarih: "2026-01-23", Tutar: "800", Durum: "Kargo" },
    { SiparisId: 10, SiparisNo: "SIP010", MusteriAdi: "Ava Johnson", Ürün: "USB Bellek", Tarih: "2026-01-24", Tutar: "400", Durum: "Bekleme" }
];

export default function Siparisler() {

    // --- State Yönetimi ---
    const [eklePenceresiAcikMi, setEklePenceresiAcikMi] = useState(false);

    // --- Olay Yönetimi ---
    const ekleButonunaBasildi = () => setEklePenceresiAcikMi(true);
    const vazgecBasildi = () => setEklePenceresiAcikMi(false);

    return (
        <div>
            <h1>💰 Siparişler</h1>

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
                            title="Yeni Sipariş Kaydı Oluştur"
                            className="k-button k-button-md k-rounded-md k-button-solid k-button-solid-primary"
                            onClick={ekleButonunaBasildi}
                        >
                            + Yeni Sipariş Ekle
                        </button>
                    </GridToolbar>

                    {/* Sütunlar */}
                    <Column field="SiparisId" title="ID" filterable={false} width="70px" />
                    <Column field="SiparisNo" title="Sipariş No" width="120px" />
                    <Column field="MusteriAdi" title="Müşteri Adı" width="180px" />
                    <Column field="Ürün" title="Ürün" width="150px" />
                    <Column field="Tarih" title="Tarih" filterable={false} width="120px" />
                    <Column field="Tutar" title="Tutar (₺)" filterable={false} width="120px" />
                    <Column field="Durum" title="Durum" width="130px" />
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