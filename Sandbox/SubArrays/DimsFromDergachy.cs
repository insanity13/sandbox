using Triple = ((int a, int c) p1, (int a, int c) p2, (int a, int c) p3);

namespace Sandbox.SubArrays
{
    public static class DimsFromDergachy
    {

        public static int GetMaxSum(int[] xs)
        {
            Triple start = ((0, 0), (0, 0), (0, 0));
            return xs.Scan(start, Next)
                     .Max(t => t.p1.a * t.p1.c + t.p2.a * t.p2.c);
        }

        private static Triple Next(Triple prev, int x)
        {
            (var p1, var p2, var p3) = prev;
            if (p1.a == x)
                return (p2, p1.Increment(), x.Single());

            if (p2.a == x)
                return (p1, p2.Increment(), p3.Increment());

            return (p3, x.Single(), x.Single());
        }

        private static (int a, int c) Single(this int x) => (x, 1);
        private static (int a, int c) Increment(this (int a, int c) p) => (p.a, p.c + 1);

        // Scan [1,2,3,4,5] 0 (+) => [0,1,3,6,10,15]
        internal static IEnumerable<TAccumulate> Scan<TSource, TAccumulate>(
            this IEnumerable<TSource> source,
            TAccumulate seed,
            Func<TAccumulate, TSource, TAccumulate> func)
        {
            yield return seed;
            foreach (var item in source)
            {
                seed = func(seed, item);
                yield return seed;
            }
        }
    }
}
