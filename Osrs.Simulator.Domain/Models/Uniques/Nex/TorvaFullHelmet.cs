using Osrs.Simulator.Domain.Interfaces;

namespace Osrs.Simulator.Domain.Models.Uniques.Nex;

public record TorvaFullHelmet(int DropRateNumerator, int DropRateDenominator) : IBossUnique<Bosses.Nex>
{
    public string Name => "Torva Full Helm";
}
