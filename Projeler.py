
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


"""#pt PC'nin belirlediği (1-50 arası) 7 sayı ile kullanıcının girdiği 7 sayıyı tahmin etme oyunu
<Başla>
Dizi PC_Sayıları[7], Dizi Kullanıcı_Sayıları[7], Puan = 0, x, y

Sayaç (x = 0'dan PC_Sayıları.ElemanSayısı - 1'e kadar)
    PC_Sayıları[x] = RastgeleSayı(1, 50)
SayaçSonu

Sayaç (y = 0'dan Kullanıcı_Sayıları.ElemanSayısı - 1'e kadar)
    Yaz "Sayı Giriniz (1-50 arası):"
    Oku Kullanıcı_Sayıları[y]
SayaçSonu

Sayaç (x = 0'dan PC_Sayıları.ElemanSayısı - 1'e kadar)
    Sayaç (y = 0'dan Kullanıcı_Sayıları.ElemanSayısı - 1'e kadar)
        Eğer (PC_Sayıları[x] == Kullanıcı_Sayıları[y])
            Puan = Puan + 20
        EğerSonu
    SayaçSonu
SayaçSonu

Yaz "Puanınız = " + Puan
<Bitir>
"""

"""#pt Kullanıcının kendi belirlediği kadar sayı girmesi, bu sayıların toplamını bulması ve ters çevirerek yazdırması
Başla
Değişkenler: Adet, x, Toplam = 0, Kadcefa, Yedek
Yaz "Kaç adet sayı gireceksiniz?"
Oku Adet

Dizi Sayılar[Adet]

Sayaç (x = 0'dan Sayılar.ElemanSayısı - 1'e kadar)
    Yaz "Sayı giriniz:"
    Oku Sayılar[x]
SayaçSonu

Sayaç (x = 0'dan Sayılar.ElemanSayısı - 1'e kadar)
    Toplam = Toplam + Sayılar[x]
SayaçSonu

Yaz "Sayıların Toplamı = " + Toplam

Kadcefa = TamSayı(Sayılar.ElemanSayısı / 2)

Sayaç (x = 0'dan Kadcefa - 1'e kadar)
    Yedek = Sayılar[x]
    Sayılar[x] = Sayılar[Sayılar.ElemanSayısı - 1 - x]
    Sayılar[Sayılar.ElemanSayısı - 1 - x] = Yedek
SayaçSonu

Sayaç (x = 0'dan Sayılar.ElemanSayısı - 1'e kadar)
    Yaz Sayılar[x]
SayaçSonu

Bitir
"""

"""#pt Kullanıcının belirttiği kadar sayı girip toplamını ve tersini yazdırma
Başla
Değişkenler: adet, x, toplam = 0, kadcefa, yedek
Yaz "Kaç adet sayı gireceksiniz?"
Oku adet

Dizi sayılar[adet]

# Kullanıcıdan sayıları al
Sayaç (x = 0'dan sayılar.ElemanSayısı - 1'e kadar)
    Yaz "Sayı giriniz:"
    Oku sayılar[x]
SayaçSonu

# Sayıların toplamını hesapla
Sayaç (x = 0'dan sayılar.ElemanSayısı - 1'e kadar)
    toplam = toplam + sayılar[x]
SayaçSonu
Yaz "Sayıların toplamı = " + toplam

# Diziyi ters çevir
kadcefa = TamSayı(sayılar.ElemanSayısı / 2)
Sayaç (x = 0'dan kadcefa - 1'e kadar)
    yedek = sayılar[x]
    sayılar[x] = sayılar[sayılar.ElemanSayısı - 1 - x]
    sayılar[sayılar.ElemanSayısı - 1 - x] = yedek
SayaçSonu

# Ters çevrilen diziyi yazdır
Sayaç (x = 0'dan sayılar.ElemanSayısı - 1'e kadar)
    Yaz sayılar[x]
SayaçSonu

Bitir

"""

"""#pt Kullanıcının belirttiği kadar sayı girerek, bu sayıların toplamını bulma ve elemanları ters çevirme
Başla
Değişkenler: kactane, toplam = 0, x, islemsayisi, yedek
Yaz "Kaç sayı toplayacaksınız?"
Oku kactane

Dizi sayılar[kactane]

# Kullanıcıdan sayıları al
Sayaç (x = 0'dan sayılar.ElemanSayısı - 1'e kadar 1'er)
    Yaz "Sayı gir:"
    Oku sayılar[x]
SayaçSonu

# Sayıların toplamını hesapla
Sayaç (x = 0'dan sayılar.ElemanSayısı - 1'e kadar 1'er)
    toplam = toplam + sayılar[x]
SayaçSonu
Yaz "Sayıların toplamı = " + toplam

# Diziyi ters çevir
islemsayisi = TamSayı(sayılar.ElemanSayısı / 2)
Sayaç (x = 0'dan islemsayisi - 1'e kadar 1'er)
    yedek = sayılar[x]
    sayılar[x] = sayılar[sayılar.ElemanSayısı - 1 - x]
    sayılar[sayılar.ElemanSayısı - 1 - x] = yedek
SayaçSonu

# Ters çevrilen diziyi yazdır
Sayaç (x = 0'dan sayılar.ElemanSayısı - 1'e kadar 1'er)
    Yaz sayılar[x]
SayaçSonu

Bitir

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



"""#pt Diziyi Ters Çevirme Algoritması
Başla 

Değişkenler: KacTane, Dizi Sayılarım[KacTane], x, TamSayı, Yedek

Yaz "Dizinin boyutunu gir:"
Oku KacTane

Dizi Sayılarım[KacTane]

Sayaç (x = 0'dan KacTane - 1'e kadar)
    Yaz "Dizinin " + (x + 1) + ". elemanını gir:"
    Oku Sayılarım[x]
SayaçSonu

TamSayı = Tamsayı(KacTane / 2)

Sayaç (x = 0'dan TamSayı - 1'e kadar)
    Yedek = Sayılarım[x]
    Sayılarım[x] = Sayılarım[KacTane - 1 - x]
    Sayılarım[KacTane - 1 - x] = Yedek
SayaçSonu

Yaz "Dizinin Ters Çevirilmiş Hali:"
Sayaç (x = 0'dan KacTane - 1'e kadar)
    Yaz Sayılarım[x]
SayaçSonu

Bitir
"""

"""#pt En Büyük Sayıyı Bulma

Başla
Dizi Listeem[5], x
Değişken En_buyuk_sayı = 0

Sayaç(x=0'dan x=Listeem.ElemanSayısı-1'e kadar)
    Yaz("Listenin " + (x+1) + ". elemanını girin:")
    Oku Listeem[x]
SayaçSonu

En_buyuk_sayı = Listeem[0]  # İlk eleman en büyük olarak belirlenir

Sayaç(x=1'den x=Listeem.ElemanSayısı-1'e kadar)
    Eğer Listeem[x] > En_buyuk_sayı
        En_buyuk_sayı = Listeem[x]
SayaçSonu

Yaz("Listedeki en büyük sayı: " + En_buyuk_sayı)
Bitir"""


