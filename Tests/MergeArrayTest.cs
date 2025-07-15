using Sandbox.MergeArrays;

namespace Tests
{
    public class MergeArrayTest
    {
        [Theory, MemberData(nameof(Data))]
        public void DimsFromDergachy_Merge(int[] a, int[] b, int[] e)
        {
            Assert.Equal<int[]>(e, [.. DimsFromDergachy.Merge(a, b)]);
            Assert.Equal<int[]>(e, [.. DimsFromDergachy.Merge(b, a)]);
        }

        [Theory, MemberData(nameof(Data))]
        public void Kreator22_Merge(int[] a, int[] b, int[] e)
        {
            Assert.Equal<int[]>(e, [.. Kreator22.Merge(a, b)]);
            Assert.Equal<int[]>(e, [.. Kreator22.Merge(b, a)]);
        }

        [Theory, MemberData(nameof(Data))]
        public void MySolution_Merge(int[] a, int[] b, int[] e)
        {
            Assert.Equal<int[]>(e, [.. MySolution.Union(a, b)]);
            Assert.Equal<int[]>(e, [.. MySolution.Union(b, a)]);
        }

        public static IEnumerable<object[]> Data =>
        [
            [
                new int[] { },
                new int[] { },
                new int[] { }],
            [
                new int[] { },
                new int[] { 1, 2, 3},
                new int[] { 1, 2, 3}],
            [
                new int[] { 1, 2, 3},
                new int[] { 1, 2, 3},
                new int[] { 1, 2, 3}],
            [
                new int[] { 1, 3, 5},
                new int[] { 2, 4, 6},
                new int[] { 1, 2, 3, 4, 5, 6}],
            [
                new int[] { 1, 2, 3, 4},
                new int[] { 3, 4, 5, 6},
                new int[] { 1, 2, 3, 4, 5, 6}],
            [
                new int[] { 1, 5, 6, 9},
                new int[] { 1, 4, 7, 9},
                new int[] { 1, 4, 5, 6, 7, 9}],
        ];
    }
}
