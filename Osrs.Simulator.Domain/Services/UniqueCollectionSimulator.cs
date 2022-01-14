using Osrs.Simulator.Domain.Interfaces;
using Osrs.Simulator.Domain.Models;
using Osrs.Simulator.Domain.Models.Bosses;
using Osrs.Simulator.Domain.Models.Uniques;

namespace Osrs.Simulator.Domain.Services;

public class UniqueCollectionSimulator<T> : IUniqueCollectionSimulator<T> where T : Boss
{
    private readonly IKillSimulator<T> _killer;

    public UniqueCollectionSimulator(IKillSimulator<T> killer)
    {
        _killer = killer;
    }

    public SimulationResult<T> GetKillsForUniques(int teamSize, IEnumerable<BossUnique<T>> desiredUniques)
    {
        var kills = 0;
        var obtainedUniques = new List<BossUnique<T>>();
        var groupedDesiredUniques = desiredUniques.GroupBy(x => x.Name).ToList();
        while (true)
        {
            kills++;
            var unique = _killer.SimulateDrop(teamSize);
            if (unique is null)
            {
                continue;
            }

            obtainedUniques.Add(unique);
            if (DoesUniqueListSuperSetDesiredUniques(obtainedUniques, groupedDesiredUniques))
            {
                return new SimulationResult<T>(kills, obtainedUniques);
            }
        }

    }

    private static bool DoesUniqueListSuperSetDesiredUniques(
        IEnumerable<BossUnique<T>> obtainedUniques,
        IEnumerable<IGrouping<string, BossUnique<T>>> desiredUniques
    )
    {
        var obtainedUniqueCounts = obtainedUniques.GroupBy(x => x.Name);
        return desiredUniques.All(desiredUniqueType =>
        {
            var obtainedUniquesOfTheSameType = obtainedUniqueCounts.FirstOrDefault(u => u.Key == desiredUniqueType.Key);
            if (obtainedUniquesOfTheSameType is null)
            {
                return false;
            }

            return obtainedUniquesOfTheSameType.Count() >= desiredUniqueType.Count();
        });
    }
}
