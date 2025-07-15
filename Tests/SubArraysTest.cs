using Sandbox.SubArrays;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class SubArraysTest
    {
        [Theory, MemberData(nameof(Data))]
        public void DenisNPTest(int e, int[] a)
        {
            Assert.Equal(e, DenisNP.GetMaxSum(a));
        }

        [Theory, MemberData(nameof(Data))]
        public void Test(int e, int[] a)
        {
            Assert.Equal(e, DimsFromDergachy.GetMaxSum(a));
        }

        [Theory, MemberData(nameof(Data))]
        public void MySolutionTest(int e, int[] a)
        {
            Assert.Equal(e, MySolution.GetMaxSum(a));
        }


        public static IEnumerable<object[]> Data =>
        [
            [ 4,new int[] {1, 1, 1, 1 }],
            [ 7,new int[] { 1, 2, 3, 4 }],
            [ 7,new int[] { 1, 2, 2, 1, 1, 3, 1, 1 }],
            [ 8,new int[] { 1, 2, 2, 1, 1, 3, 3 }],
            [ 9,new int[] { 1, 2, 2, 1, 1, 1, 3, 6 }],
            [ 8,new int[] { 1, 2, 2, 1, 1, 1, 3, 2 }],
        ];
    }
}
