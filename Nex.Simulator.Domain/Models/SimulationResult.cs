namespace Nex.Simulator.Domain.Models;

public record SimulationResult(int Kills, IEnumerable<NexUnique> Uniques);
