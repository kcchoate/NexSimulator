using Osrs.Simulator.Domain.Interfaces;

namespace Osrs.Simulator.Domain.Models.Uniques.Nex;

public record TorvaPlateBody : IBossUnique<Bosses.Nex>
{
    public string Name => "Torva Plate Body";
    public int DropRateNumerator => 2;
    public int DropRateDenominator => 12;
}
