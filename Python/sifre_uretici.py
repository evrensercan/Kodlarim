import random

uzunluk=int(input("\n\tŞifren Kaç Haneli Olsun? :"))
sifrem=""
for x in range(uzunluk):
    rst=random.randint(0,9)  
    sifrem=sifrem+str(rst)
    
print("\tÖnerilen Şifre ==> : ",sifrem)








