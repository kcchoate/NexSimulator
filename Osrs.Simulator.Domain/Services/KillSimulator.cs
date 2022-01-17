using Osrs.Simulator.Domain.Interfaces;
using Osrs.Simulator.Domain.Models.Bosses;
using Osrs.Simulator.Domain.Models.Uniques;

namespace Osrs.Simulator.Domain.Services;

public class KillSimulator<T> : IKillSimulator<T> where T : Boss<T>
{
    private readonly IRandomNumberGenerator _rng;
    private readonly Boss<T> _bossInstance;

    public KillSimulator(IRandomNumberGenerator rng, Boss<T> bossInstance)
    {
        _rng = rng;
        _bossInstance = bossInstance;
    }

    public virtual UniqueItemName<T>? SimulateDrop(int teamSize)
    {
        var individualsDropRateFraction = _bossInstance.UniqueDropRateDenominator * teamSize;
        return _rng.GetRandomInt(1, individualsDropRateFraction) == 1 ? GetRandomUnique() : null;
    }

    protected virtual UniqueItemName<T> GetRandomUnique() => _bossInstance.GetBossUnique(_rng.GetRandomLootRoll()).Name;
}
