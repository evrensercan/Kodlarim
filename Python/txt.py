"""liste = [[1,2],[3,4],[5,6],[0,0]]
kullanıcı = {
    'Evren':'Sercan',
    'Taylan':'Testo',
    'Cripto':'Kemal'
}

kullanıcı.items()

for ad,soyad in kullanıcı.items():
    print("Ad :{} \t Soyad :{}".format(ad,soyad))
"""



listem = [4, 7, 1, 9, 3, 12, 15, 6, 17, 15, 70]
en_buyuk = listem[0]
en_kucuk = listem[0]
for syi in listem:
    if syi > en_buyuk:
        en_buyuk=syi
    if syi < en_kucuk:
        en_kucuk=syi
print("En büyük değer :",en_buyuk)
print("En küçük değer :",en_kucuk)




