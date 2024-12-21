corba_menu = [ 'Mercimek', 'Tarhana', 'KremalıMantar' , 'KellePaça', 'Ezogelin']

musteri_istegi = input("İstediğin Çorba? ")

if musteri_istegi in corba_menu: 
    print("Çorbanız Hazırlanıyor...")
else:
    print("İstediğiniz" ,musteri_istegi, "çorbası menümüzde yok ama isterseniz menüye ekliyebiliriz.")

    son_karar = input( "{} çorbasının yapımı birz uzun sürebilir eminmisiniz ?".format(musteri_istegi))
    son_karar.lower()
    if son_karar == 'evet':
        print( musteri_istegi,"çorbası hazırlanıyor...")
    if son_karar == 'Evet':
        print( musteri_istegi,"çorbası hazırlanıyor...")
    else:
        print("Pekala menüden seçimini yap")
        print(corba_menu)