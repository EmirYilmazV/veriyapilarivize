using System;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            StackYapisi stc = new StackYapisi();
            int sayi;

            int secim = menu();
            while (secim != 0)
            {
                switch (secim)
                {
                    case 1:
                        Console.WriteLine("Sayı:"); 
                        sayi = int.Parse(Console.ReadLine());
                        stc.push(sayi);
                        break;

                    case 2: 
                        sayi = stc.pop(); 
                        if (sayi != -1)
                        {
                            Console.WriteLine("Çıkan Sayı: " + sayi);
                        }
                        break;

                    case 3: 
                        Console.Clear();
                        stc.print(); 
                        break;

                    case 4: 
                        stc.topPrint();
                        break;

                    case 0: 
                        Console.WriteLine("Program sonlandırılıyor...");
                        break;

                    default:
                        Console.WriteLine("Hatalı Seçim!");
                        break;
                }
                secim = menu();
            }
        }

        private static int menu()
        {
            Console.WriteLine("\n1. Push");
            Console.WriteLine("2. Pop");
            Console.WriteLine("3. Print");
            Console.WriteLine("4. Top");
            Console.WriteLine("0. Exit");
            Console.Write("Seçiminiz: ");
            return int.Parse(Console.ReadLine());
        }
    }

    class Node
    {
        public int data;
        public Node next;
        public Node(int data)
        {
            this.data = data;
            next = null;
        }
    }

    class StackYapisi
    {
        Node top;

        public StackYapisi()
        {
            top = null;
        }

        public void push(int data)
        {
            Node eleman = new Node(data);
            if (top == null)
            {
                top = eleman;
                Console.WriteLine("Stack oluşturuldu, ilk eleman eklendi.");
            }
            else
            {
                eleman.next = top;
                top = eleman;
                Console.WriteLine("Eleman eklendi.");
            }
        }

        public int pop()
        {
            if (top == null)
            {
                Console.WriteLine("Stack boş!");
                return -1;
            }
            else
            {
                int sayi = top.data;
                top = top.next;
                Console.WriteLine(sayi + " stack'ten çıkarıldı.");
                return sayi;
            }
        }

        public void print()
        {
            if (top == null)
            {
                Console.WriteLine("Stack boş!");
            }
            else
            {
                Node temp = top;
                Console.WriteLine("Stack Elemanları:");
                while (temp != null)
                {
                    Console.WriteLine(temp.data);
                    temp = temp.next;
                }
            }
        }

        public void topPrint()
        {
            if (top == null)
            {
                Console.WriteLine("Stack boş!");
            }
            else
            {
                Console.WriteLine("Top Eleman: " + top.data);
            }
        }
    }
}
