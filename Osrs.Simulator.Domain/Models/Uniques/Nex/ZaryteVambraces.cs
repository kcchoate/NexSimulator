namespace Osrs.Simulator.Domain.Models.Uniques.Nex;

public record ZaryteVambraces : NexUnique
{
    public override string Name => "Zaryte Vambraces";
    public override decimal DropRate { get; } = new decimal(1) / new decimal(12);
}
