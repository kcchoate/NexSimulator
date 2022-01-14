namespace Osrs.Simulator.Domain.Models.Uniques.Nex;

public record TorvaPlateLegs : NexUnique
{
    public override string Name => "Torva Plate Legs";
    public override decimal DropRate { get; } = new decimal(2) / new decimal(12);
}
