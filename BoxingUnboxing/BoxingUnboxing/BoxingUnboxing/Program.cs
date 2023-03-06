using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        const int numIterations = 10000000;

        Stopwatch stopwatch = Stopwatch.StartNew();
        for (int i = 0; i < numIterations; i++)
        {
            object o = i;
            int j = (int)o;
        }
        stopwatch.Stop();
        Console.WriteLine($"Boxing: {stopwatch.ElapsedMilliseconds}ms");

        List<object> mixedList = new List<object>();
        for (int i = 0; i < numIterations; i++)
        {
            mixedList.Add(i);
        }
        stopwatch.Restart();
        for (int i = 0; i < numIterations; i++)
        {
            int j = (int)mixedList[i];
        }
        stopwatch.Stop();
        Console.WriteLine($"Unboxing: {stopwatch.ElapsedMilliseconds}ms");
    }
}
