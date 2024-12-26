ogrenciler = []
notlar = []
x=0
mevcut = int(input("\nSınıf Mevcudu? : "))
for i in range(mevcut):
    x=x+1
    print("\n",x,". Öğrenci")
    ad = input("Adı: ")
    notu = int(input("Aldığı Not: "))
    ogrenciler.append(ad)
    notlar.append(notu)

not_ortalama = (sum(notlar) / len(notlar))
print("\nSınıfın Not Ortalaması : ",not_ortalama)

ortalama_ust = []
ortalama_alt = []

for i in range(len(notlar)):

    if notlar[i] > not_ortalama:
        ortalama_ust.append(ogrenciler[i])
    else:
        ortalama_alt.append(ogrenciler[i])        
        

print("\nOrtalamadan yüksek not alan öğrenciler:")
for ogr in ortalama_ust:
    print("\t-",ogr)

print("\nOrtalamadan düşük not alan öğrenciler:")
for ogr in ortalama_alt:
    print("\t-",ogr)
