namespace Sandbox.MergeArrays
{
    public static class MySolution
    {
        public static IEnumerable<int> Union(int[] m1, int[] m2)
        {
            var i = 0;
            var j = 0;

            while (true)
            {
                if (i < m1.Length && (j >= m2.Length || m1[i] <= m2[j]))
                {
                    yield return m1[i];

                    if (j < m2.Length && m1[i] == m2[j])
                        j++;

                    i++;
                }
                else if (j < m2.Length)
                {
                    yield return m2[j];
                    j++;
                }
                else
                    break;
            }
        }
    }
}
