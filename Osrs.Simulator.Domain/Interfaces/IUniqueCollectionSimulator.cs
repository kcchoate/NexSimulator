using Osrs.Simulator.Domain.Models;
using Osrs.Simulator.Domain.Models.Bosses;
using Osrs.Simulator.Domain.Models.Uniques;
using Osrs.Simulator.Domain.Models.Uniques.Nex;

namespace Osrs.Simulator.Domain.Interfaces;

public interface IUniqueCollectionSimulator<T> where T : Boss
{
    SimulationResult<T> GetKillsForUniques(int teamSize, IEnumerable<BossUnique<T>> desiredUniques);
}
