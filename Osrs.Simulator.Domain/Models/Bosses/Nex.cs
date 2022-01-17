using Osrs.Simulator.Domain.Interfaces;
using Osrs.Simulator.Domain.Models.Uniques;
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

    protected override BossUniqueCollection<Nex> BossUniqueCollection { get; } = new(_nexUniques);

    public override string Name => "Nex";

    public override int UniqueDropRateDenominator => 53;
    public static class UniqueNames
    {
        public static UniqueItemName<Nex> NihilHorn { get; } = new("Nihil Horn");
        public static UniqueItemName<Nex> TorvaPlateBody { get; } = new("Torva Plate Body");
        public static UniqueItemName<Nex> TorvaPlateLegs { get; } = new("Torva Plate Legs");
        public static UniqueItemName<Nex> TorvaFullHelmet { get; } = new("Torva Full Helmet");
        public static UniqueItemName<Nex> AncientHilt { get; } = new("Ancient Hilt");
        public static UniqueItemName<Nex> ZaryteVambraces { get; } = new("Zaryte Vambraces");
    }
}
