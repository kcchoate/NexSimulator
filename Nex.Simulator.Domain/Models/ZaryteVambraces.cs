namespace Nex.Simulator.Domain.Models;

public record ZaryteVambraces : NexUnique
{
    public override string Name { get; } = "Zaryte Vambraces";
    public override decimal DropRate { get; } = new decimal(1) / new decimal(12);
}
