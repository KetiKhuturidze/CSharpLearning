# FileSystem API

Beginner level task for practicing FileSystem API.

Estimated time to complete the task - 1.5h.

The task requires .NET 6 SDK installed.

## Task Description

Filesystem in .NET is a mechanism that allows to create, copy, moving, deleting, opening  Files and Directories, Read the [Files](https://learn.microsoft.com/en-us/dotnet/api/system.io.file), [Directories](https://learn.microsoft.com/en-us/dotnet/api/system.io.directory) articles before starting the task.

### 1. Files

### 1.1. Create a File in file path.

Implement the [CreatingFileAndReturnFilePath](FileSystem/FileOperations.cs#L9) method, so it could create the file in specified file path. Use the [FileCreate](https://learn.microsoft.com/en-us/dotnet/api/system.io.file.create) method to create file in the specified path.


### 1.2. Create File and appending some text into that file, and verify the text appended in that file path.

Implement the [WriteTextToFileReadAppendedText](FileSystem/FileOperations.cs#L15) method, so it could append some text in specified file path. Use the [FileWriteAllText](https://learn.microsoft.com/en-us/dotnet/api/system.io.file.writealltext) method to write data in the specified file.


### 1.3. Read text from the specified file path.

Implement the [ReadingFileContentAndValidateText](FileSystem/FileOperations.cs#L21) method, so it could read text in specified file path. Use the [ReadAllLines](https://learn.microsoft.com/en-us/dotnet/api/system.io.file.readalllines) method to read data in the specified file.


### 1.4. Move a file from specific path to other path, and verify the file is moved to the new path or not.

Implement the [MoveFileFromOneFolderToNewFolderAndValidateFile](FileSystem/FileOperations.cs#L27) method, so it could read text in specified file path. Use the [FileMove](https://learn.microsoft.com/en-us/dotnet/api/system.io.file.move) method to move the file to new path.


### 1.5. Copy a file which already created from specified path.

Implement the [DeleteFileAndValidateFileExistOrNot](FileSystem/FileOperations.cs#L33) method, so it could copy file in specified file path new path. Use the [FileCopy](https://learn.microsoft.com/en-us/dotnet/api/system.io.file.copy) method to move the file from specified path.


### 1.6. Delete a file which already created from specified path.

Implement the [DeleteFileAndValidateFileExistOrNot](FileSystem/FileOperations.cs#L39) method, so it could delete file in specified file path. Use the [FileDelete](https://learn.microsoft.com/en-us/dotnet/api/system.io.file.delete) method to delete the file from specified path.



#### 2. Directories

#### 2.1. Create Directory in specified path.

Implement the [DirectoryIsCreatedOrNotValidateDirectory](FileSystem/DirectoryOperations.cs#L7) method, so it could create the directory in specified path. Use the [CreateDirectory](https://learn.microsoft.com/en-us/dotnet/api/system.io.directory.createdirectory) method to create directory in the specified path.


#### 2.2. Deleting a directory and validating the directory is removed from the path.

Implement the [DirectoryIsDeletedOrNotValidateDirectory](FileSystem/DirectoryOperations.cs#L13) method, so it could delete the directory in specified path. Use the [DirectoryDelete](https://learn.microsoft.com/en-us/dotnet/api/system.io.directory.delete) method to delete directory in the specified path.


#### 2.3. Move a directory from one location to other directory location.

Implement the [DirectoryIsMovedToOtherDirectoryValidateDirectory](FileSystem/DirectoryOperations.cs#L19) method, so it could delete the directory in specified path. Use the [DirectoryDelete](https://learn.microsoft.com/en-us/dotnet/api/system.io.directory.move) method to move directory from specified path.


#### 2.4. Create a sub directory and verify that directory is created or not.

Implement the [SubDirectoryIsCreatedOrNotValidateSubDirectory](FileSystem/DirectoryOperations.cs#L25) method, so it could create the subdirectory in specified path. Use the [CreateSubdirectory](https://learn.microsoft.com/en-us/dotnet/api/system.io.directoryinfo.createsubdirectory) method to create subdirectory from specified path.


#### 2.5. Delete an existing Directory or create a new Directory and delete from the specified path.

Implement the [DeleteSubDirectoryValidateSubDirectoryDeletedOrNot](FileSystem/DirectoryOperations.cs#L31) method, so it could delete the subdirectory in specified path. Use the [Delete](https://learn.microsoft.com/en-us/dotnet/api/system.io.directory.delete) method to delete subdirectory from specified path.


#### 2.6. Move an existing sub Directory or create a new sub Directory, and move this to other Path.

Implement the [MoveSubDirectoryValidateSubDirMovedOrNot](FileSystem/DirectoryOperations.cs#L37) method, so it could delete the subdirectory in specified path. Use the [DirectoryMove](https://learn.microsoft.com/en-us/dotnet/api/system.io.directory.move) method to move subdirectory to specified path.

##### See also
.NET API
  * [File.Create](https://learn.microsoft.com/en-us/dotnet/api/system.io.file.create)
  * [File.WriteAllLines](https://learn.microsoft.com/en-us/dotnet/api/system.io.file.writealllines)
  * [File.ReadLines](https://learn.microsoft.com/en-us/dotnet/api/system.io.file.readlines)
  * [File.Move](https://learn.microsoft.com/en-us/dotnet/api/system.io.file.move)
  * [Directory.CreateDirectory](https://learn.microsoft.com/en-us/dotnet/api/system.io.directory.createdirectory)
  * [Directory.Move](https://learn.microsoft.com/en-us/dotnet/api/system.io.directory.move)
  * [Directory.Delete](https://learn.microsoft.com/en-us/dotnet/api/system.io.directory.delete)

