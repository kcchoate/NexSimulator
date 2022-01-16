using Osrs.Simulator.Domain.Interfaces;

namespace Osrs.Simulator.Domain.Models.Uniques.Nex;

public record TorvaPlateLegs : IBossUnique<Bosses.Nex>
{
    public string Name => "Torva Plate Legs";
    public int DropRateNumerator => 2;
    public int DropRateDenominator => 12;
}
