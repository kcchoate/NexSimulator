namespace Nex.Simulator.Domain;

public abstract record NexUnique
{
    public abstract string Name { get; }
    public abstract decimal DropRate { get; }
}
