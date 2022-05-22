using Strategies.OrderStrategies;
using Strategies.SwapStrategies;
using Strategies.SortStrategies;
using Strategies.SwapStrategies.ArraySwap;

namespace Solution;

public static class Program
{
    public static void Main(string[] args)
    {
        double[][] matrix =
        {
            new double[] { 1, 2, 3 },
            new double[] { 3, 2, 6 },
            new double[] { 5, 2, 3 },
            new double[] { 10, 2, 3 },
        };
        
        char option = '\n';
        string options = "Меню программы: \n" +
                         "1 - Выбрать порядок сортировки\n" +
                         "2 - Выбрать принцип сортировки\n" +
                         "3 - Сортировать\n" +
                         "0 - Выход из программы\n";

        IOrderStrategy orderer = new AscendingOrder();
        ISwapStrategy swapper = new SumSwap();
        ISortStrategy sorter = new BubbleSort();

        while (true)
        {
            Console.Clear();
            ShowMatrix(matrix);
            Console.WriteLine(options);
            option = Console.ReadKey().KeyChar;

            switch (option)
            {
                case '1':
                    orderer = ChooseOrderStrategy();
                    break;
                case '2':
                    swapper = ChooseSwapStrategy();
                    break;
                case '3':
                    sorter.Sort(ref matrix, swapper, orderer);
                    break;
                case '0':
                    return;
            }
        }
    }

    public static IOrderStrategy ChooseOrderStrategy()
    {
        char option = '\n';
        string options = "1 - По возрастанию\n" +
                              "2 - По убыванию\n";

        while (true)
        {
            Console.Clear();
            Console.WriteLine(options);
            option = Console.ReadKey().KeyChar;
            
            switch(option)
            {
                case '1':
                    return new AscendingOrder();
                case '2':
                    return new DescendingOrder();
            }
        }
    }
    
    public static ISwapStrategy ChooseSwapStrategy()
    {
        char option = '\n';
        string options = "1 - По сумме элементов строки\n" +
                             "2 - По максимальному элементу строки\n" +
                             "3 - По минимальному элементу строки\n";

        while (true)
        {
            Console.Clear();
            Console.WriteLine(options);
            option = Console.ReadKey().KeyChar;
            
            switch(option)
            {
                case '1':
                    return new SumSwap();
                case '2':
                    return new MaxValueSwap();
                case '3':
                    return new MinValueSwap();
            }
        }
    }

    public static void ShowMatrix(double[][] matrix, string info = "Текущая матрица:")
    {
        Console.WriteLine(info);
        foreach (var row in matrix)
        {
            foreach (var value in row)
            {
                Console.Write(value + " ");
            }
            Console.WriteLine();
        }
    }
}