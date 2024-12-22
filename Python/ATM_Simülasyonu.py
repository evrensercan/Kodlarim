#Basit_ATM_Simülasyonu
baslangic_bakiyesi = 7500


print("\n\nATM tarafından desteklenen diller / Languages ​​supported by ATM")
print("1. Türkçe \n2. English")

secilen_dil=input("Dil seçin / Choose Language: ")


if secilen_dil == '1':
    
    sifre=input("\nLütfen Dört Haneli Şifreyi Girin : ")
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

#İngilizce
elif secilen_dil == '2':
     
    sifre=input("\nPlease Enter Four Digit Password: ")
    if sifre=='1234':
        print("Welcome \t1.Balance Inquiry \n \t2.Withdrawal \n \t3.Deposit Money")
        karar=input("Please select the action you wish to perform: ")


        if karar=='1':
            print("\tYour Current Account Balance ==>",baslangic_bakiyesi,"TL")



        elif karar=='2':
            cekme=int(input("Enter the amount you want to withdraw: "))
            if cekme>baslangic_bakiyesi:
                print("\tYour balance is insufficient")
            else:
                guncel_bakiye=(baslangic_bakiyesi-cekme)
                print("\tCurrent Balance in Your Account",guncel_bakiye)



        elif karar=='3':
            ekleme=int(input("Enter the amount you want to deposit: "))
            guncel_bakiye=(baslangic_bakiyesi+ekleme)
            print("\tCurrent Balance in Your Account",guncel_bakiye)


        else:
            print("\tInvalid operation")


    else:
        print("Wrong Password")
else:
    print("Geçersiz İşlem / Invalid Transaction")