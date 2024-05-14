using System.IO;

[assembly: CLSCompliant(false)]

namespace FileSystem
{
    public static class FileOperations
    {
        public static void CreatingFileAndReturnFilePath(string filePath)
        {
            File.Create(filePath);
        }

        public static void WriteTextToFileReadAppendedText(string filePath, string msgToWrite)
        {
            File.WriteAllText(filePath, msgToWrite);
        }

        public static string ReadingFileContentAndValidateText(string filePath)
        {
            return string.Join(" ", File.ReadAllLines(filePath));
        }

        public static void MoveFileFromOneFolderToNewFolderAndValidateFile(string filePath, string destinationPath)
        {
            if (File.Exists(filePath))
            {
                File.Move(filePath, destinationPath);
            }

            File.Exists(destinationPath);
        }

        public static void CopyFileFromOneFolderToNewFolder(string filePath, string destinationPath)
        {
            File.Copy(filePath, destinationPath);
        }

        public static void DeleteFileAndValidateFileExistOrNot(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}
