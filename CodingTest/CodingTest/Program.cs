using System;
using System.Reflection.Metadata.Ecma335;

namespace CodingTest
{
    public class Program  
    {
        public static List<B> Map<A, B>(List<A> list, Func<A, B> f)
        {
            var result = new List<B>();

            foreach (var a in list)
            {
                result.Add(f(a));
            }

            return result;
        }

        public static B Fold<A, B>(List<A> list, B initial, Func<B, A, B> folder)
        {
            foreach (var a in list)
            {
                initial = folder(initial, a);
            }

            return initial;
        }

        public static List<B> Map2<A, B>(List<A> list, Func<A, B> f)
        {
            var k = Fold(list, new List<B>(), (arr, x) =>
            {
                arr.Add(f(x));
                return arr;
            });

            return k;
        }

        public static void Main(string[] args)
        {
            var a = new List<int>() {1,2,3};

            var b = Map2(a, x => x.ToString() + '%');

            foreach (var i in b)
            {
                Console.WriteLine(i);
            }

        }
    }
}