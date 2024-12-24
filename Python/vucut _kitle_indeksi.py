yas = int(input("\n\tYaşınızı Girin : "))
cinsiyet = input("\tCinsiyetinizi Seçin (1-Erkek/2-Kadın) : ")
boy = int(input("\tBoyunuzu CM Şeklinde Girin : "))
kilo = int(input("\tKilonuzu Girin : "))

boy=boy/100
vki=kilo/boy*boy

if yas>18:
    print("VKİ değerin ==>",vki)    
    if cinsiyet=="1":
        if vki<17:
            print("Aşırı Düşük Kilo")    
        elif vki>22:
            print("Aşırı Yüksek Kilo")
        else:
            print("Değerlerin Normal")
        
    elif cinsiyet=="2":
        if vki<15:
            print("Aşırı Düşük Kilo")    
        elif vki>20:
            print("Aşırı Yüksek Kilo")
        else:
            print("Değerlerin Normal")
    else:
        print("Geçersiz Cinsiyet Seçimi!")
else:
    print("Bu Program 18 Yaş Altı İçin Doğru Sonuç Vermeyebilir.")
