sınıftakiler = ["Evren","Enver","Ömer","Enes","Meryem","Murat","Eray"]
sınava_girenler = []
sınava_girmeyenler = []
telafi_sınavına_girenler = []
sıra_no = 0
print("\n")

for ogrenci in sınıftakiler:
    
    sıra_no = sıra_no+1
    durumu = input(f"{sıra_no}.Öğrenci {ogrenci} Sınava Girdimi? (1-evet/2-hayır/3-telafi) : ")
    
    if durumu=='1':
        sınava_girenler.append(ogrenci)
    elif durumu=='2':
        sınava_girmeyenler.append(ogrenci)
    elif durumu=='3':
        telafi_sınavına_girenler.append(ogrenci)
    else:
        print("Hatalı İşlem")


print("\nSınava Giren Öğrenci Sayısı: => ",len(sınava_girenler))
print("Sınava Girmeyen Öğrenci Sayısı: => ",len(sınava_girmeyenler))
print("Telafi Sınavına Giren Öğrenci Sayısı: => ",len(telafi_sınavına_girenler))


print("\nSınava Giren Öğrenciler:")
for ogrenci in sınava_girenler:
    print("\t-", ogrenci)
    
print("\nSınava Girmeyen Öğrenciler:")
for ogrenci in sınava_girmeyenler:
    print("\t-", ogrenci)

print("\nTelafi Sınavına Giren Öğrenciler:")
for ogrenci in telafi_sınavına_girenler:
    print("\t-", ogrenci)