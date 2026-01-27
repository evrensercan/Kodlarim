/**
 * Module: Müşteri Yönetim Modülü (v1.0 - Stable)
 * Description: Müşteri listesini görüntüler ve yeni kayıt ekleme arayüzünü sunar.
 */

import { Grid, GridColumn as Column, GridToolbar } from '@progress/kendo-react-grid';
import { Dialog, DialogActionsBar } from '@progress/kendo-react-dialogs';
import '@progress/kendo-theme-default/dist/all.css';
import React, { useState } from 'react';

// --- Test Verisi (10 Kişilik Liste) ---
const ornekVeri = [
    { MusteriId: 1, AdSoyad: "Evren Sercan", Adres: "İstanbul, Kadıköy", TelNo: "555-123-4567", Mail: "john@test.com" },
    { MusteriId: 2, AdSoyad: "Ahmet Yılmaz", Adres: "Ankara, Çankaya", TelNo: "555-987-6543", Mail: "jane@test.com" },
    { MusteriId: 3, AdSoyad: "Michael Brown", Adres: "İzmir, Bornova", TelNo: "555-456-7890", Mail: "michael@test.com" },
    { MusteriId: 4, AdSoyad: "Emily Davis", Adres: "Bursa, Nilüfer", TelNo: "555-234-5678", Mail: "emily@test.com" },
    { MusteriId: 5, AdSoyad: "Daniel Wilson", Adres: "Antalya, Konyaaltı", TelNo: "555-876-5432", Mail: "daniel@test.com" },
    { MusteriId: 6, AdSoyad: "Sophia Taylor", Adres: "Trabzon, Orta Mahalle", TelNo: "555-345-6789", Mail: "sophia@test.com" },
    { MusteriId: 7, AdSoyad: "James Anderson", Adres: "Kayseri, Erciyes Mahallesi", TelNo: "555-678-9012", Mail: "james@test.com" },
    { MusteriId: 8, AdSoyad: "Olivia Martinez", Adres: "İzmir, Konak", TelNo: "555-111-2222", Mail: "olivia@test.com" },
    { MusteriId: 9, AdSoyad: "William Thompson", Adres: "Samsun, Bafra", TelNo: "555-333-4444", Mail: "william@test.com" },
    { MusteriId: 10, AdSoyad: "Ava Johnson", Adres: "Gaziantep, Şahinbey", TelNo: "555-555-6666", Mail: "ava@test.com" }
];

export default function Müsteriler() {

    // --- State Yönetimi ---
    const [eklePenceresiAcikMi, setEklePenceresiAcikMi] = useState(false);

    // --- Olay Yönetimi ---
    const ekleButonunaBasildi = () => setEklePenceresiAcikMi(true);
    const vazgecBasildi = () => setEklePenceresiAcikMi(false);

    return (
        <div>
            <h1>👥 Müşteriler</h1>

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
                            + Yeni Müşteri Ekle
                        </button>
                    </GridToolbar>

                    {/* Sütunlar */}
                    <Column field="MusteriId" title="ID" filterable={false} width="70px" />
                    <Column field="AdSoyad" title="Müşteri Adı" width="200px" />
                    <Column field="Adres" title="Adres" filterable={false} />
                    <Column field="TelNo" title="Telefon No" filterable={false} />
                    <Column field="Mail" title="E-Mail" filterable={false} />
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