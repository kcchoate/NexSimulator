using Osrs.Simulator.Domain.Models.Bosses;

namespace Osrs.Simulator.Domain.Interfaces;

public interface IKillSimulator<T> where T: Boss<T>
{
    IBossUnique<T>? SimulateDrop(int teamSize);
}
