using Osrs.Simulator.Domain.Interfaces;

namespace Osrs.Simulator.Domain.Models.Bosses;

public abstract record Boss<T> where T : Boss<T>
{
    public abstract string Name { get; }
    protected abstract BossUniqueCollection<T> BossUniqueCollection { get; }
    public abstract int UniqueDropRateDenominator { get; }

    public IBossUnique<T> GetBossUnique(LootRoll lootRoll)
    {
        return BossUniqueCollection.GetRandomUnique(lootRoll);
    }
}