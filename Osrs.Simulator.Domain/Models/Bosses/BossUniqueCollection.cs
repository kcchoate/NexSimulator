using Osrs.Simulator.Domain.Models.Uniques;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osrs.Simulator.Domain.Models.Bosses
{
    internal class BossUniqueCollection<T> where T : Boss
    {
        Dictionary<decimal, BossUnique<T>> _bossUniques { get; }

        public BossUniqueCollection(IEnumerable<BossUnique<T>> allBossUniques)
        {
            _bossUniques = CalculateBossUniqueLookupTable(allBossUniques);
        }

        private Dictionary<decimal, BossUnique<T>> CalculateBossUniqueLookupTable(IEnumerable<BossUnique<T>> allBossUniques)
        {
            allBossUniques = allBossUniques ?? throw new ArgumentNullException(nameof(allBossUniques));
            if (!allBossUniques.Any())
            {
                throw new ArgumentException("At least one element must exist in the collection.", nameof(allBossUniques));
            }
            if (allBossUniques.Sum(x => x.DropRate) != 1)
            {
                throw new ArgumentException("The sum of the DropRates of the items in the collection must equal 1.", nameof(allBossUniques));
            }

            var totalWeight = allBossUniques.Sum(x => x.DropRate);
            return allBossUniques.Aggregate(new Dictionary<decimal, BossUnique<T>>(), (dict, curr) => {
                var currentMaxWeight = dict.Keys.Any() ? dict.Keys.Max() : 0;
                dict[currentMaxWeight + curr.DropRate] = curr;
                return dict;
            });
        }

        public BossUnique<T> GetRandomUnique(decimal randomValue)
        {
            var targetKey = _bossUniques.Where(x => x.Key < randomValue).Max().Key;
            return _bossUniques[targetKey];
        }
    }
}
