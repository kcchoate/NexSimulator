namespace Nex.Simulator.Domain.Models;

public record AncientHilt : NexUnique
{
    public override string Name { get; } = "Ancient Hilt";
    public override decimal DropRate { get; } = new decimal(1) / new decimal(12);
}
