namespace Osrs.Simulator.Domain.Models.Uniques.Nex;

public record NihilHorn : NexUnique
{
    public override string Name => "Nihil Horn";
    public override decimal DropRate { get; } = new decimal(2) / new decimal(12);
}
