#AyakkabıNumarasıKontrolSistemi
magaza = ['39','40','41','43','44','45']
nmr = input("Almak İstediğiniz Ayakkabı Numarasını Girin :")


if nmr in magaza:
    
    if nmr==39:
        print("Seçtiğiniz Ürünün Fiyatı 500TL ")
    if nmr==40: 
        print("Seçtiğiniz Ürünün Fiyatı 550TL ")
    if nmr==41: 
        print("Seçtiğiniz Ürünün Fiyatı 600TL ")
    if nmr==43: 
        print("Seçtiğiniz Ürünün Fiyatı 700TL ")
    if nmr==44: 
        print("Seçtiğiniz Ürünün Fiyatı 750TL ")
    else : 
        print("Seçtiğiniz Ürünün Fiyatı 800TL ")

else:
    print("Seçtiğiniz Beden Tükenmiştir. ")
