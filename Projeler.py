
"""#pt Girilen sayının işaretini yaz
Başla
sayı
Yaz("Bir Sayı Girin :")
oku sayı
Eğer sayı>0
    Yaz("Girdiğiniz Sayı Pozitif")
Eğer sayı<0
    Yaz("Girdiğiniz Sayı Negatif")
Değilse 
    Yaz("Girdiğiniz sayı 0 Yani Nötr")
Bitir

"""


"""#pt bas dan bite kadar olan sayıları toplar.
Başla
Bas,Bit,Yedek,Toplam=0,
Yaz("Kaçla Başlasın?")
Oku Bas
Yaz("Kaçla Bitsin?")
Oku Bit
Eğer (Bas>Bit)
    Yaz("Nebiçimişyapıyon")

    Yedek=Bas
    Bas=Bit
    Bit=Yedek
sayaç (x=bas'den x=bit'e 1'er)    
    toplam = toplam + x

    eğer (x==bit)
        yaz("sonuç="+toplam)

    değilse
        yaz("aratoplam="+toplam)
sayaçsonu
Bitir
"""


"""#pt Sayaç kullanım örneği

Başla
Sayaç ( x=1'den x=100'e kadar 1'er )
    Yaz ( x + "-merhaba" )
Sayaçsonu
Bitir

"""


"""#pt Ortalama hesaplayıp geçtin kaldın yazma
Başla
vize,final,ortalama
yaz("Vize giriniz :")
oku vize
yaz("Final giriniz :")
oku final
ortalama = ((vize*0.4)+(final*0.6))
yaz ("sonuç:" + ortalama)
Eğer ortalama <50
    yaz("kaldınız")
Değilse 
    yaz ("geçtiniz")
Bitir

"""


"""#Asal Tespiti
<Başla>
sayı,asalmi=yanlış,x
Yaz "Bir Sayı Girin?"
Oku sayı
Sayaç(x=2'den sayı-1'e kadar)
    Eğer (sayı modx ==0)
        asalmi=doğru
SayaçSonu
Eğer(asalmi==yanlış)
    Yaz"Sayı Asaldır"
Değilse
    Yaz"Asal Değil"
<Bitir>
"""


"""#Diziler
<Başla>
Dizi Sayılar[10], toplam=0, x
Sayaç(x=0'dan x=9'a 1'er)
    Yaz"Sayı Giriniz"
    Oku Sayılar[x]
Sayaçsonu
Sayaç(x=0'dan x=9'a 1'er)
    Eğer(Sayılar[x] mod==0)
        toplam=toplam+Sayılar[x]
Sayaçsonu
<Bitir>
"""


"""#pt Listenin en büyük değerini bulma
<Başla>
Liste = [4, 7, 1, 9, 3]
En_Büyük_Değer = Liste[0]

Sayaç (Sayı in Liste)
    Eğer Sayı > En_Büyük_Değer
        En_Büyük_Değer = Sayı
Sayaçsonu

Yaz("En Büyük Değer: " + En_Büyük_Değer)
<Bitir>
"""