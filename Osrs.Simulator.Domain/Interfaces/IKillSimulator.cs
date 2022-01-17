using Osrs.Simulator.Domain.Models.Bosses;
using Osrs.Simulator.Domain.Models.Uniques;

namespace Osrs.Simulator.Domain.Interfaces;

public interface IKillSimulator<T> where T: Boss<T>
{
    UniqueItemName<T>? SimulateDrop(int teamSize);
}
