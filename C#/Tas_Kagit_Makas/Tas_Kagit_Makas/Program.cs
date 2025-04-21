using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tas_Kagit_Makas
{
    class Program
    {
        static void Main(string[] args)
        {

            Random rastgele = new Random();
            int pc_seçimi = rastgele.Next(1, 4);

            Console.WriteLine("*********************************");
            Console.WriteLine("Taş/Kağıt/Makas Oyununa Hoşgeldin");
            Console.WriteLine("");
            Console.WriteLine("Taş için 1'i");
            Console.WriteLine("Kağıt için 2'yi");
            Console.WriteLine("Makas için 3'ü Tuşlayın");
            Console.Write("Seçimini Yap : ");

            string kullanıcı_secimi = Console.ReadLine();

            switch (pc_seçimi)
            {
                //pcSeçimi=Taş
                case 1:
                    Console.WriteLine("--------------------------");
                    Console.WriteLine("Bilgisayarın Seçimi => Taş");
                    switch (kullanıcı_secimi)
                    {

                        case "1": //kullanıcıSeçimi=Taş

                            Console.WriteLine("Senin Seçimin => Taş");
                            Console.WriteLine("");
                            Console.WriteLine("Durum Berabere");

                            break;

                        case "2"://kullanıcıSeçimi=Kağıt

                            Console.WriteLine("Senin Seçimin => Kağıt");
                            Console.WriteLine("");
                            Console.WriteLine("Bilgisayar Kazandı :( ");
                            break;

                        case "3"://kullanıcıSeçimi=Makas

                            Console.WriteLine("Senin Seçimin => Makas");
                            Console.WriteLine("");
                            Console.WriteLine("Tebrikler! Sen kazandın! 🎉");
                            break;

                    }
                    break;



                //pcSeçimi=Kağıt
                case 2:
                    Console.WriteLine("--------------------------");
                    Console.WriteLine("Bilgisayarın Seçimi => Kağıt");

                    switch (kullanıcı_secimi)
                    {

                        case "1"://kullanıcıSeçimi=Taş

                            Console.WriteLine("Senin Seçimin => Taş");
                            Console.WriteLine("");
                            Console.WriteLine("Bilgisayar Kazandı :( ");

                            break;

                        case "2"://kullanıcıSeçimi=Kağıt

                            Console.WriteLine("Senin Seçimin => Kağıt");
                            Console.WriteLine("");
                            Console.WriteLine("Durum Berabere");
                            break;

                        case "3"://kullanıcıSeçimi=Makas

                            Console.WriteLine("Senin Seçimin => Makas");
                            Console.WriteLine("");
                            Console.WriteLine("Tebrikler! Sen kazandın! 🎉");
                            break;

                    }

                    break;



                //pcSeçimi=Makas
                case 3:
                    Console.WriteLine("--------------------------");
                    Console.WriteLine("Bilgisayarın Seçimi => Makas");
                    switch (kullanıcı_secimi)
                    {

                        case "1"://kullanıcıSeçimi=Taş

                            Console.WriteLine("Senin Seçimin => Taş");
                            Console.WriteLine("");
                            Console.WriteLine("Tebrikler! Sen kazandın! 🎉");
                            break;

                        case "2"://kullanıcıSeçimi=Kağıt

                            Console.WriteLine("Senin Seçimin => Kağıt");
                            Console.WriteLine("");
                            Console.WriteLine("Bilgisayar Kazandı :( ");
                            break;

                        case "3"://kullanıcıSeçimi=Makas

                            Console.WriteLine("Senin Seçimin => Makas");
                            Console.WriteLine("");
                            Console.WriteLine("Durum Berabere");
                            break;

                    }
                    break;

            }



            Console.Read();
        }
    }
}
