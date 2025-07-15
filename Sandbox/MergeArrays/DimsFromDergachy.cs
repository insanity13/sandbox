namespace Sandbox.MergeArrays
{
    public static class DimsFromDergachy
    {
        public static IEnumerable<int> Merge(int[] a, int[] b)
        {
            for ((int i, int j) = (0, 0); i < a.Length || j < b.Length;)
            {
                if (i == a.Length)
                {
                    yield return b[j++]; continue;
                }

                if (j == b.Length)
                {
                    yield return a[i++]; continue;
                }

                if (a[i] < b[j])
                {
                    yield return a[i++]; continue;
                }
                if (b[j] < a[i])
                {
                    yield return b[j++]; continue;
                }

                yield return a[i];
                i++;
                j++;
            }
        }
    }
}
