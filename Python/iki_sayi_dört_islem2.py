# Öğrenci sayısını al
ogrenci_sayisi = int(input("Kaç öğrenci var? "))

ogrenciler = []

# Öğrenci bilgilerini topla
for i in range(ogrenci_sayisi):
    print(f"\n{i + 1}. Öğrencinin bilgilerini girin:")
    ad = input("Ad: ")
    soyad = input("Soyad: ")
    vize = float(input("Vize Notu (%40): "))
    final = float(input("Final Notu (%60): "))
    
    # Ağırlıklı ortalama hesapla
    ortalama = (vize * 0.4) + (final * 0.6)
    
    # Öğrenci bilgilerini kaydet
    ogrenciler.append({
        "ad": ad,
        "soyad": soyad,
        "ortalama": ortalama
    })

# Geçen ve kalan öğrencileri ayır
gecenler = []
kalanlar = []

for ogrenci in ogrenciler:
    if ogrenci["ortalama"] >= 50:
        gecenler.append(ogrenci)
    else:
        kalanlar.append(ogrenci)

# Sonuçları yazdır
print("\nGeçen Öğrenciler:")
for ogrenci in gecenler:
    print(f"{ogrenci['ad']} {ogrenci['soyad']} - Ortalama: {ogrenci['ortalama']:.2f}")

print("\nKalan Öğrenciler:")
for ogrenci in kalanlar:
    print(f"{ogrenci['ad']} {ogrenci['soyad']} - Ortalama: {ogrenci['ortalama']:.2f}")
