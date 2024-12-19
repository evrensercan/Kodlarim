#AyakkabıNumarasıKontrolSistemi
magaza = ['39','40','41','43','44','45']
nmr = input("Almak İstediğiniz Ayakkabı Numarasını Girin :")

if nmr in magaza:
    print("Seçtiğiniz Beden Mevcuttur.")
else:
    print("Seçtiğiniz Beden Tükenmiştir. ")