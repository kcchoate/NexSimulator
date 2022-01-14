using Nex.Simulator.Domain.Interfaces;

namespace Nex.Simulator.Domain.Services;

public class NexUniqueSimulator : INexUniqueSimulator
{
    private readonly INexKillSimulator _nexKiller;

    public NexUniqueSimulator(INexKillSimulator nexKiller)
    {
        _nexKiller = nexKiller;
    }

    public (int requiredKills, IEnumerable<NexUnique> uniquesObtained) GetKillsForUniques(int teamSize, IEnumerable<NexUnique> desiredUniques)
    {
        var kills = 0;
        var obtainedUniques = new List<NexUnique>();
        var groupedDesiredUniques = desiredUniques.GroupBy(x => x.Name).ToList();
        while (true)
        {
            kills++;
            var unique = _nexKiller.SimulateNexDrop(teamSize);
            if (unique is null)
            {
                continue;
            }

            obtainedUniques.Add(unique);
            if (DoesUniqueListSuperSetDesiredUniques(obtainedUniques, groupedDesiredUniques))
            {
                return (kills, obtainedUniques);
            }
        }

    }

    private static bool DoesUniqueListSuperSetDesiredUniques(
        IEnumerable<NexUnique> obtainedUniques,
        IEnumerable<IGrouping<string, NexUnique>> desiredUniques
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
