namespace Nex.Simulator.Domain.Models;

public record TorvaPlateLegs : NexUnique
{
    public override string Name { get; } = "Torva Plate Legs";
    public override decimal DropRate { get; } = new decimal(2) / new decimal(12);
}
