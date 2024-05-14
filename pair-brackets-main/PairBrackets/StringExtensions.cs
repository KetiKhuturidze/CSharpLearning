namespace PairBrackets
{
    public static class StringExtensions
    {
        /// <summary>
        /// Returns the number of bracket pairs in the <see cref="text"/>.
        /// </summary>
        /// <param name="text">The source text.</param>
        /// <returns>The number of bracket pairs in the <see cref="text"/>.</returns>
        public static int CountBracketPairs(this string text)
        {
            Dictionary<char, char> bracketPairs = new Dictionary<char, char>()
            {
                { '[', ']' },
                { '(', ')' },
            };
            Stack<char> bracketStack = new Stack<char>();
            int pairCount = 0;

            foreach (char c in text)
            {
                if (c == '(' || c == '[')
                {
                    bracketStack.Push(c);
                }
                else if ((c == ')' || c == ']') && bracketStack.Count > 0 && bracketPairs.TryGetValue(bracketStack.Peek(), out char openingBracket) && openingBracket == c)
                {
                    bracketStack.Pop();
                    pairCount++;
                }
            }

            return pairCount;
        }

        /// <summary>
        /// Searches the <see cref="text"/> and returns the list of start and end positions of bracket pairs.
        /// </summary>
        /// <param name="text">The source text.</param>
        /// <returns>The list of start and end positions of bracket pairs.</returns>
        /// <exception cref="ArgumentNullException"><see cref="text"/> is null.</exception>
        public static IList<(int, int)> GetBracketPairPositions(this string? text)
        {
            if (text is null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            List<(int, int)> bracketPairPositions = new List<(int, int)>();

            Dictionary<char, char> bracketPairs = new Dictionary<char, char>()
            {
                { '{', '}' },
                { '[', ']' },
                { '(', ')' },
            };
            Stack<int> bracketStack = new Stack<int>();

            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];

                if (c == '(' || c == '[' || c == '{')
                {
                    bracketStack.Push(i);
                }
                else if ((c == ')' || c == ']' || c == '}') && bracketStack.Count > 0 && bracketPairs.TryGetValue(text[bracketStack.Peek()], out char openingBracket) && openingBracket == c)
                {
                    bracketPairPositions.Add((bracketStack.Pop(), i));
                }
            }

            return bracketPairPositions.OrderBy(p => p.Item1).ToList();
        }

        /// <summary>
        /// Examines the <see cref="text"/> and returns true if the pairs and the orders of brackets are balanced; otherwise returns false.
        /// </summary>
        /// <param name="text">The source text.</param>
        /// <param name="bracketTypes">The bracket type option.</param>
        /// <returns>True if the pairs and the orders of brackets are balanced; otherwise returns false.</returns>
        /// <exception cref="ArgumentNullException"><see cref="text"/> is null.</exception>
        public static bool ValidateBrackets(this string? text, BracketTypes bracketTypes)
        {
            if (text is null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            Stack<char> bracketStack = new Stack<char>();

            Dictionary<char, char> bracketPairs = new ();

            switch (bracketTypes)
            {
                case BracketTypes.All:
                    bracketPairs = new Dictionary<char, char>()
                    {
                        { '(', ')' },
                        { '[', ']' },
                        { '{', '}' },
                        { '<', '>' },
                    };

                    break;
                case BracketTypes.RoundBrackets:
                    bracketPairs = new Dictionary<char, char>()
                    {
                        { '(', ')' },
                    };

                    break;
                case BracketTypes.SquareBrackets:
                    bracketPairs = new Dictionary<char, char>()
                    {
                        { '[', ']' },
                    };

                    break;
                case BracketTypes.CurlyBrackets:
                    bracketPairs = new Dictionary<char, char>()
                    {
                        { '{', '}' },
                    };

                    break;
                case BracketTypes.AngleBrackets:
                    bracketPairs = new Dictionary<char, char>()
                    {
                        { '<', '>' },
                    };

                    break;
                default:
                    break;
            }

            foreach (char c in text)
            {
                if (bracketPairs.ContainsKey(c))
                {
                    bracketStack.Push(c);
                }
                else if (bracketPairs.ContainsValue(c) && (bracketStack.Count == 0 || bracketPairs[bracketStack.Pop()] != c))
                {
                    return false;
                }
            }

            return bracketStack.Count == 0;
        }
    }

    [Flags]
    public enum BracketTypes
        {
            All = 0,
            RoundBrackets = 1,
            SquareBrackets = 2,
            CurlyBrackets = 3,
            AngleBrackets = 4,
        }
}