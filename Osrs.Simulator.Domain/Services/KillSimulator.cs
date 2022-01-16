using Osrs.Simulator.Domain.Interfaces;
using Osrs.Simulator.Domain.Models.Bosses;

namespace Osrs.Simulator.Domain.Services;

public class KillSimulator<T> : IKillSimulator<T> where T : Boss<T>, new()
{
    protected readonly IRandomNumberGenerator Rng;
    static readonly Boss<T> BossInstance = new T();

    public KillSimulator(IRandomNumberGenerator rng)
    {
        Rng = rng;
    }

    public virtual IBossUnique<T>? SimulateDrop(int teamSize)
    {
        var individualsDropRateFraction = BossInstance.UniqueDropRateDenominator * teamSize;
        return Rng.GetRandomInt(1, individualsDropRateFraction) == 1 ? GetRandomUnique() : null;
    }

    protected virtual IBossUnique<T> GetRandomUnique() => BossInstance.GetBossUnique(Rng.GetRandomLootRoll());
}
