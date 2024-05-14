using System.Text;
#pragma warning disable

namespace Streams
{
    public static class ReadingFromStream
    {
        public static string ReadAllStreamContent(StreamReader streamReader)
        {
            return streamReader.ReadToEnd().ToString();
        }

        public static string[] ReadLineByLine(StreamReader streamReader)
        {
            List<string> lines = new List<string>();

            string line;
            while ((line = streamReader.ReadLine()) != null)
            {
                lines.Add(line);
            }

            return lines.ToArray();
        }

        public static StringBuilder ReadOnlyLettersAndNumbers(StreamReader streamReader)
        {
            StringBuilder stringBuilder = new StringBuilder();

            while (streamReader.Peek() != -1)
            {
                char ch = (char)streamReader.Peek();

                if (char.IsLetterOrDigit(ch))
                {
                    stringBuilder.Append(ch);
                    streamReader.Read();
                }
                else
                {
                    return stringBuilder;
                }
            }

            return stringBuilder;
        }

        public static char[][] ReadAsCharArrays(StreamReader streamReader, int arraySize)
        {
            string fromStream = streamReader.ReadToEnd();

            int rows = (fromStream.Length / arraySize) + (fromStream.Length % arraySize == 0 ? 0 : 1);

            char[][] chars = new char[rows][];

            for (int i = 0; i < rows; i++)
            {
                int length = i == rows - 1 && fromStream.Length % arraySize != 0 ? fromStream.Length % arraySize : arraySize;

                chars[i] = new char[length];

                for (int j = 0; j < length; j++)
                {
                    char ch = fromStream[(i * arraySize) + j];
                    chars[i][j] = ch;
                }
            }

            return chars;
        }
    }
}
