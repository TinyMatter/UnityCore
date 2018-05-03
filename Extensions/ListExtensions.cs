using System.Collections.Generic;

namespace TinyMatter.Extensions {
    public static class ListExtensions {
        private static System.Random rng = new System.Random();
        
        public static void Shuffle<T>(this List<T> list) {
            for (var n = list.Count - 1; n > 0; --n) {
                var k = rng.Next(n + 1);
                var temp = list[n];
                list[n] = list[k];
                list[k] = temp;
            }
        }
        
        public static List<T> Shuffled<T>(this List<T> list) {
            var result = new List<T>(list);

            result.Shuffle();

            return result;
        }
        
        public static List<T> Shuffled<T>(this T[] list) {
            var result = new List<T>(list);

            result.Shuffle();

            return result;
        }
    }
}