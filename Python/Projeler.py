
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



"""#py otlmya gören geçtin/kaldın
vize = int(input("Vize notun :"))
Final = int(input("Final notun :"))

ort = (vize*0.40)+(Final*0.60)

print("Ortalaman: ",ort)
if ort>50:
    print("Geçtin")
if ort<50:
    print("Kaldın")
"""

"""MuratAmcamınverdiğiProje
# Öğrencilerin bilgilerini saklamak için boş listeler
ogrenciler = []
notlar = []

# 20 öğrencinin adını ve notunu al
for i in range(1, 21):
    print(f"{i}. öğrenci:")
    ad = input("Adı: ")
    notu = float(input("Aldığı Not: "))  # Notu ondalık da olabilir
    ogrenciler.append(ad)
    notlar.append(notu)

# Ortalama hesaplama
ortalama = sum(notlar) / len(notlar)
print(f"\nSınıfın not ortalaması: {ortalama:.2f}")

# Ortalamanın üstündekiler ve altındakiler
ust_ortalama = []
alt_ortalama = []

for i in range(len(notlar)):
    if notlar[i] >= ortalama:
        ust_ortalama.append((ogrenciler[i], notlar[i]))
    else:
        alt_ortalama.append((ogrenciler[i], notlar[i]))

# Çıktı verme
print("\nOrtalamadan yüksek not alan öğrenciler:")
for ad, notu in ust_ortalama:
    print(f"{ad}: {notu:.2f}")

print("\nOrtalamadan düşük not alan öğrenciler:")
for ad, notu in alt_ortalama:
    print(f"{ad}: {notu:.2f}")


"""


"""#py 



"""


