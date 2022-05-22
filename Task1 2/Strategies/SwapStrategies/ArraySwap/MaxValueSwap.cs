using Strategies.OrderStrategies;

namespace Strategies.SwapStrategies.ArraySwap;

public class MaxValueSwap : LinearSwap
{
    public sealed override bool NeedSwap(double[] a, double[] b, IOrderStrategy orderer)
    {
        return NeedSwap(a.Max(), b.Max(), orderer);
    }
}