namespace Sandbox.Keyboard
{
    /// <summary>
    /// Kreator22 Version.
    /// </summary>
    /// <see cref="https://github.com/Kreator22/st.OtherTasks/blob/master/BrokenKeyboard/BrokenKeyboard/Printer.cs#L14"/>
    public static class Kreator22
    {
        /// <summary>
        /// Сложность по времени - в худшем случае О(n^2) 
        /// (для каждого символа придётся проверить все остальные до начала строки),
        /// в лучшем случае O(n)
        /// (для каждой b или B символ для удаления - предыдущий)
        /// Сложность по памяти - O(n)
        /// </summary>
        public static string Print1(string input)
        {
            if (string.IsNullOrEmpty(input))
                return "";

            char[] chars = input.ToArray();

            for ((int i, int j) = (0, 0); i < chars.Length; i++)
            {
                if (chars[i] == 'b')
                {
                    j = i;
                    while (j > 0 && (char.IsUpper(chars[--j]) || chars[j] == ' ')) ;
                    chars[j] = ' ';
                    chars[i] = ' ';
                    continue;
                }

                if (chars[i] == 'B')
                {
                    j = i;
                    while (j > 0 && (char.IsLower(chars[--j]) || chars[j] == ' ')) ;
                    chars[j] = ' ';
                    chars[i] = ' ';
                    continue;
                }
            }

            return new string(chars.Where(c => c != ' ').ToArray());
        }

        /// <summary>
        /// Сложность по времени - O(n)
        /// Сложность по памяти - O(n)
        /// </summary>
        public static string Print2(string input)
        {
            if (string.IsNullOrEmpty(input))
                return "";

            Stack<int> lowPos = new();
            Stack<int> upPos = new();

            char[] chars = input.ToArray();

            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] == 'b')
                {
                    if (lowPos.Count > 0)
                        chars[lowPos.Pop()] = ' ';
                    chars[i] = ' ';
                    continue;
                }

                if (chars[i] == 'B')
                {
                    if (upPos.Count > 0)
                        chars[upPos.Pop()] = ' ';
                    chars[i] = ' ';
                    continue;
                }

                else if (char.IsLower(chars[i]))
                    lowPos.Push(i);
                else
                    upPos.Push(i);
            }

            return new string(chars.Where(c => c != ' ').ToArray());
        }
    }
}
