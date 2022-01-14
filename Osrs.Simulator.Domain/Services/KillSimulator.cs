using Osrs.Simulator.Domain.Interfaces;
using Osrs.Simulator.Domain.Models.Bosses;
using Osrs.Simulator.Domain.Models.Uniques;

namespace Osrs.Simulator.Domain.Services;

public abstract class KillSimulator<T> : IKillSimulator<T> where T : Boss
{
    protected abstract int UniqueDropRateDenominator { get; }

    protected readonly IRandomNumberGenerator Rng;

    protected KillSimulator(IRandomNumberGenerator rng)
    {
        Rng = rng;
    }

    public BossUnique<T>? SimulateDrop(int teamSize)
    {
        var individualsDropRateFraction = UniqueDropRateDenominator * teamSize;
        return Rng.GetRandomInt(1, individualsDropRateFraction) == 1 ? GetRandomUnique() : null;
    }

    protected abstract BossUnique<T> GetRandomUnique();
}
