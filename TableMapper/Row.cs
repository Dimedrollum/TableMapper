using System;
using System.Linq;

namespace TableMapper
{
    /// <summary>
    /// Row.Represents Rows Char Key and Int Value
    /// </summary>
    public class Row
    {
        public char Key { get; set; }
        public int Value { get; set; }
        string[] _keyValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="TableMapper.Row"/> class.
        /// Creates a row from provided string 
        /// </summary>
        /// <param name="stringRow">String row.</param>
        public Row(string stringRow)
        {
            SplitKeyValues(stringRow);
            ValidateKeyValuesArray();
            Key = ParseKey();
            Value = ParseValue();
        }

        void SplitKeyValues(string stringRow)
        {
            _keyValue = stringRow.Split(',');
        }

        void ValidateKeyValuesArray()
        {
            if (_keyValue.Length != 2)
                throw new ApplicationException("Row in invalid format is detected");
        }

        char ParseKey()
        {
            const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghigklmnopqrstuvwxyz";
            char result;
            try
            {
                result = Char.Parse(_keyValue[0]);
            }
            catch (FormatException)
            {
                throw new ApplicationException("First Element of a Row is not a Char");
            }

            if (!alphabet.Contains(result))
                throw new ApplicationException("First Element of a Row is not an Alfabetic Char");

            return result;
            
        }

        int ParseValue()
        {
            int result;
            try
            {
                result = int.Parse(_keyValue[1]);
            }
            catch (FormatException)
            {
                throw new ApplicationException("Second Element of a Row is not an Integer");
            }

            return result;
        }
    }
}

