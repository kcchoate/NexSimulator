using Osrs.Simulator.Domain.Interfaces;

namespace Osrs.Simulator.Domain.Models.Uniques.Nex;

public record TorvaFullHelmet : IBossUnique<Bosses.Nex>
{
    public string Name => "Torva Full Helm";
    public int DropRateNumerator => 2;
    public int DropRateDenominator => 12;
}
