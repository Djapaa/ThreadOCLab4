using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace ThreadOCLab4
{
    class Program
    {

        static void MethodSearchEvenNumber()
        {
            Random rnd = new Random();


            for (int i = 0; i < 20; i++)
            {
                int num = rnd.Next(100);
                if (num % 2 == 0)
                {
                    Console.WriteLine($"2 поток : {num}");
                }
                Thread.Sleep(300);
            }
        }
        static void MethodSearchOddNumber(object nums)
        {
            
                List<int> n = (List<int>)nums;
                foreach (int a in n)
                {
                if (a % 2 == 1)
                {
                    Console.WriteLine($"1 поток: {a}");
                   
                }
                Thread.Sleep(300);
            }
            
        }
        static void MethodSearchEvenThree()
        {
            Random rnd = new Random();

            for (int i = 0; i < 20; i++)
            {
                int num = rnd.Next(100);
                if (num % 3 == 0)
                {
                    Console.WriteLine($"3 поток : {num}");
                }
                Thread.Sleep(300);
            }
        }

        static void Main(string[] args)
        {
            Random rnd = new Random();
            List<int> num = new List<int>();
            for (int i = 0; i < 10; i++)
                num.Add(rnd.Next(100));


            //int[] nums = new int[10];
            //for (int i = 0; i < 10; i++)
            //    nums[i] = rnd.Next(100);


            Thread thread1 = new Thread(MethodSearchEvenNumber);
            Thread thread2 = new Thread(new ParameterizedThreadStart(MethodSearchOddNumber));
            thread1.Start();

            thread2.Start(num);

            Thread t = new Thread(() => { MethodSearchEvenThree(); });
            t.Start();
            Console.ReadLine();
        }


    }
}
