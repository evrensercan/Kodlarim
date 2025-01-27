import random
print("\n\nSayı_Tahmin.3 Oyununa Hoşgeldiniz")
oyuncu_sayisi=int(input("\n\tOyuncu Sayısı : "))
oyuncular=[]
print("\n")
for x in range(oyuncu_sayisi):
    isim=input(f"{x+1} Oyuncunun Adı : ")
    oyuncular.append(isim)
rastgele_sayi = random.randint(1,100)
liste=[]
kucuk_deger=float('inf')
print("\n")
for x in oyuncular:
    tahmin=int(input(f"{x} Tahmini : "))
    tahminler=abs(rastgele_sayi-tahmin)
    liste.append((x,tahminler))
    for sayı in liste:
        if sayı[1]<kucuk_deger:
            kucuk_deger=sayı[1]
            kazanan=sayı[0]

print(f"\nDoğru Cevap : {rastgele_sayi}")
print(f"{kucuk_deger} Farkla En Yakın Tahmini Yapan : {kazanan}")