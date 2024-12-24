#AyakkabıNumarasıKontrolSistemi
magaza = {
    '39' : 500,
    '40' : 600,
    '41' : 700,
    '43' : 800,
    '44' : 900,
    '45' : 1000
    }
nmr = input("\nAlmak İstediğiniz Ayakkabı Numarasını Girin :") 

if nmr in magaza:
    print("Mevcut")

else: 
    print("Seçtiğiniz Beden Tükenmiştir.\nMevcut ürünlere gözatın: ",magaza.keys())

























"""
if nmr in magaza: 
    fiyat=magaza[nmr]
    print("Seçtiğiniz Ürünün Fiyatı: ",fiyat,"TL")
         
    karar = input("Sepete Eklensinmi? (Evet/Hayır) :").lower() 
    if karar=='Evet':
        print("Ürün Sepetinize Eklenmiştir.")
    else:
        magaza.remove(nmr)  
        print("Diğer ürünlere gözatın ",magaza)
else: 
    print("Seçtiğiniz Beden Tükenmiştir.\nMevcut ürünlere gözatın: ",magaza) 
 
"""