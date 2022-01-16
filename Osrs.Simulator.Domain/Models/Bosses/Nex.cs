using Osrs.Simulator.Domain.Interfaces;
using Osrs.Simulator.Domain.Models.Uniques.Nex;

namespace Osrs.Simulator.Domain.Models.Bosses;

public record Nex : Boss<Nex>
{
    private static IEnumerable<IBossUnique<Nex>> _nexUniques { get; } = new IBossUnique<Nex>[]
    {
        new ZaryteVambraces(3, 12),
        new TorvaFullHelmet(2, 12),
        new TorvaPlateBody(2, 12),
        new TorvaPlateLegs(2, 12),
        new NihilHorn(2, 12),
        new AncientHilt(1, 12),
    };

    public Nex() : base(_nexUniques)
    {

    }

    public override string Name => "Nex";

    public override int UniqueDropRateDenominator => 53;
}
