using Strategies.OrderStrategies;
using Strategies.SwapStrategies;

namespace Strategies.SortStrategies;

public class BubbleSort : ISortStrategy
{
    protected void Swap(ref double a, ref double b)
    {
        (a, b) = (b, a);
    }

    protected void Swap(ref double[] a, ref double[] b)
    {
        int len = Math.Min(a.Length, b.Length);

        for (int i = 0; i < len; ++i)
        {
            Swap(ref a[i], ref b[i]);
        }
    }
    
    public void Sort(ref double[][] a, ISwapStrategy swapper, IOrderStrategy orderer)
    {
        for (int i = 0; i < a.Length - 1; ++i)
        {
            for (int j = i + 1; j < a.Length; ++j)
            {
                if (swapper.NeedSwap(a[i], a[j], orderer))
                {
                    Swap(ref a[i], ref a[j]);
                }
            }
        }
    }
}