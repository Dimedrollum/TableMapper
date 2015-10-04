using System;
using System.Linq;

namespace TableMapper
{
    /// <summary>
    /// Ro_keyepresents Rows Char Key _valuent Value
    /// </summary>
    public class Row
    {
        public char Key{ get; }

        public int Value{ get; set; }

        string[] _keyValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="TableMapper.Row"/> class.
        /// Splits string to Key Values pairs.
        /// </summary>
        /// <param name="stringRow">String row.</param>
        public Row(string stringRow)
        {
            SplitKeyValues(stringRow);
            ValidateKeyValuesArray();
            Key = ParseKey();
            if (_keyValue.Length == 2)
                Value = ParseValue();
        }

        void SplitKeyValues(string stringRow)
        {
            _keyValue = stringRow.Split(',');
        }

        void ValidateKeyValuesArray()
        {
            if (_keyValue.Length > 2)
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

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents the current <see cref="TableMapper.Row"/>.
        /// </summary>
        /// <returns>A <see cref="System.String"/> that represents the current <see cref="TableMapper.Row"/>.</returns>
        public override string ToString()
        {
            return string.Format("{0},{1}", Key, Value);
        }
    }
}

