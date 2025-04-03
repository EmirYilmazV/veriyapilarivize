using System;

namespace ConsoleApp7
{
    class Program
    {
        static void Main(string[] args)
        {
            Liste cydaListe = new Liste();
            int sayi, indis;

            int secim = menu();

            while (secim != 0)
            {
                switch (secim)
                {
                    case 1:
                        Console.Write("sayı : ");
                        sayi = int.Parse(Console.ReadLine());
                        cydaListe.basaEkle(sayi);
                        cydaListe.yazdir();
                        break;

                    case 2:
                        Console.Write("sayı : ");
                        sayi = int.Parse(Console.ReadLine());
                        cydaListe.sonaEkle(sayi);
                        cydaListe.yazdir();
                        break;

                    case 3:
                        Console.Write("indis : ");
                        indis = int.Parse(Console.ReadLine());
                        Console.Write("sayı : ");
                        sayi = int.Parse(Console.ReadLine());
                        cydaListe.arayaEkle(indis, sayi);
                        cydaListe.yazdir();
                        break;

                    case 4:
                        cydaListe.bastanSil();
                        cydaListe.yazdir();
                        break;

                    case 5:
                        cydaListe.sondanSil();
                        cydaListe.yazdir();
                        break;

                    case 6:
                        Console.Write("indis: ");
                        indis = int.Parse(Console.ReadLine());
                        cydaListe.aradanSil(indis);
                        cydaListe.yazdir();
                        break;

                    case 7:
                        cydaListe.terstenYazdir();
                        break;

                    default:
                        Console.WriteLine("Hatalı seçim yaptınız");
                        break;
                }
                secim = menu();

                
            }
                Console.Clear();
                Console.WriteLine("Program kapatıldı");
                Console.ReadKey();
        }

        private static int menu()
        {
            int secim;
            Console.WriteLine("\n\n1-Başa Ekle ");
            Console.WriteLine("2-Sona Ekle ");
            Console.WriteLine("3-Araya Ekle ");
            Console.WriteLine("4-Baştan Sil ");
            Console.WriteLine("5-Sondan Sil ");
            Console.WriteLine("6-Aradan Sil ");
            Console.WriteLine("7-Tersten Yazdır ");
            Console.WriteLine("0-Programı Kapat ");
            Console.Write("Seçiminiz: ");
            secim = int.Parse(Console.ReadLine());
            return secim;
        }
    }

    class Node
    {
        public int data;
        public Node next;
        public Node prev;

        public Node(int data)
        {
            this.data = data;
            this.next = null;
            this.prev = null;
        }
    }

    class Liste
    {
        Node head;
        Node tail;

        public Liste()
        {
            this.head = null;
            this.tail = null;
        }

        public void basaEkle(int data)
        {
            Node eleman = new Node(data);

            if (head == null)
            {
                head = tail = eleman;
                tail.next = head;
                tail.prev = head;
            }
            else
            {
                eleman.next = head;
                head.prev = eleman;
                head = eleman;
                head.prev = tail;
                tail.next = head;
            }
            Console.WriteLine("Başa eleman eklendi");
        }

        public void sonaEkle(int data)
        {
            Node eleman = new Node(data);

            if (head == null)
            {
                head = tail = eleman;
                tail.next = head;
                tail.prev = head;
            }
            else
            {
                tail.next = eleman;
                eleman.prev = tail;
                tail = eleman;
                tail.next = head;
                head.prev = tail;
            }
            Console.WriteLine("Sona eleman eklendi");
        }

        public void arayaEkle(int indis, int data)
        {
            Node eleman = new Node(data);

            if (head == null && indis == 0)
            {
                head = tail = eleman;
                tail.next = head;
                tail.prev = head;
                Console.WriteLine("Liste oluşturuldu, ilk eleman eklendi");
            }
            else if (indis == 0)
            {
                basaEkle(data);
            }
            else
            {
                int i = 0;
                Node temp = head;
                Node temp2 = null;

                while (temp != tail && i < indis)
                {
                    temp2 = temp;
                    temp = temp.next;
                    i++;
                }

                if (i == indis)
                {
                    temp2.next = eleman;
                    eleman.prev = temp2;
                    eleman.next = temp;
                    temp.prev = eleman;
                    Console.WriteLine("Araya eleman eklendi");
                }
                else
                {
                    Console.WriteLine("Geçersiz indis");
                }
            }
        }

        public void yazdir()
        {
            if (head == null)
            {
                Console.WriteLine("Liste boş");
                return;
            }

            Node temp = head;
            Console.Write("Başı ");
            do
            {
                Console.Write(temp.data + " -> ");
                temp = temp.next;
            } while (temp != head);
            Console.WriteLine("Son.");
        }

        public void terstenYazdir()
        {
            if (head == null)
            {
                Console.WriteLine("Liste boş");
                return;
            }

            Node temp = tail;
            Console.Write("Son -> ");
            do
            {
                Console.Write(temp.data + " -> ");
                temp = temp.prev;
            } while (temp != tail);
            Console.WriteLine("Baş.");
        }

        public void bastanSil()
        {
            if (head == null)
            {
                Console.WriteLine("Liste boş");
                return;
            }
            else if (head == tail)
            {
                head = tail = null;
                Console.WriteLine("Liste boşaldı");
            }
            else
            {
                head = head.next;
                head.prev = tail;
                tail.next = head;
                Console.WriteLine("Baştan eleman silindi");
            }
        }

        public void sondanSil()
        {
            if (head == null)
            {
                Console.WriteLine("Liste boş");
                return;
            }
            else if (head == tail)
            {
                head = tail = null;
                Console.WriteLine("Liste boşaldı");
            }
            else
            {
                tail = tail.prev;
                tail.next = head;
                head.prev = tail;
                Console.WriteLine("Sondan eleman silindi");
            }
        }

        public void aradanSil(int indis)
        {
            if (head == null)
            {
                Console.WriteLine("Liste boş");
                return;
            }

            int i = 0;
            Node temp = head;

            while (i < indis && temp != tail)
            {
                temp = temp.next;
                i++;
            }

            if (i == indis)
            {
                temp.prev.next = temp.next;
                temp.next.prev = temp.prev;
                Console.WriteLine("Aradan eleman silindi");
            }
            else
            {
                Console.WriteLine("Geçersiz indis");
            }
        }
    }
}
