namespace positive_number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] integers = { -10, 15, 0, 23, -8, 42, -7, 3 };
            int positiveCount = Count(integers, x => x > 0);
            Console.WriteLine("Количество чисел больше 0: " + positiveCount);
        }
        private static int Count(int[] numbers, Predicate<int> func)
        {
            int count = 0;
            foreach (int i in numbers)
            {
                if (func(i))
                    count++;
            }
            return count;
        }
    }
}
