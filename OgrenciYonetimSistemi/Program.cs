namespace OgrenciYonetimSistemi
{
    internal class Program
    {
        static string Sor(string soru)
        {
            Console.Write(soru);
            return Console.ReadLine();
        }
        static void Ekle(string ekle)
        {
          

            Console.WriteLine("Öğrenci ekle");
            Ogrenci ogrenci = new Ogrenci();
            ogrenci.Ad = Sor("Ad: ");
            ogrenci.Soyad = Sor("Soyad: ");
            ogrenci.Yas = int.Parse(Sor("Yaşınız:  "));
            ogrenci.Cinsiyet = Sor("Cinsiyetiniz:  ");
            ogrenci.DogumYılı = DateTime.Parse(Sor("Doğum Tarihiniz:  "));
            //date time kısmında  00.00.00 çıktı verdi onun nedenini öğren?
            ogrenci.OgrenciId = int.Parse(Sor("Öğrenci Numaranız:  "));

            ogrenciler.Add(ogrenci);
        }
        static Ogrenci? OgrenciBul(string arananAd)
        {
            Ogrenci? bulunanOgrenci = null;

            foreach(var ogrenci in ogrenciler)
            {
                if (arananAd == ogrenci.Ad)
                {
                    bulunanOgrenci=ogrenci;
                    break;
                }
            }
            return bulunanOgrenci;
        }



        static void OgrenciSil()
        {
            Console.Clear();
            Console.WriteLine("Öğrenci Sil");
            Console.WriteLine("\n1-Öğrenci numarası ile silmek istiyorum: ");
            Console.WriteLine("2-Öğrencinin adı ile silmek istiyorum");
            bool ogrenciBulundu = false;
            int inputSilmeSecimi = int.Parse(Sor("Yapmak istediğiniz işlemşi seçiniz: "));

            if (inputSilmeSecimi == 2)
            {
                string silinecekAd = Sor("Silmek istediğiniz öğrencinin adını girin: ");

                for (int i = 0; i < ogrenciler.Count; i++)
                {
                    if (ogrenciler[i].Ad.ToLower() == silinecekAd.ToLower())
                    {
                        Console.WriteLine($"{ogrenciler[i].Ad} {ogrenciler[i].Soyad} - {ogrenciler[i].Yas} - {ogrenciler[i].Cinsiyet} - {ogrenciler[i].DogumYılı} - {ogrenciler[i].OgrenciId} silindi.");
                        ogrenciler.RemoveAt(i);
                        ogrenciBulundu = true;
                        break;
                    }
                }

                if (!ogrenciBulundu)
                {
                    Console.WriteLine("Böyle bir öğrenci bulunamadı.");
                }

            }
            else if (inputSilmeSecimi == 1)
            {
                int silinecekNumara = int.Parse(Sor("Silmek istediğin öğrencini numarası: "));

                for (int i = 0;i < ogrenciler.Count; i++)
                {
                    if (ogrenciler[i].OgrenciId == silinecekNumara)
                    {
                        Console.WriteLine($"{ogrenciler[i].Ad} {ogrenciler[i].Soyad} - {ogrenciler[i].Yas} - {ogrenciler[i].Cinsiyet} - {ogrenciler[i].DogumYılı} - {ogrenciler[i].OgrenciId} silindi.");
                        ogrenciler.RemoveAt(i);
                        ogrenciBulundu = true;
                        break;  
                    }

                }
                if (!ogrenciBulundu)
                {
                    Console.WriteLine("Böyle bir öğrenci yok");
                }



            }
           

            Console.WriteLine("\nDevam etmek için bir tuşa basın");
            Console.ReadKey();
        }


        static List<Ogrenci> ogrenciler = new List<Ogrenci>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Öğrenci Sistemine Hoş geldiniz");
                Console.WriteLine("Yapmak istediğiniz işlemi seçiniz");
                Console.WriteLine("\n1-Kayıtlı öğrencileri listele");
                Console.WriteLine("2-Yeni öğrenci ekle");
                Console.WriteLine("3-Öğrenci ara");
                Console.WriteLine("4-Öğrenci düzenle");
                Console.WriteLine("5-Öğrenci sil");

                int kullanıcıSecimi = int.Parse(Sor("Hangi işlemi yapmak istiyorsunuz:  "));

                if (kullanıcıSecimi == 1)
                {
                    Console.WriteLine("1-Kayıtlı öğrencilerin hepsini göster:");
                    Console.WriteLine("2-Cinsiyete göre filtreleyerk göster:");
                    Console.WriteLine("3-İsime göre filtreleyerek göster:");

                    int inputFilitreSecim = int.Parse(Sor("Hangi işlemi yapmak istiyorsunuz?: "));

                    if (inputFilitreSecim == 1)
                    {
                        foreach(Ogrenci ogrenci in ogrenciler)
                        {
                            Console.WriteLine($"{ogrenci.Ad} {ogrenci.Soyad} - {ogrenci.Yas} - {ogrenci.Cinsiyet} - {ogrenci.DogumYılı} - {ogrenci.OgrenciId}");
                        }
                    }
                    else if (inputFilitreSecim==2)
                    {
                        string cinsiyetFiltre = Sor("Hangi cinsiyete göre filtrelemek istiyorsunuz(ERKEK/KADIN):  ").ToLower();

                        foreach(Ogrenci ogrenci in ogrenciler)
                        {
                            if (cinsiyetFiltre == ogrenci.Cinsiyet.ToLower())
                            {
                                Console.WriteLine($"{ogrenci.Ad} {ogrenci.Soyad} - {ogrenci.Yas} - {ogrenci.Cinsiyet} - {ogrenci.DogumYılı} - {ogrenci.OgrenciId}");
                            }
                        }

                    }
                    else if (inputFilitreSecim == 3)
                    {
                        string isimFilitre = Sor("Filtrelemek istediğiniz ismi giriniz:  ").ToLower();
                        
                        foreach(Ogrenci ogrenci in ogrenciler)
                        {
                            if (isimFilitre == ogrenci.Ad.ToLower())
                            {
                                Console.WriteLine($"{ogrenci.Ad} {ogrenci.Soyad} - {ogrenci.Yas} - {ogrenci.Cinsiyet} - {ogrenci.DogumYılı} - {ogrenci.OgrenciId}");

                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Geçersiz seçim.");
                    }
                    Console.WriteLine("\nDevam etmek için bir tuşa basın");
                    Console.ReadKey();

                }


                   
                else if (kullanıcıSecimi == 2)
                {
                    Ekle("Öğrenci ekle");
                }
                else if (kullanıcıSecimi == 3)
                {
                    Console.WriteLine("Öğrenci ara");
                    string inputArananOgrenci = Sor("Adı:  ");

                    Ogrenci? arananOgrenci = OgrenciBul(inputArananOgrenci);

                    if (arananOgrenci != null)
                    {
                        Console.WriteLine("Öğrenciyi buldum");
                        Console.WriteLine($"{arananOgrenci.Ad} {arananOgrenci.Soyad} {arananOgrenci.Yas}");
                    }
                    else
                    {
                        Console.WriteLine("Öğrenci bulunamadı");
                    }
                    Console.WriteLine("\nDevam etmek için bir tuşa basın");
                    Console.ReadKey();

                }
                else if (kullanıcıSecimi == 4)
                {
                    Console.WriteLine("Öğrenci düzenle");
                    string inputArananOgrenci = Sor("Düzenlemek istediğiniz öğrencini adını girin:  ");

                    Ogrenci? arananOgrenci = OgrenciBul(inputArananOgrenci);

                    if (arananOgrenci != null)
                    {
                        Console.WriteLine("\nÖğrenciyi buldum");
                        Console.WriteLine($"Kayıtlı öğrenci :  {arananOgrenci.Ad} {arananOgrenci.Soyad} - {arananOgrenci.Yas} - {arananOgrenci.Cinsiyet} - {arananOgrenci.DogumYılı} -- {arananOgrenci.OgrenciId}");

                        Console.WriteLine("\nYeni bilgileri girin: ");
                        arananOgrenci.Ad = Sor("Ad:  ");
                        arananOgrenci.Soyad = Sor("Soyad:  ");
                        arananOgrenci.Yas = int.Parse(Sor("Yas:  "));
                        arananOgrenci.Cinsiyet = Sor("Cinsiyet:  ");
                        arananOgrenci.DogumYılı = DateTime.Parse(Sor("Doğum yılı:  "));
                        arananOgrenci.OgrenciId = int.Parse(Sor("Öğrenci numarası:  "));

                    }

                    else
                    {
                        Console.WriteLine("Öğrenci bulunamadı.");
                    }
                    Console.WriteLine($"Yeni öğrenci:  {arananOgrenci.Ad} {arananOgrenci.Soyad} - {arananOgrenci.Yas} - {arananOgrenci.Cinsiyet} - {arananOgrenci.DogumYılı} -- {arananOgrenci.OgrenciId}");

                    Console.WriteLine("\nDevam etmek için bir tuşa basın");
                    Console.ReadKey();
                }
                else if (kullanıcıSecimi == 5)
                {

                    OgrenciSil();

                }
            }


            
        }
    }
}
