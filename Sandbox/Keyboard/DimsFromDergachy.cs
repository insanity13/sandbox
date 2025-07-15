namespace Sandbox.Keyboard
{
    public static class DimsFromDergachy
    {
        /// <summary>
        /// DimsFromDergachy Version
        /// </summary>
        ///<see cref="https://gist.github.com/DimsFromDergachy/28e501cb57557eaf070a67eac22e5e8f"/>
        public static IEnumerable<char> UnEscape(string a)
        {
            // Stacks keep good indexes
            var lowers = new Stack<(int, char chr)>(a.Count());
            var uppers = new Stack<(int, char chr)>(a.Count());

            for (int i = 0; i < a.Count(); i++)
            {
                var ch = a[i];
                switch (ch)
                {
                    case 'b':
                        lowers.TryPop(out _); break;
                    case 'B':
                        uppers.TryPop(out _); break;
                    case var o when char.IsLower(o):
                        lowers.Push((i, ch)); break;
                    case var o when char.IsUpper(o):
                        uppers.Push((i, ch)); break;
                    default:
                        throw new NotSupportedException($"Unsupported character: '{ch}'");
                }
            }

            var result = new Stack<char>(a.Length);

            while (lowers.Any() || uppers.Any())
            {
                if (!lowers.Any())
                {
                    result.Push(uppers.Pop().chr); continue;
                }
                if (!uppers.Any())
                {
                    result.Push(lowers.Pop().chr); continue;
                }

                (int i1, _) = lowers.Peek();
                (int i2, _) = uppers.Peek();

                if (i1 > i2)
                {
                    result.Push(lowers.Pop().chr); continue;
                }
                if (i1 < i2)
                {
                    result.Push(uppers.Pop().chr); continue;
                }

                throw new NotSupportedException("Broken invariant");
            }

            return result.ToArray();
        }

        public static string UnEscapeString(string a) => new string(UnEscape(a).ToArray());
    }
}
