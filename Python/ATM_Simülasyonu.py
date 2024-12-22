#Basit_ATM_Simülasyonu

baslangic_bakiyesi = 7500

print("\n\n\n Hoşgeldiniz \n \t1.Bakiye Sorgulama \n \t2.Para Çekme \n \t3.Para Yatırma")
karar=input("Lütfen yapmak istediğiniz işlemi seçin : ")


if karar=='1':
    print("Şuanki Hesap Bakiyeniz ==>",baslangic_bakiyesi,"TL")
    
    
    
elif karar=='2':
    cekme=int(input("Çekmek İstediğiniz Tutarı Girin : "))
    guncel_bakiye=(baslangic_bakiyesi-cekme)
    print("Hesabınızdaki Güncel Bakiye ",guncel_bakiye)



else:
    ekleme=int(input("Yatırmak İstediğiniz Tutarı Girin : "))
    guncel_bakiye=(baslangic_bakiyesi+ekleme)
    print("Hesabınızdaki Güncel Bakiye ",guncel_bakiye)



