using Osrs.Simulator.Domain.Interfaces;

namespace Osrs.Simulator.Domain.Models.Bosses;

public class BossUniqueCollection<T> where T : Boss<T>
{
    /// <summary>
    /// This collection holds the "scaled" values for uniques. This means that if we have 3 uniques with drop rates 1/8, 1/16, and 13/16,
    /// our dictionary will contain { {2, UniqueA}, {3, UniqueB}, {16, UniqueC} }. When we retrieve a random unique, we scale the random
    /// value by the least common denominator (in this case 16), then retrieve the value from the dictionary for which the key is the
    /// lowest key which is greater than the scaled value, e.g. if we roll a .1, we scale to 1.6, and retrieve UniqueA. If we roll a .5,
    /// we scale to 8, and retrieve UniqueC.
    /// </summary>
    private Dictionary<int, IBossUnique<T>> _bossUniques { get; }
    private int _leastCommonDenominator { get; }

    public BossUniqueCollection(IEnumerable<IBossUnique<T>> allBossUniques)
    {
        _leastCommonDenominator = GetLeastCommonMultiple(allBossUniques.Select(x => x.DropRateDenominator));
        _bossUniques = CalculateBossUniqueLookupTable(allBossUniques, _leastCommonDenominator);
    }

    public IBossUnique<T> GetRandomUnique(LootRoll lootRoll)
    {
        var lootRollValue = lootRoll.LootRollValue * _leastCommonDenominator;
        var bossUnique = _bossUniques[_bossUniques.Keys.Min()];
        foreach (var (dropValue, currentBossUnique) in _bossUniques.OrderBy(x => x.Key))
        {
            bossUnique = currentBossUnique;
            if (lootRollValue < dropValue)
            {
                return bossUnique;
            }
        }
        return bossUnique;
    }

    private static Dictionary<int, IBossUnique<T>> CalculateBossUniqueLookupTable(IEnumerable<IBossUnique<T>> allBossUniques, int leastCommonDenominator)
    {
        allBossUniques = allBossUniques ?? throw new ArgumentNullException(nameof(allBossUniques));
        if (!allBossUniques.Any())
        {
            throw new ArgumentException("At least one element must exist in the collection.", nameof(allBossUniques));
        }
        if (allBossUniques.Sum(x => x.DropRateNumerator * (leastCommonDenominator / x.DropRateDenominator)) != leastCommonDenominator)
        {
            throw new ArgumentException("The sum of the DropRates of the items in the collection must equal 1.", nameof(allBossUniques));
        }

        return allBossUniques.Aggregate(new Dictionary<int, IBossUnique<T>>(), (dict, curr) =>
        {
            var currentMaxWeight = dict.Keys.Any() ? dict.Keys.Max() : 0;
            dict[currentMaxWeight + curr.DropRateNumerator * (leastCommonDenominator / curr.DropRateDenominator)] = curr;
            return dict;
        });
    }

    private static int GetLeastCommonMultiple(IEnumerable<int> allBossUniques)
    {
        if (allBossUniques.Count() == 1)
        {
            return allBossUniques.First();
        }
        // we do this weird skip 1 and start with the first so that we don't start our seed at 0, since that would screw up the LCM calculation.
        return allBossUniques.Skip(1).Aggregate(allBossUniques.First(), (lcm, curr) => GetLeastCommonMultiple(lcm, curr));
    }

    private static int GetLeastCommonMultiple(int a, int b)
    {
        return (a * b) / (GetGreatestCommonDivisor(a, b));
    }

    private static int GetGreatestCommonDivisor(int a, int b)
    {
        // https://stackoverflow.com/questions/18541832/c-sharp-find-the-greatest-common-divisor
        while (a != 0 && b != 0)
        {
            if (a > b)
                a %= b;
            else
                b %= a;
        }

        return a | b;
    }
}
