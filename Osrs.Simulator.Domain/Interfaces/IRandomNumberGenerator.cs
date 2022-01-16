using Osrs.Simulator.Domain.Models;

namespace Osrs.Simulator.Domain.Interfaces;

public interface IRandomNumberGenerator
{
    public int GetRandomInt(int min, int max);
    public LootRoll GetRandomLootRoll();
}
