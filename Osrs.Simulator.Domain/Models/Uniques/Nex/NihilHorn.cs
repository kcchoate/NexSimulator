using Osrs.Simulator.Domain.Interfaces;

namespace Osrs.Simulator.Domain.Models.Uniques.Nex;

public record NihilHorn : IBossUnique<Bosses.Nex>
{
    public string Name => "Nihil Horn";
    public int DropRateNumerator => 2;
    public int DropRateDenominator => 12;
}
