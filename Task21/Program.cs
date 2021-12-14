using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Task21
{
    /* Имеется пустой участок земли (двумерный массив) и план сада, который необходимо реализовать. Эту задачу выполняют два садовника, 
 * которые не хотят встречаться друг с другом. Первый садовник начинает работу с верхнего левого угла сада и перемещается слева направо, 
 * сделав ряд, он спускается вниз. Второй садовник начинает работу с нижнего правого угла сада и перемещается снизу вверх, сделав ряд, он перемещается влево. 
 * Если садовник видит, что участок сада уже выполнен другим садовником, он идет дальше. Садовники должны работать параллельно. 
 * Создать многопоточное приложение, моделирующее работу садовников.
 */
    class Program
    {
        static int m;
        static int n;
        static int[,] place;

        static void Main(string[] args)
        {
            #region Инициализация переменных
            Console.Write("Введите целое число m: ");
            m = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите целое число n: ");
            n = Convert.ToInt32(Console.ReadLine());
            place = new int[m, n];
            #endregion


            ThreadStart threadStart1 = new ThreadStart(Gardener1);
            Thread myThread1 = new Thread(threadStart1);

            ThreadStart threadStart2 = new ThreadStart(Gardener2);
            Thread myThread2 = new Thread(threadStart2);

            myThread1.Start();
            myThread2.Start();

            myThread1.Join();
            myThread2.Join();

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {                    
                    Thread.Sleep(300);
                    if (place[i, j] == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.BackgroundColor = ConsoleColor.Yellow;
                    }
                    else if (place[i, j] == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.BackgroundColor = ConsoleColor.DarkCyan;
                    }
                    Console.Write(place[i, j] + " ");
                }
                Console.WriteLine("\r");
            }
            Console.ReadKey();
        }
        static void Gardener1()
        {
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (place[i, j] == 0)
                    {
                        place[i, j] = 1;
                        Thread.Sleep(1);
                    }
                }
            }
            Console.Clear();
        }
        static void Gardener2()
        {
            for (int i = n - 1; i > 0; i--)
            {
                for (int j = m - 1; j > 0; j--)
                {
                    if (place[j, i] == 0)
                    {
                        place[j, i] = 2;
                        Thread.Sleep(1);
                    }
                }
            }
        }
    }
}
