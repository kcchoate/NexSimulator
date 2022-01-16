using Osrs.Simulator.Domain.Interfaces;

namespace Osrs.Simulator.Domain.Models.Uniques.Nex;

public record ZaryteVambraces : IBossUnique<Bosses.Nex>
{
    public string Name => "Zaryte Vambraces";
    public int DropRateNumerator => 3;
    public int DropRateDenominator => 12;
}
