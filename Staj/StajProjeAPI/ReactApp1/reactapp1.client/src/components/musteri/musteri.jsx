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
    { ID: 1, Name: "John Doe" },
    { ID: 2, Name: "Jane Smith" },
    { ID: 3, Name: "Michael Brown" },
    { ID: 4, Name: "Emily Davis" },
    { ID: 5, Name: "Daniel Wilson" },
    { ID: 6, Name: "Sophia Taylor" },
    { ID: 7, Name: "James Anderson" },
    { ID: 8, Name: "Olivia Martinez" },
    { ID: 9, Name: "William Thompson" },
    { ID: 10, Name: "Ava Johnson" }
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
                    pageable={true}
                    sortable={true}
                    filterable={true}
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
                    <Column field="ID" title="ID" filterable={false} width="70px" />
                    <Column field="Name" title="Müşteri Adı" />
                    {/* Silme sütununu kaldırdık */}
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