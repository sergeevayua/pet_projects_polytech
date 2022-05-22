using Strategies.OrderStrategies;

namespace Strategies.SwapStrategies.ArraySwap;

public class MinValueSwap : LinearSwap
{
    public sealed override bool NeedSwap(double[] a, double[] b, IOrderStrategy orderer)
    {
        return NeedSwap(a.Min(), b.Min(), orderer);
    }
}