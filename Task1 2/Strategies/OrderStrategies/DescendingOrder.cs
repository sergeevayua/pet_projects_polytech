namespace Strategies.OrderStrategies;

public class DescendingOrder : IOrderStrategy
{
    public int Compare(double a, double b)
    {
        return b.CompareTo(a);
    }
}