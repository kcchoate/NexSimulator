using Osrs.Simulator.Domain.Interfaces;
using Osrs.Simulator.Domain.Models.Bosses;

namespace Osrs.Simulator.Domain.Models;

public record SimulationResult<T>(int Kills, IEnumerable<IBossUnique<T>> Uniques) where T: Boss<T>;
