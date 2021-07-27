using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace program
{
    class Program
    {
        const bool PrintInfo = false;

        static void Main(string[] args)
        {
            Console.WriteLine("Тестовое задание: ");
            Console.WriteLine("Введите число, либо нажмите Enter (будет посчитано 1е7)");
            String s = Console.ReadLine();
            uint N = 10000000;
            //uint N = 20;
            if (0 < s.Length)
                N = Convert.ToUInt32(s);
            ulong Sum = 2;
            ulong Count = 1;

            DateTime date1 = DateTime.Now;
            Dictionary<ulong, ulong> dictMap = new Dictionary<ulong, ulong>();

            dictMap.Add(1, 1);
            ulong step = 10000;
            ulong range = 1 * step;

            SortedSet<ulong> Ar = new SortedSet<ulong>();

            while (Count < N)
            {
                Ar.Clear();
                for (ulong i = 1; 2 * i * (i + 1) <= range; i++)
                {
                    ulong j;
                    ulong ind;
                    if(!dictMap.ContainsKey(i))
                        dictMap.Add(i, i);
                    for (j = dictMap[i]; true; j++)
                    {
                        ind = 2 * i * j + i + j;
                        if (ind > (ulong)range)
                            break;
                        Ar.Add(ind);//массив пропущенных на интервале
                    }
                    dictMap[i] = j;
                }

                ulong PrimeValue;

                for (ulong i = range - step + 1; i<=range; i++)
                {
                    if (Ar.Contains(i))  continue;

                    PrimeValue = 2 * i + 1;
                    Sum = Sum + PrimeValue;
                    Count++;

                    if (Count == N)  break;
                }
                range = range + step;
            }

            DateTime date2 = DateTime.Now;
            TimeSpan interval = date2 - date1;

            Console.WriteLine("Sum = " + Sum.ToString());
            Console.WriteLine("Count = " + Count.ToString());
            Console.WriteLine("Время выполнения = " + interval);
            Console.WriteLine("Нажмите Enter");
            Console.ReadLine();
        }
    }
}
