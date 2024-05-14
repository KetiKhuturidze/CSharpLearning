using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace TableOfRecords
{
    /// <summary>
    /// Presents method that write in table form to the text stream a set of elements of type T.
    /// </summary>
    public static class TableOfRecordsCreator
    {
        /// <summary>
        /// Write in table form to the text stream a set of elements of type T (<see cref="ICollection{T}"/>),
        /// where the state of each object of type T is described by public properties that have only build-in
        /// type (int, char, string etc.)
        /// </summary>
        /// <typeparam name="T">Type selector.</typeparam>
        /// <param name="collection">Collection of elements of type T.</param>
        /// <param name="writer">Text stream.</param>
        /// <exception cref="ArgumentNullException">Throw if <paramref name="collection"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Throw if <paramref name="writer"/> is null.</exception>
        /// <exception cref="ArgumentException">Throw if <paramref name="collection"/> is empty.</exception>
        public static void WriteTable<T>(ICollection<T>? collection, TextWriter? writer)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            if (collection.Count == 0)
            {
                throw new ArgumentException("Collection is empty.", nameof(collection));
            }

            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var columnWidths = new Dictionary<PropertyInfo, int>();

            foreach (var property in properties)
            {
                int maxLength = property.Name.Length;

                foreach (var item in collection)
                {
                    var value = property.GetValue(item);
                    if (value != null && value.ToString() !.Length > maxLength)
                    {
                        maxLength = value.ToString() !.Length;
                    }
                }

                columnWidths[property] = maxLength;
            }

            // Write the table header
            WriteLineSeparator(properties, writer, columnWidths);

            foreach (var property in properties)
            {
                var name = property.Name;
                var width = columnWidths[property] + 2;
                writer.Write($"| {name}".PadRight(width) + " ");
            }

            writer.WriteLine("|");
            WriteLineSeparator(properties, writer, columnWidths);

            // Write the table rows
            foreach (var item in collection)
            {
                foreach (var property in properties)
                {
                    var value = property.GetValue(item);
                    var width = columnWidths[property] + 2;
                    string? formattedValue = value != null ? value.ToString() : string.Empty;

                    // Check if the property type is numeric
                    if (IsNumericType(property.PropertyType))
                    {
                        writer.Write($"| {formattedValue!.PadLeft(width - 2)} ");
                    }
                    else
                    {
                        writer.Write($"| {formattedValue!.PadRight(width - 2)} ");
                    }
                }

                writer.WriteLine("|");
                WriteLineSeparator(properties, writer, columnWidths);
            }
        }

        private static bool IsNumericType(Type type)
        {
            return type == typeof(int) || type == typeof(decimal) || type == typeof(double) || type == typeof(float);
        }

        private static void WriteLineSeparator(PropertyInfo[] properties, TextWriter? writer, Dictionary<PropertyInfo, int> columnWidths)
        {
            writer!.Write("+");

            foreach (var property in properties)
            {
                var width = columnWidths[property] + 2;
                writer.Write(new string('-', width) + "+");
            }

            writer.WriteLine();
        }
    }
}