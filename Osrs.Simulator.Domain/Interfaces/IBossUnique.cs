using Osrs.Simulator.Domain.Models.Bosses;
using Osrs.Simulator.Domain.Models.Uniques;

namespace Osrs.Simulator.Domain.Interfaces;

public interface IBossUnique<T> where T : Boss<T>
{
    UniqueItemName<T> Name { get; }
    int DropRateNumerator { get; }
    int DropRateDenominator { get; }
}
