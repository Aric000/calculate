using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            for (int i = 0; i < 100000; i++)
            {
                numbers.Add(i);
            }
            int target = 150056;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var a = GetNumIndex1(numbers.ToArray(), target);
            stopwatch.Stop();
            var al = stopwatch.ElapsedMilliseconds;
            stopwatch.Restart();
            var b = GetNumIndex2(numbers.ToArray(), target);
            stopwatch.Stop();
            var bl = stopwatch.ElapsedMilliseconds;
            Console.WriteLine("方法一：{0},耗时：{1}", string.Join(',', a), al);
            Console.WriteLine("方法二：{0},耗时：{1}", string.Join(',', b), bl);
            Console.ReadKey();
        }

        /// <summary>
        /// 方法一：暴力破解法
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int[] GetNumIndex1(int[] numbers, int target)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[i] + numbers[j] == target)
                    {
                        return new int[] { i, j };
                    }
                }
            }
            return new int[] { -1, -1 };
        }

        /// <summary>
        /// 方法二：hash一遍轮询
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int[] GetNumIndex2(int[] numbers, int target)
        {
            Hashtable hashtable = new Hashtable();
            for (int i = 0; i < numbers.Length; i++)
            {
                int diffVal = target - numbers[i];
                if (hashtable.Contains(diffVal))
                {
                    return new int[] { (int)hashtable[diffVal], i };
                }
                else
                {
                    hashtable.Add(numbers[i], i);
                }
            }
            return new int[] { -1, -1 };
        }
    }
}
