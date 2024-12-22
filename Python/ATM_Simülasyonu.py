#Basit_ATM_Simülasyonu

baslangic_bakiyesi = 7500

sifre=input("\n\n\nLütfen Dört Haneli Şifreyi Girin : ")
if sifre=='1234':
    print(" Hoşgeldiniz \n \t1.Bakiye Sorgulama \n \t2.Para Çekme \n \t3.Para Yatırma")
    karar=input("Lütfen yapmak istediğiniz işlemi seçin : ")


    if karar=='1':
        print("\tŞuanki Hesap Bakiyeniz ==>",baslangic_bakiyesi,"TL")



    elif karar=='2':
        cekme=int(input("Çekmek İstediğiniz Tutarı Girin : "))
        if cekme>baslangic_bakiyesi:
            print("\tBakiyeniz Yetersiz")
        else:
            guncel_bakiye=(baslangic_bakiyesi-cekme)
            print("\tHesabınızdaki Güncel Bakiye ",guncel_bakiye)



    elif karar=='3':
        ekleme=int(input("Yatırmak İstediğiniz Tutarı Girin : "))
        guncel_bakiye=(baslangic_bakiyesi+ekleme)
        print("\tHesabınızdaki Güncel Bakiye ",guncel_bakiye)


    else:
        print("\tGeçersiz işlem")


else:
    print("Yanlış Şifre")