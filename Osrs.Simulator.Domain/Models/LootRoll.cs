namespace Osrs.Simulator.Domain.Models;

public record struct LootRoll
{
    public LootRoll(double lootRollValue)
    {
        _lootRollValue = Math.Clamp(lootRollValue, 0, 1);
    }

    private double _lootRollValue;
    public double LootRollValue 
    {
        get => _lootRollValue;
        init => _lootRollValue = Math.Clamp(value, 0, 1);
    }
}
