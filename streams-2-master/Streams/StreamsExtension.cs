using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Security.Cryptography;
using System.Text;
#pragma warning disable

namespace Streams
{
    /// <summary>
    /// Class for training streams and operations with it.
    /// </summary>
    public static class StreamsExtension
    {
        /// <summary>
        /// Implements the logic of byte copying the contents of the source text file using class FileStream as a backing store stream.
        /// </summary>
        /// <param name="sourcePath">Path to source file.</param>
        /// <param name="destinationPath">Path to destination file.</param>
        /// <returns>The number of recorded bytes.</returns>
        /// <exception cref="ArgumentException">Throw if path to source file or path to destination file is null or empty.</exception>
        /// <exception cref="FileNotFoundException">Throw if source file doesn't exist.</exception>
        public static int ByteCopyWithFileStream(string? sourcePath, string? destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            if (string.IsNullOrEmpty(sourcePath))
            {
                throw new ArgumentException(null, nameof(sourcePath));
            }

            if (!File.Exists(sourcePath))
            {
                throw new FileNotFoundException(null, nameof(sourcePath));
            }

            int bytesCopied = 0;

            using (FileStream source = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
            {
                using (FileStream destination = new FileStream(destinationPath, FileMode.Open, FileAccess.Write))
                {
                    byte[] buffer = new byte[4096];
                    int bytesRead;

                    while ((bytesRead = source.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        destination.Write(buffer, 0, bytesRead);
                        bytesCopied += bytesRead;
                    }
                }
            }

            return bytesCopied;
        }

        /// <summary>
        /// Implements the logic of byte copying the contents of the source text file using MemoryStream.
        /// </summary>
        /// <param name="sourcePath">Path to source file.</param>
        /// <param name="destinationPath">Path to destination file.</param>
        /// <returns>The number of recorded bytes.</returns>
        /// <exception cref="ArgumentException">Throw if path to source file or path to destination file is null or empty.</exception>
        /// <exception cref="FileNotFoundException">Throw if source file doesn't exist.</exception>
        public static int ByteCopyWithMemoryStream(string? sourcePath, string? destinationPath)
        {
            InputValidation(sourcePath, destinationPath);
            string stringFromFile;
            int bytesCopied = 0;

            // TODO: step 1. Use StreamReader to read entire file in string\
            using (FileStream sourceStream = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
            {
                StreamReader streamReader = new StreamReader(sourceStream, Encoding.UTF8);
                stringFromFile = streamReader.ReadToEnd();
            }

            // TODO: step 2. Create byte array on base string content - use  System.Text.Encoding class
            byte[] byteArray = System.Text.Encoding.Default.GetBytes(stringFromFile);

            // TODO: step 3. Use MemoryStream instance to read from byte array (from step 2)
            using (MemoryStream memoryStream = new MemoryStream(byteArray))
            {
                // TODO: step 4. Use MemoryStream to write its content to a new byte array
                byte[] newByteArray = memoryStream.ToArray();

                // TODO: step 5. Use Encoding class instance (from step 2) to create a char array from the byte array content
                char[] charArray = Encoding.UTF8.GetChars(newByteArray);

                // TODO: step 6. Use StreamWriter to write the char array content to a new file
                using (StreamWriter streamWriter = new StreamWriter(destinationPath))
                {
                    streamWriter.Write(charArray);
                }

                bytesCopied = charArray.Length;
            }

            return bytesCopied;
        }

        /// <summary>
        /// Implements the logic of block copying the contents of the source text file using FileStream buffer.
        /// </summary>
        /// <param name="sourcePath">Path to source file.</param>
        /// <param name="destinationPath">Path to destination file.</param>
        /// <returns>The number of recorded bytes.</returns>
        /// <exception cref="ArgumentException">Throw if path to source file or path to destination file is null or empty.</exception>
        /// <exception cref="FileNotFoundException">Throw if source file doesn't exist.</exception>
        public static int BlockCopyWithFileStream(string? sourcePath, string? destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            using (FileStream sourceStream = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
            {
                using (FileStream destinationStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write))
                {
                    byte[] buffer = new byte[4096]; // You can adjust the buffer size as needed
                    int bytesRead;
                    int totalBytesCopied = 0;

                    while ((bytesRead = sourceStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        destinationStream.Write(buffer, 0, bytesRead);
                        totalBytesCopied += bytesRead;
                    }

                    return totalBytesCopied;
                }
            }
        }

        /// <summary>
        /// Implements the logic of block copying the contents of the source text file using MemoryStream.
        /// </summary>
        /// <param name="sourcePath">Path to source file.</param>
        /// <param name="destinationPath">Path to destination file.</param>
        /// <returns>The number of recorded bytes.</returns>
        /// <exception cref="ArgumentException">Throw if path to source file or path to destination file is null or empty.</exception>
        /// <exception cref="FileNotFoundException">Throw if source file doesn't exist.</exception>
        public static int BlockCopyWithMemoryStream(string? sourcePath, string? destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            using (FileStream sourceStream = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
            using (MemoryStream memoryStream = new MemoryStream())
            {
                byte[] buffer = new byte[4096]; // You can adjust the buffer size as needed

                int bytesRead;
                int totalBytesCopied = 0;

                while ((bytesRead = sourceStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    memoryStream.Write(buffer, 0, bytesRead);
                    totalBytesCopied += bytesRead;
                }

                File.WriteAllBytes(destinationPath, memoryStream.ToArray());

                return totalBytesCopied;
            }
        }

        /// <summary>
        /// Implements the logic of block copying the contents of the source text file using FileStream and class-decorator BufferedStream.
        /// </summary>
        /// <param name="sourcePath">Path to source file.</param>
        /// <param name="destinationPath">Path to destination file.</param>
        /// <returns>The number of recorded bytes.</returns>
        /// <exception cref="ArgumentException">Throw if path to source file or path to destination file is null or empty.</exception>
        /// <exception cref="FileNotFoundException">Throw if source file doesn't exist.</exception>
        public static int BlockCopyWithBufferedStreamForFileStream(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            using (FileStream sourceStream = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
            using (BufferedStream bufferedStream = new BufferedStream(sourceStream))
            using (FileStream destinationStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write))
            {
                byte[] buffer = new byte[4096]; // You can adjust the buffer size as needed

                int bytesRead;
                int totalBytesCopied = 0;

                while ((bytesRead = bufferedStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    destinationStream.Write(buffer, 0, bytesRead);
                    totalBytesCopied += bytesRead;
                }

                return totalBytesCopied;
            }
        }

        /// <summary>
        /// Implements the logic of block copying the contents of the source text file using MemoryStream and class-decorator BufferedStream.
        /// </summary>
        /// <param name="sourcePath">Path to source file.</param>
        /// <param name="destinationPath">Path to destination file.</param>
        /// <returns>The number of recorded bytes.</returns>
        /// <exception cref="ArgumentException">Throw if path to source file or path to destination file is null or empty.</exception>
        /// <exception cref="FileNotFoundException">Throw if source file doesn't exist.</exception>
        public static int BlockCopyWithBufferedStreamForMemoryStream(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);
            InputValidation(sourcePath, destinationPath);

            using (FileStream sourceStream = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
            using (BufferedStream bufferedStream = new BufferedStream(sourceStream))
            using (FileStream destinationStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write))
            {
                byte[] buffer = new byte[4096]; // You can adjust the buffer size as needed

                int bytesRead;
                int totalBytesCopied = 0;

                while ((bytesRead = bufferedStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    destinationStream.Write(buffer, 0, bytesRead);
                    totalBytesCopied += bytesRead;
                }

                return totalBytesCopied;
            }
        }

        /// <summary>
        /// Implements the logic of line-by-line copying of the contents of the source text file
        /// using FileStream and classes-adapters  StreamReader/StreamWriter
        /// </summary>
        /// <param name="sourcePath">Path to source file.</param>
        /// <param name="destinationPath">Path to destination file.</param>
        /// <returns>The number of recorded lines.</returns>
        /// <exception cref="ArgumentException">Throw if path to source file or path to destination file are null or empty.</exception>
        /// <exception cref="FileNotFoundException">Throw if source file doesn't exist.</exception>
        public static int LineCopy(string? sourcePath, string? destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            using (FileStream sourceStream = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
            using (MemoryStream memoryStream = new MemoryStream())
            using (BufferedStream bufferedStream = new BufferedStream(sourceStream))
            {
                byte[] buffer = new byte[4096]; // You can adjust the buffer size as needed

                int bytesRead;
                int totalBytesCopied = 0;

                while ((bytesRead = bufferedStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    memoryStream.Write(buffer, 0, bytesRead);
                    totalBytesCopied += bytesRead;
                }

                File.WriteAllBytes(destinationPath, memoryStream.ToArray());

                return totalBytesCopied;
            }
        }

        /// <summary>
        /// Reads file content encoded with non Unicode encoding.
        /// </summary>
        /// <param name="sourcePath">Path to source file.</param>
        /// <param name="encoding">Encoding name.</param>
        /// <returns>Uncoding file content.</returns>
        /// <exception cref="ArgumentException">Throw if path to source file or encoding string is null or empty.</exception>
        /// <exception cref="FileNotFoundException">Throw if source file doesn't exist.</exception>
        public static string ReadEncodedText(string? sourcePath, string? encoding)
        {
            InputValidation(sourcePath);

            try
            {
                Encoding fileEncoding = Encoding.GetEncoding(encoding);

                using (FileStream fileStream = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
                using (StreamReader streamReader = new StreamReader(fileStream, fileEncoding))
                {
                    return streamReader.ReadToEnd();
                }
            }
            catch (ArgumentException)
            {
                throw new ArgumentException(null, nameof(encoding));
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException(null, sourcePath);
            }
        }

        /// <summary>
        /// Returns decompressed stream from file.
        /// </summary>
        /// <param name="sourcePath">Path to source file.</param>
        /// <param name="method">Method used for compression (none, deflate, gzip).</param>
        /// <returns>Output stream.</returns>
        /// <exception cref="ArgumentException">Throw if path to source file is null or empty.</exception>
        /// <exception cref="FileNotFoundException">Throw if source file doesn't exist.</exception>
        public static Stream DecompressStream(string? sourcePath, DecompressionMethods? method)
        {
            InputValidation(sourcePath);

            Stream decompressedStream;
            Stream sourceStream = File.OpenRead(sourcePath);
            
                if (method == DecompressionMethods.Deflate)
                {
                    decompressedStream = new DeflateStream(sourceStream, CompressionMode.Decompress);
                }
                else if (method == DecompressionMethods.GZip)
                {
                    decompressedStream = new GZipStream(sourceStream, CompressionMode.Decompress);
                }
                else if (method == DecompressionMethods.None)
                {
                    decompressedStream = sourceStream; // No compression, return the original stream.
                }
                else if(method == DecompressionMethods.Brotli)
                {
                    decompressedStream = new BrotliStream(sourceStream, CompressionMode.Decompress);
                }
                else
                {
                    throw new ArgumentException("Unsupported decompression method.", nameof(method));

                }

            return decompressedStream;

            
        }

        /// <summary>
        /// Calculates hash of stream using specified algorithm.
        /// </summary>
        /// <param name="stream">Source stream.</param>
        /// <param name="hashAlgorithmName">
        ///     Hash algorithm ("MD5","SHA1","SHA256" and other supported by .NET).
        /// </param>
        /// <returns>Hash.</returns>
        public static string CalculateHash(this Stream? stream, string? hashAlgorithmName)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream), "Source stream is null.");
            }

            if (string.IsNullOrWhiteSpace(hashAlgorithmName))
            {
                throw new ArgumentException("Hash algorithm name is null or empty.", nameof(hashAlgorithmName));
            }

            using (HashAlgorithm hashAlgorithm = HashAlgorithm.Create(hashAlgorithmName))
            {
                if (hashAlgorithm == null)
                {
                    throw new ArgumentException("Unsupported hash algorithm.", nameof(hashAlgorithmName));
                }

                byte[] hashBytes = hashAlgorithm.ComputeHash(stream);
                return BitConverter.ToString(hashBytes).Replace("-", string.Empty).ToUpper();
            }
        }

        private static void InputValidation(string? sourcePath, string? destinationPath)
        {
            if (string.IsNullOrWhiteSpace(sourcePath))
            {
                throw new ArgumentException($"{nameof(sourcePath)} cannot be null or empty or whitespace.", nameof(sourcePath));
            }

            if (!File.Exists(sourcePath))
            {
                throw new FileNotFoundException($"File '{sourcePath}' not found. Parameter name: {nameof(sourcePath)}.");
            }

            if (string.IsNullOrWhiteSpace(destinationPath))
            {
                throw new ArgumentException($"{nameof(destinationPath)} cannot be null or empty or whitespace", nameof(destinationPath));
            }
        }

        private static void InputValidation(string? sourcePath)
        {
            if (string.IsNullOrWhiteSpace(sourcePath))
            {
                throw new ArgumentException($"{nameof(sourcePath)} cannot be null or empty or whitespace.", nameof(sourcePath));
            }

            if (!File.Exists(sourcePath))
            {
                throw new FileNotFoundException($"File '{sourcePath}' not found. Parameter name: {nameof(sourcePath)}.");
            }
        }
    }
}
