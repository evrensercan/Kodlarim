import random
x=0
print("\t\n Sayı Tahmin Oyununa Hoşgeldin")


pc_sayısı = random.randint(1, 100)

for x in range(5):
    print( "\n[", 5-x ,"Tahmin Hakkın Kaldı.]")
    tahmin = int(input("\tTahminin : "))
    if tahmin == pc_sayısı:
        print("\t!!!Doğru Tahmin Tebrikler!!!")
    elif tahmin > pc_sayısı:
        print("\t!Yanlış Tahmin! Daha Küçük Bi Sayı Dene")
    elif tahmin < pc_sayısı:
        print("\t!Yanlış Tahmin! Daha Büyük Bi Sayı Dene")
else:
    print("\nÜzgünüm, tahmin hakkın bitti. 😢")
    print(f"Doğru sayı: {pc_sayısı}")