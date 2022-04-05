namespace CodingTest;

public class Program  
{
    public static List<TB> Map<TA, TB>(List<TA> list, Func<TA, TB>? func = null)
    {
        var result = new List<TB>();

        if (list == null)
        {
            throw new ArgumentNullException(nameof(list));
        }

        if (func == null)
        {
            throw new ArgumentNullException(nameof(func));
        }

        if (list.Count == 0 )
            return result;

        foreach (var item in list)
        {
            result.Add(func(item));
        }

        return result;
    }

    public static TB? Fold<TA, TB>(List<TA?> source, TB? seed, Func<TB?, TA?, TB?> func)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }
        if (func == null)
        {
            throw new ArgumentNullException(nameof(func));
        }

        TB? current = seed;

        foreach (TA? item in source)
        {
            current = func(current, item);
        }

        return current;
    }

    public static List<B?> Map2<A, B>(List<A?> list, Func<A?, B?> f)
    {
        List<B>? fold = Fold(list, new List<B>(), (arr, x) =>
        {
            arr?.Add(f(x));
            return arr;
        });

        return fold;
    }

    public static void Main()
    {
        var inputMap = new List<int> {1, 2, 3};

        // Map methods

        var map1 = Map(inputMap, x => x + 1);
        var map2 = Map(inputMap, x => x.ToString());

        Console.WriteLine("Map1 Result:");
        map1.ForEach(Console.WriteLine);

        Console.WriteLine("Map2 Result:");
        map2.ForEach(Console.WriteLine);

        // Fold methods

        var fold1 = Fold(inputMap, 0, (sum, x) => sum + x);
        var fold2 = Fold(inputMap, "", (str, x) => str + x);

        Console.WriteLine("Fold1 Result:");
        Console.WriteLine(fold1);

        Console.WriteLine("Fold2 Result:");
        Console.WriteLine(fold2);

        // Map2 method

        var mapp2 = Map2(inputMap, (x) => x + Fold(inputMap, 0, (sum, x) => sum + x));

        Console.WriteLine("Mapp2 Result:");
        Console.WriteLine(mapp2);
    }
}