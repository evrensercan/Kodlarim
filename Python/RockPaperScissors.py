import random
pc_secimi=random.randint(1,3)
print("\nSeçimini Yap \n\t1-Taş \n\t2-Kağıt \n\t3-Makas")
kullanıcı_secimi=int(input("Saçimin: "))

if pc_secimi==1:
    if kullanıcı_secimi==1:
        print("\nPC seçimi ==> Taş \nSenin seçimin ==> Taş")
        print("Sonuç ==> 'Berabere'")
    if kullanıcı_secimi==2:
        print("\nPC seçimi ==> Taş \nSenin seçimin ==> Kağıt")
        print("Sonuç ==> 'Sen Kazandın'")
    if kullanıcı_secimi==3:
        print("\nPC seçimi ==> Taş \nSenin seçimin ==> Makas")
        print("Sonuç ==> 'Bilgisayar Kazandı'")

if pc_secimi==2:
    if kullanıcı_secimi==1:
        print("\nPC seçimi ==> Kağıt \nSenin seçimin ==> Taş")
        print("Sonuç ==> 'Bilgisayar Kazandı'")
    if kullanıcı_secimi==2:
        print("\nPC seçimi ==> Kağıt \nSenin seçimin ==> Kağıt")
        print("Sonuç ==> 'Berabere'")
    if kullanıcı_secimi==3:
        print("\nPC seçimi ==> Kağıt \nSenin seçimin ==> Makas")
        print("Sonuç ==> 'Sen Kazandın'")

if pc_secimi==3:
    if kullanıcı_secimi==1:
        print("\nPC seçimi ==> Makas \nSenin seçimin ==> Taş")
        print("Sonuç ==> 'Sen Kazandın'")
    if kullanıcı_secimi==2:
        print("\nPC seçimi ==> Makas \nSenin seçimin ==> Kağıt")
        print("Sonuç ==> 'Bilgisayar Kazandı'")
    if kullanıcı_secimi==3:
        print("\nPC seçimi ==> Makas \n Senin seçimin ==> Makas")
        print("Sonuç ==> 'Berabere'")