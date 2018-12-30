using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ogrenci_Kayit_Programi
{
    class Ogrenci
    {
        public string Ad, Soyad;
        public int Numarasi;
        public double N1, N2, F;

        public double NotOrtalamasi()
        {
            return (N1 + N2 + F) / 3;
        }
        public string TamAd()
        {
            return Ad + " " + Soyad;
        }
        public void BilgileriYazdir(int index)
        {
            Console.WriteLine();
            Console.WriteLine(index + ". Öğrencinin Adı Soyadı: " + TamAd());
            Console.WriteLine(index + ". Öğrencinin Numarası: " + Numarasi);
            Console.WriteLine(index + ". Öğrencinin Notları: {0}, {1}, {2}", N1, N2, F);
            Console.WriteLine(index + ". Öğrencinin Not Ortalaması: " + NotOrtalamasi());
            string durumu = NotOrtalamasi() >= 50 ? "GEÇTİ" : "KALDI";
            Console.WriteLine(index + ". Öğrencinin Durumu: " + durumu);
        }
        public void BilgileriYazdirKisa(int index)
        {
            Console.WriteLine();
            string durumu = NotOrtalamasi() >= 50 ? "GEÇTİ" : "KALDI";
            //if (NotOrtalamasi() >= 50)
            //{
            //    durumu = "GEÇTİ";
            //}
            //else
            //{
            //    durumu = "KALDI";
            //}
            Console.WriteLine(index + ". Öğrencinin Adı Soyadı: " + TamAd() + " - " + durumu);
        }
    }

    class Program
    {

        static List<Ogrenci> ogrenciler = new List<Ogrenci>();

        static void Main(string[] args)
        {
            // ÖĞRENCİ KAYIT PROGRAMI

            // 1. Öğrenci Ekle
            // 2. Öğrencileri Listele (Öğrenci numarasına göre Bilgisini göstersin, ekstra olarak not ortalamasına göre geçti veya kaldı yazsın. 50'den büyük eşitse Geçti, 50'den küçükse kaldı)
            // 3. Öğrenci Sil
            // 4. Öğrenci Ara (Ad, Soyad veya Numarasına göre)
            // 5. Tüm Öğrencilerin Not Ortalaması
            // 6. Programdan Çık

            char cevap = ' ';

            do
            {
                Console.Clear();
                Console.WriteLine("ÖĞRENCİ KAYIT PROGRAMI");
                Console.WriteLine("-----------------------");
                Console.WriteLine("1. Öğrenci Ekle");
                Console.WriteLine("2. Öğrencileri Listele");
                Console.WriteLine("3. Öğrenci Sil");
                Console.WriteLine("4. Öğrenci Ara");
                Console.WriteLine("5. Tüm Öğrencilerin Not Ortalaması");
                Console.WriteLine("6. Programdan Çık");

                Console.WriteLine();
                Console.WriteLine("Menüden yapmak istediğiniz işlemin numarasını giriniz");
                cevap = Console.ReadKey().KeyChar;  // Klavyeden kullanıcının klavyeden basmış olduğu karakteri alır.

                switch (cevap)
                {
                    case '1':
                        OgrenciEkle("ÖĞRENCİ EKLEME EKRANI");
                        AnaEkranaDon();
                        break;
                    case '2':
                        OgrencileriListele("ÖĞRENCİ lİSTELEME EKRANI");
                        AnaEkranaDon();
                        break;
                    case '3':
                        OgrenciSil("ÖĞRENCİ SİLME EKRANI");
                        AnaEkranaDon();
                        break;
                    case '4':
                        OgrenciAra("ÖĞRENCİ ARAMA EKRANI");
                        AnaEkranaDon();
                        break;
                    case '5':
                        OgrencilerinNotOrtalamasi();
                        AnaEkranaDon();
                        break;
                }
            } while (cevap != '6');

            Console.WriteLine();
            Console.WriteLine("Programımızı kullandığınız için teşekkür ederiz.");
            Console.WriteLine("Çıkmak için bir tuşa basın...");
            Console.ReadKey();

        }

        private static void OgrencilerinNotOrtalamasi()
        {
            double ToplamNot = 0;
            double sinifOrtalamasi = 0;
            if (ogrenciler.Count > 0)
            {
                for (int i = 0; i < ogrenciler.Count; i++)
                {
                    ToplamNot += ogrenciler[i].NotOrtalamasi();
                    // ToplamNot = ToplamNot + ogrenciler[i].NotOrtalamasi();
                }
                sinifOrtalamasi = ToplamNot / ogrenciler.Count;
            }
            Console.WriteLine();
            Console.WriteLine("Tüm öğrencilerin not ortalaması : " + sinifOrtalamasi);

        }

        private static void OgrenciAra(string baslik)
        {
            Console.Clear();
            Console.WriteLine(baslik);
            Console.WriteLine();

            if (ogrenciler.Count > 0)
            {
                Console.Write("Aramak istediğiniz öğrencinin numarasını giriniz > ");
                int numara = int.Parse(Console.ReadLine());

                bool kayit = false;

                for (int i = 0; i < ogrenciler.Count; i++)
                {
                    if (ogrenciler[i].Numarasi == numara)
                    {
                        ogrenciler[i].BilgileriYazdir(i + 1);
                        kayit = true;
                    }
                }
                if (!kayit)
                {
                    Console.WriteLine();
                    Console.WriteLine("Aradığınız kriterlere uygun öğrenci bulunamadı.");
                }
            }
        }

        private static void OgrenciSil(string baslik)
        {
            Console.Clear();
            Console.WriteLine(baslik);
            Console.WriteLine();
            OgrencileriListele("ÖĞRENCİ LİSTESİ");
            Console.WriteLine();

            if (ogrenciler.Count > 0)
            {
                Console.Write("Silmek istediğiniz öğrencinin sıra numarasını giriniz >");
                int silinecekIndex = int.Parse(Console.ReadLine());
                ogrenciler.RemoveAt(silinecekIndex - 1);
            }
        }

        private static void OgrencileriListele(string baslik)
        {
            Console.Clear();
            Console.WriteLine(baslik);
            Console.WriteLine();
            if (ogrenciler.Count > 0)
            {
                for (int i = 0; i < ogrenciler.Count; i++)
                {
                    ogrenciler[i].BilgileriYazdirKisa(i + 1);
                }
            }
            else
            {
                Console.WriteLine("Listelenecek öğrenci bulunamadı.");
            }
        }

        private static void OgrenciEkle(string baslik)
        {
            Console.Clear();
            Console.WriteLine(baslik);
            Console.WriteLine();
            Ogrenci ogr = new Ogrenci();
            Console.Write("Öğrencinin Adı: ");
            ogr.Ad = Console.ReadLine();
            Console.Write("Öğrencinin Soyadı: ");
            ogr.Soyad = Console.ReadLine();
            Console.Write("Öğrencinin Numarası: ");
            ogr.Numarasi = int.Parse(Console.ReadLine());
            Console.Write("1. Not: ");
            ogr.N1 = double.Parse(Console.ReadLine());
            Console.Write("2. Not: ");
            ogr.N2 = double.Parse(Console.ReadLine());
            Console.Write("Final Not: ");
            ogr.F = double.Parse(Console.ReadLine());
            ogrenciler.Add(ogr);
        }

        private static void AnaEkranaDon()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Ana menüye dönmek için bir tuşa basınız.");
            Console.ReadKey();
        }

    }
}
