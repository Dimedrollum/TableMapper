using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System;

namespace TableMapper
{
    /// <summary>
    /// Represents Table of Key Value Rows.
    /// </summary>
    public class Table
    {
        public List<Row> Rows { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TableMapper.Table"/> class.
        /// Cretes a Table from Plain CSV tests.
        /// </summary>
        /// <param name="fileContent">File content.</param>
        public Table(string fileContent)
        {
            Rows = new List<Row>();
            SplitToRows(fileContent).ForEach(x => Rows.Add(new Row(x)));
        }

        /// <summary>
        /// Maps the Values from provided value by the Keys.
        /// </summary>
        /// <param name="sourseTable">Sourse table.</param>
        public void MapValuesFrom(Table sourseTable)
        {
            try
            {
            
                Rows.ForEach(
                    x => x.Value = sourseTable.Rows.First(
                        y => y.Key.Equals(x.Key)).Value);
            }
            catch (InvalidOperationException)
            {
                throw new ApplicationException("Key not found in source Table");
            }
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents the current <see cref="TableMapper.Table"/>.
        /// </summary>
        /// <returns>A <see cref="System.String"/> that represents the current <see cref="TableMapper.Table"/>.</returns>
        public override string ToString()
        {
            var result = "";
            Rows.ForEach(x => result += x + "\n");
            return result.Trim();
        }

        static List<string> SplitToRows(string content)
        {
            return Regex.Split(content, "\r\n|\r|\n").ToList();
        }
    }
}

