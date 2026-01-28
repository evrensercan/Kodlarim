/**
 * Module: Müşteri Yönetim Modülü (v1.0 - Stable)
 * Description: Müşteri listesini görüntüler ve yeni kayıt ekleme arayüzünü sunar.
 */

import { Grid, GridColumn as Column, GridToolbar } from '@progress/kendo-react-grid';
import { Dialog, DialogActionsBar } from '@progress/kendo-react-dialogs';
import '@progress/kendo-theme-default/dist/all.css';
import React, { useEffect, useState } from 'react';
import { filterBy } from '@progress/kendo-data-query';

export default function Müsteriler() {

    // --- State Yönetimi ---
    const [eklePenceresiAcikMi, setEklePenceresiAcikMi] = useState(false);

    const [musteriListesi, setMusteriListesi] = useState([]);


    // --- API BAĞLANTISI ---
    useEffect(() => {
        fetch("https://localhost:7137/Musteri")
            .then(response => response.json())
            .then(data => {
                // API'den gelen veriyi buraya yüklüyoruz
                setMusteriListesi(data);
            })
            .catch(error => console.error("Veri çekilirken hata:", error));
    }, []);

    // --- Olay Yönetimi ---
    const ekleButonunaBasildi = () => setEklePenceresiAcikMi(true);
    const vazgecBasildi = () => setEklePenceresiAcikMi(false);


    return (
        <div>
            <h1>👥 Müşteriler</h1>

            <div>
                {/* Kendo Grid: Sadece listeleme ve filtreleme yapar */}
                <Grid
                    data={filterBy(musteriListesi, filter)}
                    dataItemKey="ID"
                    pageable={true} // Sayfalama
                    sortable={true} // Sıralama
                    filterable={true} // Filtreleme
                    filter={filter}
                    onFilterChange={(e) => setFilter(e.filter)}
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
                    <Column field="musteriId" title="ID" filterable={false} width="70px" />

                    <Column field="adSoyad" title="Müşteri Adı" width="200px" />

                    <Column field="adres" title="Adres" filterable={false} />

                    <Column field="telNo" title="Telefon No" filterable={false} />

                    <Column field="mail" title="E-Mail" filterable={false} />
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