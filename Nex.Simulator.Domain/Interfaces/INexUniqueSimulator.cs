using Nex.Simulator.Domain.Models;

namespace Nex.Simulator.Domain.Interfaces;

public interface INexUniqueSimulator
{
    SimulationResult GetKillsForUniques(int teamSize, IEnumerable<NexUnique> desiredUniques);
}
