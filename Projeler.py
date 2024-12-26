
"""#pt Girilen sayının işaretini yaz
Başla
sayı
Yaz("Bir Sayı Girin :")
oku sayı
Eğer sayı>0
    Yaz("Girdiğiniz Sayı Pozitif")
Eğer sayı<0
    Yaz("Girdiğiniz Sayı Negatif")
Değilse 
    Yaz("Girdiğiniz sayı 0 Yani Nötr")
Bitir

"""


"""#pt bas dan bite kadar olan sayıları toplar.
Başla
Bas,Bit,Yedek,Toplam=0,
Yaz("Kaçla Başlasın?")
Oku Bas
Yaz("Kaçla Bitsin?")
Oku Bit
Eğer (Bas>Bit)
    Yaz("Nebiçimişyapıyon")

    Yedek=Bas
    Bas=Bit
    Bit=Yedek
sayaç (x=bas'den x=bit'e 1'er)    
    toplam = toplam + x

    eğer (x==bit)
        yaz("sonuç="+toplam)

    değilse
        yaz("aratoplam="+toplam)
sayaçsonu
Bitir

"""


"""#pt Sayaç kullanım örneği

Başla
Sayaç ( x=1'den x=100'e kadar 1'er )
    Yaz ( x + "-merhaba" )
Sayaçsonu
Bitir

"""


"""#pt Ortalama hesaplayım geçtin kaldın yazma
Başla
vize,final,ortalama
yaz("Vize giriniz :")
oku vize
yaz("Final giriniz :")
oku final
ortalama = ((vize*0.4)+(final*0.6))
yaz ("sonuç:" + ortalama)
Eğer ortalama <50
    yaz("kaldınız")
Değilse 
    yaz ("geçtiniz")
Bitir

"""

#############################################################################

"""MuratAmcamınverdiğiProje
ogrenciler = []
notlar = []

# Öğrenci bilgilerini alma
for i in range(1, 7):
    print(f"\n{i}. Öğrenci")
    ad = input("Adı: ")
    notu = int(input("Aldığı Not: "))
    ogrenciler.append(ad)
    notlar.append(notu)

# Not ortalamasını hesaplama
not_ortalama = sum(notlar) / len(notlar)
print("\nSınıfın Not Ortalaması:", not_ortalama)

# Ortalamaya göre gruplama
ortalama_ust = []
ortalama_alt = []

for i in range(len(notlar)):
    if notlar[i] > not_ortalama:
        ortalama_ust.append(ogrenciler[i])
    else:
        ortalama_alt.append(ogrenciler[i])

# Sonuçları yazdırma
print("\nOrtalamadan yüksek not alan öğrenciler:")
for ogr in ortalama_ust:
    print("\t-", ogr)

print("\nOrtalamadan düşük not alan öğrenciler:")
for ogr in ortalama_alt:
    print("\t-", ogr)



"""