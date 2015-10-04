using System;

namespace TableMapper
{
    /// <summary>
    /// The Table Mapper application controller.
    /// </summary>
    public class Application
    {
        readonly string[] _args;
        string _file1;
        string _file2;


        /// <summary>
        /// Initializes a new instance of the <see cref="TableMapper.Application"/> class.
        /// The constructor is used for console version of application.
        /// </summary>
        /// <param name="args">Arguments.</param>
        public Application(string[] args)
        {
            _args = args;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TableMapper.Application"/> class.
        /// The constructor is used for UI version of appication
        /// </summary>
        /// <param name="file1">File1. Address to File with full Mapping</param>
        /// <param name="file2">File2. Address to File where values are missing</param>
        public Application(string file1, string file2)
        {
            _file1 = file1;
            _file2 = file2;
        }

        /// <summary>
        /// Run the instance of application.
        /// </summary>
        public void Run()
        {
            try
            {
                if (_file1 == null && _file2 == null)
                    GetFilesFromArgumets();
                var table1 = new Table(FileHandler.ReadFile(_file1));
                var table2 = new Table(FileHandler.ReadFile(_file2));
                table2.MapValuesFrom(table1);
                FileHandler.WriteFile(_file2, table2.ToString());

            }
            catch (ApplicationException ex)
            {
                Console.Write(ex.Message);
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error occured: {0}", ex);
                return;
            }
            Console.Write("Values were successfully mapped from <{0}> to <{1}>", _file1, _file2);
        }

        void GetFilesFromArgumets()
        {
            string message;
            if (_args.Length == 0)
            {
                message = 
					"To run the Application please provide addresses to 2 Coma Separated files.\n" +
                "Files should have 2 coulmns: 1st - Char and 2nd - Integer.\n" +
                "The values will be mapped from 1st table to 2nd.\n" +
                "If key is not distinct in sourse file, the first occurance will be used.\n" +
                "The result will be saved to 2nd file.";
                throw new ApplicationException(message);
            }
            if (_args.Length == 1)
            {
                message = "Please Provide second file in argumets.";
                throw new ApplicationException(message);
            }
            if (_args.Length > 2)
            {
                message = "Only 2 arguments are acceptable.";
                throw new ApplicationException(message);
            }

            _file1 = _args[0];
            _file2 = _args[1];
        }
    }
}

