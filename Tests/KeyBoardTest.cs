using Sandbox.Keyboard;

namespace Tests
{
    public class KeyBoardTest
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void DimsFromDergachy_UnEscape(string a, string e)
        {
            Assert.Equal(e, DimsFromDergachy.UnEscapeString(a));
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Kreator22_1_UnEscape(string a, string e)
        {
            Assert.Equal(e, Kreator22.Print1(a));
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Kreator22_2_UnEscape(string a, string e)
        {
            Assert.Equal(e, Kreator22.Print2(a));
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void MySolution_Version(string a, string e)
        {
            Assert.Equal(e, MySolution.GetBrokenKeyboard(a));
        }

        /// <summary>
        /// Testing Dataset.
        /// </summary>
        /// <remarks>IMHO, any symbols should be here, but other solutions only work with letters.</remarks>
        public static IEnumerable<object[]> Data =>
        [
            ["abcd", "cd"],
            ["ABCD", "CD"],
            ["abba", "a"],
            ["ABBA", "A"],
            ["aAbB", ""],
            ["xXyYzZbB", "xXyY"],
            ["xXyYBbzZ", "xXzZ"],
            ["abcdefgijklmnopqrstuvwxyz", "cdefgijklmnopqrstuvwxyz"],
            ["ABCDEFGIJKLMNOPQRSTUVWXYZ", "CDEFGIJKLMNOPQRSTUVWXYZ"],
            ["BBBBBBBBBBBbbbbbbbbbbbb", ""]
        ];
    }
}
