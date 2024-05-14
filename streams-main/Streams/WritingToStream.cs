using System.Text;
#pragma warning disable

namespace Streams
{
    public static class WritingToStream
    {
        public static void ReadAndWriteIntegers(StreamReader streamReader, StreamWriter outputWriter)
        {
            while (streamReader.Peek() != -1)
            {
                outputWriter.Write(streamReader.Read());
            }
        }

        public static void ReadAndWriteChars(StreamReader streamReader, StreamWriter outputWriter)
        {
            int c;
            while ((c = streamReader.Read()) != -1)
            {
                char character = (char)c;
                outputWriter.Write(character);
            }

            outputWriter.Flush();
        }

        public static void TransformBytesToHex(StreamReader contentReader, StreamWriter outputWriter)
        {
            int next;
            while ((next = contentReader.Read()) != -1)
            {
                string hex = next.ToString("X2");
                outputWriter.Write(hex);
            }
        }

        public static void WriteLinesWithNumbers(StreamReader contentReader, StreamWriter outputWriter)
        {
            int lineCounter = 1;

            while (!contentReader.EndOfStream)
            {
                string line = contentReader.ReadLine();

                if (line != null)
                {
                    outputWriter.Write($"{lineCounter:D3} {line}\n");
                    lineCounter++;

                    outputWriter.Flush();
                }
            }
        }

        public static void RemoveWordsFromContentAndWrite(StreamReader contentReader, StreamReader wordsReader, StreamWriter outputWriter)
        {
            StringBuilder content = new StringBuilder(contentReader.ReadToEnd());

            while (wordsReader.Peek() >= 0)
            {
                string wordToRemove = wordsReader.ReadLine();
                content.Replace(wordToRemove, string.Empty);
            }

            outputWriter.Write(content.ToString());
        }
    }
}
