using Osrs.Simulator.Domain.Interfaces;
using Osrs.Simulator.Domain.Models.Bosses;
using Osrs.Simulator.Domain.Models.Uniques;

namespace Osrs.Simulator.Domain.Services;

public abstract class KillSimulator<T> : IKillSimulator<T> where T : Boss
{
    protected readonly IRandomNumberGenerator Rng;

    protected KillSimulator(IRandomNumberGenerator rng)
    {
        Rng = rng;
    }

    public abstract BossUnique<T>? SimulateDrop(int teamSize);
}
