using Osrs.Simulator.Domain.Interfaces;
using Osrs.Simulator.Domain.Models.Uniques.Nex;

namespace Osrs.Simulator.Domain.Models.Bosses;

public record Nex : Boss<Nex>
{
    private static IEnumerable<IBossUnique<Nex>> _nexUniques { get; } = new IBossUnique<Nex>[]
    {
        new ZaryteVambraces(),
        new TorvaFullHelmet(),
        new TorvaPlateBody(),
        new TorvaPlateLegs(),
        new NihilHorn(),
        new AncientHilt(),
    };

    public Nex() : base(_nexUniques)
    {

    }

    public override string Name => "Nex";

    public override int UniqueDropRateDenominator => 53;
}
