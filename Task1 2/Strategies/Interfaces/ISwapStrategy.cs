using Strategies.OrderStrategies;

namespace Strategies.SwapStrategies;

public interface ISwapStrategy
{
    bool NeedSwap(double[] a, double[] b, IOrderStrategy orderer);
}