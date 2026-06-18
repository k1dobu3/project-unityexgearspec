using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseStart
{
    internal class Program
    {

        class House
        {
            public string street;
            public int number;

            public void Print()
            {
                Console.WriteLine($"Óëèöà {street}, {number}");
            }
        }


        static void TestFunc(ref int n)
        {
            n = 10;
            Console.WriteLine(n);
        }

        static void Main(string[] args)
        {
            //int a = 5;
            //int b = 5;
            //int c = 10;
            //if (b > a)
            //{
            //    Console.WriteLine($"×èñëî {b} áîëüøå ÷èñëà {a}");
            //}
            //else if (b < a)
            //{
            //    Console.WriteLine($"×èñëî {b} ìåíüøå ÷èñëà {a}");
            //}
            //else
            //{
            //    Console.WriteLine($"×èñëî {b} ðàâíî ÷èñëó {a}");
            //}

            //for (int i = 1; i < 10; i++)
            //{
            //    Console.WriteLine(i);
            //}



            //int count = 0;
            //while (count <= 10)
            //{
            //    count++;
            //    Console.WriteLine(count);
            //}



            //int[] numbers = new int[5];
            //int[] numbers2 = { 5, 6, 7, 8, 9 };
            //numbers2[4] = 15;
            //Console.WriteLine(numbers2[4]);



            //void Helloworld()
            //{
            //    Console.WriteLine("Hello World");
            //}

            //void Sum(int first, int sec)
            //{
            //    int sum = first + sec;
            //    Console.WriteLine(sum);
            //}

            //void Human(string name, int age)
            //{
            //    Console.WriteLine($"{name}, {age}");
            //}
            //Human("Êèðèëë", 22);



            //House tower = new House();
            //tower.street = "Êðàñíàÿ";
            //tower.number = 50;

            //tower.Print();


            // 2.3
            //short s = 0;
            int i = 0;
            long l = 0;
            //float f = 0;
            double d = 0;


            object o = d;
            double d2 = (double)o;

            ushort a = 15050;
            byte b = (byte)a;



            i = (int)l;
            l = i;


            TestFunc(ref i);


            //var c = 0f;


            if (o != null)
            {
                int i2 = Convert.ToInt32(o);
            }

            int[] array = new int[10000];


            List<int> list = new List<int>(80);
        }
    }
}
