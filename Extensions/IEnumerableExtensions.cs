using System.Collections.Generic;
using System.Linq;

namespace TinyMatter.Extensions {
    public static class IEnumerableExtensions {
        public static IEnumerable<IGrouping<int, TSource>> GroupBy<TSource>(this IEnumerable<TSource> source, int itemsPerGroup)
        {
            return source.Zip(Enumerable.Range(0, source.Count()),
                        (s, r) => new { Group = r / itemsPerGroup, Item = s })
                    .GroupBy(i => i.Group, g => g.Item)
                    .ToList();
        }

        public static IEnumerable<IGrouping<int, TSource>> GroupBy<TSource>(this IEnumerable<TSource> source, uint itemsPerGroup) {
            return source.GroupBy((int) itemsPerGroup);
        }
    }
}