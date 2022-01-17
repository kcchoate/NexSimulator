using Osrs.Simulator.Domain.Models.Bosses;

namespace Osrs.Simulator.Domain.Models.Uniques;

public record UniqueItemName<T> where T : Boss<T>
{
    public string UniqueName { get; set; }

    internal UniqueItemName(string uniqueName) => UniqueName = uniqueName;
}
