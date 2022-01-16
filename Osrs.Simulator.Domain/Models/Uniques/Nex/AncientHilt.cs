using Osrs.Simulator.Domain.Interfaces;

namespace Osrs.Simulator.Domain.Models.Uniques.Nex;

public record AncientHilt : IBossUnique<Bosses.Nex>
{
    public string Name => "Ancient Hilt";
    public int DropRateNumerator => 1;
    public int DropRateDenominator => 12;
}
