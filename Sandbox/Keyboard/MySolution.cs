using System.Collections.ObjectModel;

namespace Sandbox.Keyboard
{
    public static class MySolution
    {
        /// <summary>
        /// The data the user wanted to enter.
        /// </summary>
        /// <param name="initialString">The data the user wanted to enter.</param>
        /// <param name="length">The size of the final string if we know how many characters will be skipped.</param>
        /// <returns>The data that was printed taking into account keyboard problems.</returns>
        /// <remarks>
        /// If we don’t have a streaming (sequential) data input, it’ll be more efficient to traverse the string from the end.
        /// </remarks>
        public static string GetBrokenKeyboard(string initialString)
        {
            if (string.IsNullOrEmpty(initialString))
                return initialString;

            int skipLowers = 0;
            int skipUppers = 0;

            Span<char> buffer = new char[initialString.Length]; ;

            var bufferIndex = buffer.Length - 1;
            for (var i = initialString.Length - 1; i >= 0; i--)
            {
                var c = initialString[i];

                if ('B'.Equals(c))
                {
                    skipUppers++;
                    continue;
                }

                if ('b'.Equals(c))
                {
                    skipLowers++;
                    continue;
                }

                if (skipLowers > 0 && char.IsLower(c))
                {
                    skipLowers--;
                    continue;
                }
                else if (skipUppers > 0 && char.IsUpper(c))
                {
                    skipUppers--;
                    continue;
                }

                buffer[bufferIndex] = c;
                bufferIndex--;
            }

            return new string(buffer[(bufferIndex + 1)..buffer.Length]);
        }
    }
}
