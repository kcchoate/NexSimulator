namespace Nex.Simulator.Domain.Interfaces;

public interface INexKillSimulator
{
    NexUnique? SimulateNexDrop(int teamSize);
}
