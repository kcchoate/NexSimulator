namespace Nex.Simulator.Domain.Interfaces;

public interface INexUniqueSimulator
{
    (int requiredKills, IEnumerable<NexUnique> uniquesObtained) GetKillsForUniques(int teamSize,
        IEnumerable<NexUnique> desiredUniques);
}
