using System.Runtime.CompilerServices;
using Nex.Simulator.Domain.Interfaces;
using Nex.Simulator.Domain.Models;

namespace Nex.Simulator.Domain.Services;

public class NexKillSimulator : INexKillSimulator
{
    private const int DropRateFraction = 53;
    private const int TotalUniqueWeight = 12;

    private readonly IRandomNumberGenerator _rng;

    public NexKillSimulator(IRandomNumberGenerator rng)
    {
        _rng = rng;
    }

    public NexUnique? SimulateNexDrop(int teamSize)
    {
        var individualsDropRateFraction = DropRateFraction * teamSize;
        return _rng.GetRandomInt(1, individualsDropRateFraction) == 1 ? GetRandomNexUnique() : null;
    }

    private NexUnique GetRandomNexUnique()
    {
        var uniqueRoll = _rng.GetRandomInt(1, TotalUniqueWeight);
        return uniqueRoll switch
        {
            1 => new AncientHilt(),
            <= 3 => new NihilHorn(),
            <= 5 => new TorvaFullHelmet(),
            <= 7 => new TorvaPlateBody(),
            <= 9 => new TorvaPlateLegs(),
            <= 12 => new ZaryteVambraces(),
            _ => throw new SwitchExpressionException(uniqueRoll)
        };
    }
}
