using System;

namespace UniqueWords
{
    public static class TextProcessor
    {
        /// <summary>
        /// Returns the list of unique words in the <see cref="words"/> array.
        /// </summary>
        public static List<string> GetUniqueWordsFromArray(string[] words)
        {
            if (words is null)
            {
                throw new ArgumentNullException(nameof(words));
            }

            List<string> result = new List<string>();
            int i = 0;
            while (i < words.Length)
            {
                if (!result.Contains(words[i]))
                {
                    result.Add(words[i]);
                }

                i++;
            }

            return result;
        }

        /// <summary>
        /// Returns the number of unique words in the <see cref="text"/>.
        /// </summary>
        public static int CountUniqueWordsInText(string text)
        {
            List<string> list = new List<string>();

            int position = 0;

            if (text is null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            while (position < text.Length)
            {
                if (string.IsNullOrEmpty(text))
                {
                    return 0;
                }

                int spaceIndex = text.IndexOf(' ', position);
                string word = string.Empty;

                if (spaceIndex == position)
                {
                    position++;
                    continue;
                }
                else if (spaceIndex < 0)
                {
                    spaceIndex = text.Length;
                }

                word = text[position..spaceIndex];

                if (list.IndexOf(word) < 0 && !string.IsNullOrEmpty(word))
                {
                    list.Add(word);
                }
                else
                {
                    position = spaceIndex + 1;
                }
            }

            return list.Count;
        }

        public static List<string> CountUniqueWordsInText2(string text)
        {
            List<string> list = new List<string>();

            int position = 0;

            if (text is null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            while (position < text.Length)
            {
                int spaceIndex = text.IndexOf(' ', position);
                string word = string.Empty;

                if (spaceIndex == position)
                {
                    position++;
                    continue;
                }
                else if (spaceIndex < 0)
                {
                    spaceIndex = text.Length;
                }

                word = text[position..spaceIndex];

                if (list.IndexOf(word) < 0 && !string.IsNullOrEmpty(word))
                {
                    list.Add(word);
                }
                else
                {
                    position = spaceIndex + 1;
                }
            }

            return list;
        }

        /// <summary>
        /// Returns the list of unique words extracted from the <see cref="lines"/>. Words are separated with a space (' ') character.
        /// </summary>
        public static IEnumerable<string> GetUniqueWordsFromEnumerable(IEnumerable<string> lines)
        {
            var list = new List<string>();

            foreach (string line in lines)
            {
                foreach (var i in CountUniqueWordsInText2(line))
                {
                    if (!list.Contains(i))
                    {
                        list.Add(i);
                    }
                }
            }

            return list;
        }

            /// <summary>
            /// Returns the list of unique words extracted from the <see cref="text"/>. Words are separated with the <see cref="separator"/> character.
            /// </summary>
        public static string[][] GetUniqueWordsArray(IEnumerable<string> lines, char separator)
        {
            List<List<string>> answer = new List<List<string>>();
            List<string> allOfEm = new List<string>();
            foreach (var line in lines)
            {
                List<string> insideList = new List<string>();
                foreach (var i in line.Split(separator))
                {
                    string word = i.Replace(" ", string.Empty);
                    if (!allOfEm.Contains(word))
                    {
                        insideList.Add(word);
                        allOfEm.Add(word);
                    }
                }

                answer.Add(insideList);
            }

            string[][] jaggedArray = new string[answer.Count][];
            for (int i = 0; i < answer.Count; i++)
            {
                jaggedArray[i] = answer[i].ToArray();
            }

            return jaggedArray;
        }

        /// <summary>
        /// Returns the list of unique words extracted from the <see cref="text"/>. Words are separated with the <see cref="separator"/> characters.
        /// </summary>
        public static ICollection<string> GetUniqueWordsCollection(string text, char separator)
        {
            var uniqueWords = new List<string>();
            var startIndex = 0;
            var endIndex = 0;

            while (endIndex < text.Length)
            {
                endIndex = text.IndexOf(separator, startIndex);
                if (endIndex == -1)
                {
                    endIndex = text.IndexOf(Environment.NewLine, startIndex);
                    if (endIndex == -1)
                    {
                        endIndex = text.Length;
                    }
                }

                var word = text[startIndex..endIndex].Trim();
                if (!string.IsNullOrEmpty(word) && !uniqueWords.Contains(word))
                {
                    uniqueWords.Add(word);
                }

                startIndex = endIndex + 1;
            }

            return uniqueWords;
        }

        /// <summary>
        /// Returns the number of unique words in the <see cref="text"/>.
        /// </summary>
        public static ICollection<string> GetUniqueWordsInCharCollection(ICollection<char> collection, char separator)
        {
            List<char> wordChars = new List<char>();
            List<string> words = new List<string>();

            foreach (char c in collection)
            {
                if (c == separator)
                {
                    if (wordChars.Count > 0)
                    {
                        string word = new string(wordChars.ToArray());
                        if (!words.Contains(word))
                        {
                            words.Add(word);
                        }

                        wordChars.Clear();
                    }
                }
                else if (c != ' ')
                {
                    wordChars.Add(c);
                }
            }

            if (wordChars.Count > 0)
            {
                string word = new string(wordChars.ToArray());
                if (!words.Contains(word))
                {
                    words.Add(word);
                }
            }

            return words;
        }
    }
}
