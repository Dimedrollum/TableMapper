using System;

namespace TableMapper
{
	public class Application
	{
		private string[] _args;
		private string _file1;
		private string _file2;

		public Application (string[] args)
		{
			_args = args;
			ValidateArguments ();
			_file1 = args [0];
			_file2 = args [1];
		}

		public void Run()
		{
			try {

				var table1 = new Table(_file1);
				var table2 = new Table(_file2);
				table2.MapValuesFrom(table1);
				table2.Save();

			} catch (Exception ex) {
				Console.Write (ex.Message);
			}
			Console.Write ("Values were successfully mapped from <{0}> to <{1}>", _file1, _file2);
		}

		private void ValidateArguments()
		{
			string message = null;
			if (_args.Length == 0) {
				message = 
					"To run the Application please provide addresses to 2 Coma Separated files.\n" +
				"Files should have 2 coulmns: 1st - Char and 2nd - Integer.\n" +
				"The values will be mapped from 1st table to 2nd.\n" +
				"If key is not distinct in sourse file, the first occurance will be used." +
				"The result will be saved to 2nd file.";
				throw new ApplicationException (message);
			} else if (_args.Length == 1) {
				message = "Please Provide second file in argumets.";
				throw new ApplicationException (message);
			} else if (_args.Length > 2) {
				message = "Only 2 arguments are acceptable.";
				throw new ApplicationException (message);
			}
		}
	}
}

