
class Practice
{
    static void Main()
    {
        Console.Write("Enter number of coupons: ");
        int n = int.Parse(Console.ReadLine());

        if (n < 1 || n > 100)
        {
            Console.WriteLine("Number of coupons must be between 1 and 100.");
            return;
        }

        int[] coupons = new int[n];

        Console.WriteLine("Enter coupon values, separated by spaces:");
        string[] inputs = Console.ReadLine().Split();

        if (inputs.Length != n)
        {
            Console.WriteLine("Input count doesn't match number of coupons.");
            return;
        }

        for (int i = 0; i < n; i++)
        {
            coupons[i] = int.Parse(inputs[i]);
        }

        int totalValue = 0;
        int maxValue = coupons[0];
        int maxPosition = 0;

        int small = 0, medium = 0, large = 0;

        for (int i = 0; i < n; i++)
        {
            int val = coupons[i];
            totalValue += val;

            if (val > maxValue)
            {
                maxValue = val;
                maxPosition = i;
            }

            if (val <= 50)
                small++;
            else if (val <= 100)
                medium++;
            else
                large++;
        }

        
        Console.WriteLine($"Total coupons redeemed  : {n}");
        Console.WriteLine($"Total value collected   : {totalValue}");
        Console.WriteLine($"Highest coupon redeemed : {maxValue} (coupon #{maxPosition + 1})");

        Console.WriteLine("\nCategory breakdown");
        Console.WriteLine($"Small  (≤50)   : {small}");
        Console.WriteLine($"Medium (51-100): {medium}");
        Console.WriteLine($"Large  (>100)  : {large}");
    }
}
