using Osrs.Simulator.Domain.Models.Bosses;

namespace Osrs.Simulator.Domain.Models.Uniques;

public abstract record BossUnique<T> where T : Boss
{
    public abstract string Name { get; }
    public abstract decimal DropRate { get; }
}
