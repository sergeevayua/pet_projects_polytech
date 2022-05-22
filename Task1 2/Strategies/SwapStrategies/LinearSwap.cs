using Strategies.OrderStrategies;

namespace Strategies.SwapStrategies;

public abstract class LinearSwap : ISwapStrategy
{
    protected bool NeedSwap(double a, double b, IOrderStrategy orderer)
    {
        return orderer.Compare(a, b) == 1;
    }

    public abstract bool NeedSwap(double[] a, double[] b, IOrderStrategy orderer);
}