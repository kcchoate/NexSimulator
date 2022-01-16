using Osrs.Simulator.Domain.Interfaces;
using Osrs.Simulator.Domain.Models;

namespace Osrs.Simulator.Domain.Services;

public class RandomNumberGenerator : IRandomNumberGenerator
{
    private readonly Random _rng = new();
    
    public int GetRandomInt(int min, int max) => _rng.Next(min, max + 1);
    public LootRoll GetRandomLootRoll() => new(_rng.NextDouble());
}
