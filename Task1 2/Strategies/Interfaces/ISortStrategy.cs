using Strategies.OrderStrategies;
using Strategies.SwapStrategies;

namespace Strategies.SortStrategies;

public interface ISortStrategy
{
    void Sort(ref double[][] a, ISwapStrategy swapper, IOrderStrategy orderer);
}