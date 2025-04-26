using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Simülasyonu
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("Atm Simülasyonuna Hoşgeldiniz");
        tekrar:
            Console.WriteLine("");
            Console.Write("Şifre :");
            string sifre = Console.ReadLine();

            if (sifre == "1234")
            {
                Console.WriteLine("Giriş Başarılı");

                Console.WriteLine("1. Bakiye Sorgulama ");
                Console.WriteLine("2. Para Çekme");
                Console.WriteLine("3. Para Yatırma");
                Console.Write("Yapmak İstediğiniz İşlemi Seçin : ");
                string islem_secimi = Console.ReadLine();
                int baslangic_bakiyesi = 7500;
                switch (islem_secimi)
                {
                    case "1":
                        Console.WriteLine("Seçilen İşlem => BakiyeSorgulama ");

                        Console.WriteLine("Şuanki Hesap Bakiyesi ==> " + baslangic_bakiyesi + "TL");




                        break;
                    case "2":
                        Console.WriteLine("Seçilen İşlem => ParaÇekme ");

                        Console.Write("Çekmek İstediğiniz tutarı Girin :");
                        int cekme = int.Parse(Console.ReadLine());
                        if (cekme > baslangic_bakiyesi)
                        {
                            Console.WriteLine("Yetersiz Bakiye");

                        }
                        else
                        {
                            Console.WriteLine("Hesapdaki Kalan Bakiye ==> " + (baslangic_bakiyesi - cekme) + "tl");
                        }
                        break;
                        
                    case "3":
                        Console.WriteLine("Seçilen İşlem => ParaYatırma ");

                        Console.Write("Eklemek İstediğiniz tutarı Girin :");
                        int ekleme = int.Parse(Console.ReadLine());
                        Console.WriteLine("Hesapdaki Güncel Bakiye ==> " + (baslangic_bakiyesi + ekleme) + "tl");
                        
                        break;



                        break;
                }
                


            }
            else
            {
                Console.WriteLine("Hatalı Şifre Tekrar Dene");
                goto tekrar;
            }




            Console.Read();
        }
    }
}
