using Osrs.Simulator.Domain.Interfaces;

namespace Osrs.Simulator.Domain.Models.Bosses;

public abstract record Boss<T> where T : Boss<T>
{
    public abstract string Name { get; }
    protected BossUniqueCollection<T> BossUniqueCollection { get; }
    public abstract int UniqueDropRateDenominator { get; }

    protected Boss(IEnumerable<IBossUnique<T>> allBossUniques)
    {
        BossUniqueCollection = new BossUniqueCollection<T>(allBossUniques);
    }

    public IBossUnique<T> GetBossUnique(LootRoll lootRoll)
    {
        return BossUniqueCollection.GetRandomUnique(lootRoll);
    }
}