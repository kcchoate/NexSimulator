using Osrs.Simulator.Domain.Models;
using Osrs.Simulator.Domain.Models.Bosses;
using Osrs.Simulator.Domain.Models.Uniques;

namespace Osrs.Simulator.Domain.Interfaces;

public interface IUniqueCollectionSimulator<T> where T : Boss<T>
{
    SimulationResult<T> GetKillsForUniques(int teamSize, IEnumerable<UniqueItemName<T>> desiredUniques);
}
