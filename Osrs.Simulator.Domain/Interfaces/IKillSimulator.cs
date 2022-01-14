using Osrs.Simulator.Domain.Models;
using Osrs.Simulator.Domain.Models.Bosses;
using Osrs.Simulator.Domain.Models.Uniques;

namespace Osrs.Simulator.Domain.Interfaces;

public interface IKillSimulator<T> where T: Boss
{
    BossUnique<T>? SimulateDrop(int teamSize);
}
