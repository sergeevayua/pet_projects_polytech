namespace Strategies.OrderStrategies;

public class AscendingOrder : IOrderStrategy
{
    public int Compare(double a, double b)
    {
        return a.CompareTo(b);
    }
}