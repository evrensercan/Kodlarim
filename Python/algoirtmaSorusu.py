def hesapla(sayi):
    sonuc = 0  # Başlangıçta sonuç 0
    while sayi <= 0:
        sayi = sayi**3 + sayi  # Sayının küpünü al ve kendisiyle topla
        sonuc += 1  # Sonucu 1 artır
    return sonuc

# Başlangıç değeri -1/2
sayi = -1/2
print(hesapla(sayi))
