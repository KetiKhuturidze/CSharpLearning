#pragma warning disable

namespace Streams
{
    public static class ReadingFromString
    {
        public static string ReadAllStreamContent(StringReader stringReader)
        {
            return stringReader.ReadToEnd();
        }

        public static string ReadCurrentLine(StringReader stringReader)
        {
            return stringReader.ReadLine();
        }

        public static bool ReadNextCharacter(StringReader stringReader, out char currentChar)
        {
            int nextCharInt = stringReader.Read();

            if (nextCharInt >= 0)
            {
                currentChar = Convert.ToChar(nextCharInt);
                return true;
            }
            else
            {
                currentChar = ' ';
                return false;
            }
        }

        public static bool PeekNextCharacter(StringReader stringReader, out char currentChar)
        {
            int nextCharInt = stringReader.Peek();

            if (nextCharInt >= 0)
            {
                currentChar = Convert.ToChar(nextCharInt);
                return true;
            }
            else
            {
                currentChar = ' ';
                return false;
            }
        }

        public static char[] ReadCharactersToBuffer(StringReader stringReader, int count)
        {
            char[] buffer = new char[count];

            stringReader.ReadBlock(buffer, 0, count);

            return buffer;
        }
    }
}
