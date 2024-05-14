using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace UniqueWords
{
    public static class TextProcessor
    {
        /// <summary>
        /// Returns the number of words that are duplicated in the <see cref="text"/>.
        /// </summary>
        /// <param name="text">Source text.</param>
        /// <returns>The number of words that are duplicated in the <see cref="text"/>.</returns>
        public static int CountDuplicateWords(string text)
        {
            List<char> wordChars = new List<char>();
            List<string> words = new List<string>();
            List<int> counters = new List<int>();

            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];
                bool isSpace = c == ' ';

                if (!isSpace)
                {
                    wordChars.Add(c);
                }

                bool isSpaceAfterWord = isSpace && wordChars.Count > 0;
                bool isLastChar = !isSpace && i == text.Length - 1;

                if (isSpaceAfterWord || isLastChar)
                {
                    string word = new string(wordChars.ToArray());
                    int wordIndex = words.IndexOf(word);

                    if (wordIndex < 0)
                    {
                        words.Add(word);
                        counters.Add(1);
                    }
                    else
                    {
                        counters[wordIndex] = counters[wordIndex] + 1;
                    }

                    wordChars.Clear();
                }
            }

            int duplicateCount = 0;

            for (int j = 0; j < words.Count; j++)
            {
                if (counters[j] > 1)
                {
                    duplicateCount++;
                }
            }

            return duplicateCount;
        }

        /// <summary>
        /// Returns the total number of all words that are duplicated in the <see cref="lines"/> list.
        /// </summary>
        /// <param name="lines">Source lines of text.</param>
        /// <returns>The total number of all words that are duplicated in the <see cref="lines"/> list.</returns>
        public static int GetTotalDuplicateWordsNumber(IList<string> lines)
        {
            Dictionary<string, int> counters = new ();

            foreach (string line in lines)
            {
                IList<string> words = line.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

                foreach (string word in words)
                {
                    if (!counters.ContainsKey(word))
                    {
                        counters.Add(word, 1);
                    }
                    else
                    {
                        counters[word.ToString()]++;
                    }
                }
            }

            int sum = 0;
            foreach (int c in counters.Values)
            {
                if (c > 1)
                {
                    sum += c;
                }
            }

            return sum;
        }

        /// <summary>
        /// Returns the list of words that are duplicated in the <see cref="lines"/> collection.
        /// </summary>
        /// <param name="lines">Source lines of text.</param>
        /// <returns>The list of words that are duplicated in the <see cref="lines"/> collection.</returns>
        /// <exception cref="ArgumentNullException"><see cref="lines"/> is null.</exception>
        public static IList<string> GetDuplicateWords(ICollection<string>? lines)
        {
            HashSet<string> words = new ();
            HashSet<string> duplicates = new ();

            if (lines is null)
            {
                throw new ArgumentNullException(nameof(lines));
            }

            foreach (var line in lines)
            {
                int i = 0;

                while (i < line.Length)
                {
                    int spaceIndex = line.IndexOf(' ', i);

                    if (spaceIndex < 0)
                    {
                        spaceIndex = line.Length;
                    }

                    if (spaceIndex - i != 1)
                    {
                        string word = line[i..spaceIndex];

                        if (!words.Contains(word))
                        {
                            words.Add(word);
                        }
                        else if (!duplicates.Contains(word))
                        {
                            duplicates.Add(word);
                        }

                        i = spaceIndex + 1;
                    }
                }
            }

            return duplicates.ToList<string>();
        }

        /// <summary>
        /// Returns the collection of unique words from the <see cref="lines"/> enumerable object.
        /// </summary>
        /// <param name="lines">Source lines of text.</param>
        /// <param name="ignoreCase">If true, indicates that the case of strings should be ignored.</param>
        /// <returns>The collection of unique words from the <see cref="lines"/> enumerable object.</returns>
        /// <exception cref="ArgumentNullException"><see cref="lines"/> is null.</exception>
        public static ICollection<string> GetUniqueWords(IEnumerable<string>? lines, bool ignoreCase)
        {
            if (lines == null)
            {
                throw new ArgumentNullException(nameof(lines));
            }

            HashSet<string> uniqueWords;

            if (ignoreCase)
            {
                uniqueWords = new HashSet<string>(StringComparer.InvariantCultureIgnoreCase);
            }
            else
            {
                uniqueWords = new HashSet<string>(StringComparer.InvariantCulture);
            }

            foreach (string line in lines)
            {
                string[] words = line.Split(
                    new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries);

                foreach (string word in words)
                {
                    if (!uniqueWords.Contains(word))
                    {
                        uniqueWords.Add(word);
                    }
                    else
                    {
                        uniqueWords.Remove(word);
                    }
                }
            }

            return uniqueWords.OrderBy(w => w, StringComparer.InvariantCulture).ToList();
        }

        /// <summary>
        /// Searches a string for duplicates and removes all next occurrences of duplicate words. The first occurrence of a duplicate word should say on it's place.
        /// </summary>
        /// <param name="stringBuilder">The <see cref="StringBuilder"/> that contains a source text.</param>
        /// <exception cref="ArgumentNullException"><see cref="StringBuilder"/> is null.</exception>
        public static void RemoveDuplicateWordsInStringBuilder(StringBuilder? stringBuilder)
        {
            HashSet<string> uniqueWords = new HashSet<string>();

            if (stringBuilder is null)
            {
                throw new ArgumentNullException(nameof(stringBuilder));
            }

            string[] words = stringBuilder.ToString().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int i = words.Length - 1; i >= 0; i--)
            {
                string word = words[i];
                if (uniqueWords.Contains(word))
                {
                    int startIndex = stringBuilder.ToString().LastIndexOf(word);
                    int endIndex = startIndex + word.Length;
                    stringBuilder.Remove(startIndex, endIndex - startIndex);
                }
                else
                {
                    uniqueWords.Add(word);
                }
            }
        }

        /// <summary>
        /// Searches a string for duplicates and removes all next occurrences of duplicate words. The first occurrence of a duplicate word should say on it's place.
        /// </summary>
        /// <param name="text">The source text.</param>
        /// <param name="ignoreCase">If true, indicates that the case of strings should be ignored.</param>
        /// <exception cref="ArgumentNullException"><see cref="text"/> is null.</exception>
        public static void RemoveDuplicateWordsInString(ref string? text, bool ignoreCase)
        {
            if (text is null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            string[] words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            HashSet<string> uniqueWords = new HashSet<string>();
            List<string> dupWords = new List<string>();
            StringComparison stringComparison = StringComparison.InvariantCulture;

            if (ignoreCase)
            {
                stringComparison = StringComparison.InvariantCultureIgnoreCase;
            }
            else
            {
                uniqueWords = new HashSet<string>(StringComparer.InvariantCulture);
            }

            foreach (string word in words)
            {
                if (!uniqueWords.Contains(word))
                {
                    uniqueWords.Add(word);
                }
                else
                {
                    dupWords.Add(word);
                }
            }

            foreach (var v in dupWords)
            {
                int startIndex = text.LastIndexOf(v, stringComparison);
                if (startIndex != text.IndexOf(v, stringComparison))
                {
                    text = text.Remove(startIndex, v.Length);
                }
            }
        }
    }
}
