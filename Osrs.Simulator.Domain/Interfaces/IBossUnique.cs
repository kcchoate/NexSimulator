using Osrs.Simulator.Domain.Models.Bosses;

namespace Osrs.Simulator.Domain.Interfaces;

public interface IBossUnique<T> where T : Boss<T>
{
    string Name { get; }
    int DropRateNumerator { get; }
    int DropRateDenominator { get; }
}
