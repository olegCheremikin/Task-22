using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Task_22
{
    class Program
    {
        static int[] RandomArray()
        {
            Console.Write("Введите размер массива: ");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[n];
            Random rnd = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(0, 100);
                Thread.Sleep(100);
                Console.WriteLine(array[i]);
            }
            return array;
        }
        static void SummInArray(Task task, object a)
        {
            int[] array = (int[])a;
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }
            Thread.Sleep(1000);
            Console.WriteLine("Сумма чисел в массиве = {0}", sum);
        }
        static void MaxInArray(Task task, object a)
        {
            int[] array = (int[])a;
            int max = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (max < array[i])
                {
                    max = array[i];
                }
            }
            Thread.Sleep(1000);
            Console.WriteLine("Максимальное число в массиве = {0}", max);
        }
        static void Main(string[] args)
        {
            Func<int[]> func = new Func<int[]>(RandomArray);
            Task<int[]> task1 = new Task<int[]>(func);
            task1.Start();
            Action<Task, object> actionTask1 = new Action<Task, object>(SummInArray);
            Task task2 = task1.ContinueWith(actionTask1, task1.Result);
            Action<Task, object> actionTask2 = new Action<Task, object>(MaxInArray);
            Task task3 = task2.ContinueWith(actionTask2, task1.Result);
            Console.ReadKey();

        }
    }
}
