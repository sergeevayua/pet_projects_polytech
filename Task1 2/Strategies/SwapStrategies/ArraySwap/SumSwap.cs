using Strategies.OrderStrategies;

namespace Strategies.SwapStrategies.ArraySwap;

public class SumSwap : LinearSwap
{
    public sealed override bool NeedSwap(double[] a, double[] b, IOrderStrategy orderer)
    {
        return NeedSwap(a.Sum(), b.Sum(), orderer);
    }
}