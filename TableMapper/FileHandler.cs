using System;
using System.IO;
using System.Diagnostics;

namespace TableMapper
{
    /// <summary>
    /// File handler. The abstraction of File Management.
    /// </summary>
    public static class FileHandler
    {
        /// <summary>
        /// Check file for existance and read it to string
        /// </summary>
        /// <returns>The file.</returns>
        /// <param name="fileName">File name.</param>
        public static string ReadFile(string fileName)
        {
            if (!File.Exists(fileName))
                throw new ApplicationException("File does not exist: " + fileName);
            return File.ReadAllText(fileName).Trim();
        }

        /// <summary>
        /// Write string to file
        /// </summary>
        /// <param name="fileName">File name.</param>
        /// <param name="content">Content.</param>
        public static void WriteFile(string fileName, string content)
        {
            Debug.Assert(File.Exists(fileName));
            File.WriteAllText(fileName, content);
        }
    }
}

