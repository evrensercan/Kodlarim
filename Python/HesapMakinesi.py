#Hesap Makinesi 

print("""
\n...İşlem Seçenekleri... 
      1-Toplama(+)
      2-Çıkartma(-)
      3-Çarpma(x)
      4-Bölme(÷)
      5-Üs Alma(^)
      6-Mod Alma(%)
 
""")
islem=input("Bir İşlem Seçin (1/2/3/4) :")

ilk = int(input("\nİlk sayıyı girin :"))
iki = int(input("İkinci sayıyı girin :"))


if islem=="1":
    
    sonuc = ilk + iki
    print("\nToplama İşleminin Sonucu ==> ",sonuc)

elif islem=="2":
    
    sonuc = ilk - iki
    print("\nÇıkarma İşleminin Sonucu ==> ",sonuc)

elif islem=="3":
    
    sonuc = ilk * iki
    print("\nÇarpma İşleminin Sonucu ==> ",sonuc)

elif islem=="4":
    
    sonuc = ilk / iki
    print("\nBölme İşleminin Sonucu ==> ",sonuc)

elif islem =="5":
    
    sonuc = ilk ** iki
    print("\nÜs Alma İşleminin Sonucu ==> ",sonuc)

elif islem=="6":
    
    sonuc = ilk % iki
    print("\nMod Alma İşleminin Sonucu ==> ",sonuc)

else:
    print("Geçersiz İşlem Seçimi")


















