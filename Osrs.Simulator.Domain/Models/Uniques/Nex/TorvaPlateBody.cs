namespace Osrs.Simulator.Domain.Models.Uniques.Nex;

public record TorvaPlateBody : NexUnique
{
    public override string Name => "Torva Plate Body";
    public override decimal DropRate { get; } = new decimal(2) / new decimal(12);
}
