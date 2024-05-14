using NUnit.Framework;

[assembly: CLSCompliant(false)]

namespace FileSystem.Tests
{
    [TestFixture]
    public class FileOperationsTests
    {
        [TestCase]
        public void FileShouldBeCreated_ValidateFilePath()
        {
            // Arrange
            string dirPath = Path.Combine(Path.GetTempPath(), "TestFileCreate");
            string fileName = "testFileCreate.txt";
            string filePath = Path.Combine(dirPath, fileName);

            // Act
            try
            {
                _ = Directory.CreateDirectory(dirPath);
                FileOperations.CreatingFileAndReturnFilePath(filePath);

                // Assert
                Assert.IsTrue(File.Exists(filePath));
            }
            finally
            {
                Directory.Delete(dirPath, true);
            }
        }

        [TestCase]
        public void FileShouldBeAppendedWithText_ValidateAppendedText()
        {
            // Arrange
            string actualMsg = "If you can see this message then this is working";
            string dirPath = Path.Combine(Path.GetTempPath(), "TestFileWrite");
            string fileName = "testFileWrite.txt";
            string filePath = Path.Combine(dirPath, fileName);
            string expectedMsg = string.Empty;

            // Act
            try
            {
                _ = Directory.CreateDirectory(dirPath);
                var fileStream = File.Create(filePath);
                fileStream.Close();
                FileOperations.WriteTextToFileReadAppendedText(filePath, actualMsg);

                foreach (string line in File.ReadAllLines(filePath))
                {
                    expectedMsg = line;
                }

                // Assert
                Assert.AreEqual(actualMsg, expectedMsg);
            }
            finally
            {
                Directory.Delete(dirPath, true);
            }
        }

        [TestCase]
        public void ReadingFileText_ValidateText()
        {
            string dirPath = Path.Combine(Path.GetTempPath(), "TestFileRead");
            string fileName = "testFileRead.txt";
            string filePath = Path.Combine(dirPath, fileName);
            string result;
            string expected = "If you can see this message then this is working";
            try
            {
                _ = Directory.CreateDirectory(dirPath);
                var fileStream = File.Create(filePath);
                fileStream.Close();
                File.WriteAllText(filePath, expected);
                result = FileOperations.ReadingFileContentAndValidateText(filePath);

                // Assert
                Assert.AreEqual(expected, result);
            }
            finally
            {
                Directory.Delete(dirPath, true);
            }
        }

        [TestCase]
        public void MoveFileFromDirectoryToNewDirectoryAndValidateFile()
        {
            // Arrange
            string dirPath = Path.Combine(Path.GetTempPath(), "TestFileMove");
            string fileName = "testFileMove.txt";
            string filePath = Path.Combine(dirPath, fileName);
            string subDirPath = Path.Combine(dirPath, "SubFolder");
            string destinationPath = Path.Combine(subDirPath, fileName);

            // Act
            try
            {
                _ = Directory.CreateDirectory(dirPath);
                DirectoryInfo directoryInfo = new DirectoryInfo(dirPath);
                _ = directoryInfo.CreateSubdirectory("SubFolder");
                var fileStream = File.Create(filePath);
                fileStream.Close();
                FileOperations.MoveFileFromOneFolderToNewFolderAndValidateFile(filePath, destinationPath);

                // Assert
                Assert.IsTrue(File.Exists(destinationPath));
            }
            finally
            {
                Directory.Delete(dirPath, true);
            }
        }

        [TestCase]
        public void CopyFileFromDirectoryToNewDirectoryAndValidateFile()
        {
            // Arrange
            string dirPath = Path.Combine(Path.GetTempPath(), "TestFileCopy");
            string fileName = "testFileCopy.txt";
            string filePath = Path.Combine(dirPath, fileName);
            string subDirPath = Path.Combine(dirPath, "SubFolder");
            string destinationPath = Path.Combine(subDirPath, fileName);

            // Act
            try
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(dirPath);
                _ = directoryInfo.CreateSubdirectory("SubFolder");
                var fileStream = File.Create(filePath);
                fileStream.Close();
                FileOperations.CopyFileFromOneFolderToNewFolder(filePath, destinationPath);

                // Assert
                Assert.IsTrue(File.Exists(destinationPath));
            }
            finally
            {
                Directory.Delete(dirPath, true);
            }
        }

        [TestCase]
        public void DeleteFileAnd_ValidateFileExistOrNot()
        {
            string dirPath = Path.Combine(Path.GetTempPath(), "TestFileDelete");
            string fileName = "testFileDelete.txt";
            string filePath = Path.Combine(dirPath, fileName);

            try
            {
                _ = Directory.CreateDirectory(dirPath);
                var fileStream = File.Create(filePath);
                fileStream.Close();
                FileOperations.DeleteFileAndValidateFileExistOrNot(filePath);
                Assert.IsTrue(!File.Exists(filePath));
            }
            finally
            {
                Directory.Delete(dirPath, true);
            }
        }
    }
}
