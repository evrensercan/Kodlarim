import random
kazanan=0
print("\n\n\tSayı Tahmin.2 Oyununa Hoşgeldiniz")
rastgele_sayi=random.randint(1, 7)
snf=["Evren","Aylin","Can","Elif","Arda","Ceyda","Kerem"]
print("\nOyuncular ==> ",snf)
print("[1 ile 7 arasında bi sayı tahmin edin.]")
for ogrenci in snf:
    tahmin = int(input(f"\t\n{ogrenci} Tahmini :")) 
    if rastgele_sayi == tahmin:
        kazanan=ogrenci

if kazanan:
    print(f"\t\nDoğru Tahminde Bulunan: {kazanan} 🎉")
else:
    print("\t\nMaalesef kimse doğru tahminde bulunamadı. 😢")
    print(f"Doğru Sayı: {rastgele_sayi}")