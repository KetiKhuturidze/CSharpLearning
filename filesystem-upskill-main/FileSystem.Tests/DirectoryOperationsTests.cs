using NUnit.Framework;

namespace FileSystem.Tests
{
    public class DirectoryOperationsTests
    {
        [TestCase]
        public void DirectoryIsCreatedOrNot_ValidateDirectory()
        {
            // Arrange
            string dirPath = Path.Combine(Path.GetTempPath(), "TestCreateDirectory");

            // Act
            try
            {
                DirectoryOperations.DirectoryIsCreatedOrNotValidateDirectory(dirPath);

                // Assert
                Assert.IsTrue(Directory.Exists(dirPath));
            }
            finally
            {
                if (Directory.Exists(dirPath))
                {
                    Directory.Delete(dirPath, true);
                }
            }
        }

        [TestCase]
        public void DirectoryIsDeletedOrNot_ValidateDirectory()
        {
            // Arrange
            string dirPath = Path.Combine(Path.GetTempPath(), "TestDeleteDirectory");

            // Act
            try
            {
                _ = Directory.CreateDirectory(dirPath);
                DirectoryOperations.DirectoryIsDeletedOrNotValidateDirectory(dirPath);

                // Assert
                Assert.IsTrue(!Directory.Exists(dirPath));
            }
            finally
            {
                if (Directory.Exists(dirPath))
                {
                    Directory.Delete(dirPath, true);
                }
            }
        }

        [TestCase]
        public void DirectoryIsMovedToOtherDirectory_ValidteDirectory()
        {
            string firstDirPath = Path.Combine(Path.GetTempPath(), "FirstDirectory");
            string secondDirPath = Path.Combine(Path.GetTempPath(), "SecondDirectory");
            string destinationPath = Path.Combine(secondDirPath, "FirstDirectory");

            try
            {
                _ = Directory.CreateDirectory(firstDirPath);
                _ = Directory.CreateDirectory(secondDirPath);
                DirectoryOperations.DirectoryIsMovedToOtherDirectoryValidateDirectory(firstDirPath, destinationPath);

                Assert.IsTrue(Directory.Exists(destinationPath));
            }
            finally
            {
                if (Directory.Exists(firstDirPath))
                {
                    Directory.Delete(firstDirPath, true);
                }

                if (Directory.Exists(secondDirPath))
                {
                    Directory.Delete(secondDirPath, true);
                }
            }
        }

        [TestCase]
        public void SubDirectoryIsCreatedOrNot_ValidateSubDirectory()
        {
            // Arrange
            string dirPath = Path.Combine(Path.GetTempPath(), "TestCreateSubDir");
            string subDirPath = Path.Combine(dirPath, "SubDir");

            try
            {
                // Act
                _ = Directory.CreateDirectory(dirPath);
                DirectoryOperations.SubDirectoryIsCreatedOrNotValidateSubDirectory(dirPath, subDirPath);

                // Assert
                Assert.IsTrue(Directory.Exists(subDirPath));
            }
            finally
            {
                Directory.Delete(dirPath, true);
            }
        }

        [TestCase]
        public void DeleteSubDirectory_ValidateSubDirectoryDeletedOrNot()
        {
            // Arrange
            string dirPath = Path.Combine(Path.GetTempPath(), "TestDeleteSubDir");
            string subDirPath = Path.Combine(dirPath, "SubDir");

            try
            {
                // Act
                _ = Directory.CreateDirectory(dirPath);
                DirectoryInfo directoryInfo = new DirectoryInfo(dirPath);
                _ = directoryInfo.CreateSubdirectory("SubDir");
                DirectoryOperations.DeleteSubDirectoryValidateSubDirectoryDeletedOrNot(subDirPath);

                // Assert
                Assert.IsTrue(!Directory.Exists(subDirPath));
            }
            finally
            {
                Directory.Delete(dirPath, true);
            }
        }

        [TestCase]
        public void MoveSubDirectory_ValidateSubDirMovedOrNot()
        {
            string dirPath = Path.Combine(Path.GetTempPath(), "TestMoveSubDir");
            string firstSubDirPath = Path.Combine(dirPath, "firstSubDir");
            string secondSubDirPath = Path.Combine(dirPath, "secondSubDir");
            string destinationPath = Path.Combine(secondSubDirPath, "firstSubDir");

            try
            {
                _ = Directory.CreateDirectory(dirPath);
                DirectoryInfo directoryInfo = new DirectoryInfo(dirPath);
                _ = directoryInfo.CreateSubdirectory("firstSubDir");
                _ = directoryInfo.CreateSubdirectory("secondSubDir");
                DirectoryOperations.MoveSubDirectoryValidateSubDirMovedOrNot(firstSubDirPath, destinationPath);

                Assert.IsTrue(Directory.Exists(destinationPath));
            }
            finally
            {
                Directory.Delete(dirPath, true);
            }
        }
    }
}
