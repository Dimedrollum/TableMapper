using NUnit.Framework;
using System;
using TableMapper;

namespace TableMapperTests
{
	[TestFixture]
	public class ApplicationTests
	{
		[Test]
		public void Constructor_0_IsntructionsProvided ()
		{
			var expectedMessage = 
				"To run the Application please provide addresses to 2 Coma Separated files.\n" +
				"Files should have 2 coulmns: 1st - Char and 2nd - Integer.\n" +
				"The values will be mapped from 1st table to 2nd.\n" +
				"If key is not distinct in sourse file, the first occurance will be used." +
				"The result will be saved to 2nd file.";
			var args = new string[] {};

			try {
				new Application (args);				
			} catch (ApplicationException ex) {
				Assert.That (ex.Message, Is.EqualTo (expectedMessage));
			}
		}

		[Test]
		public void Validate_1_SecondFileException ()
		{
			var expectedMessage = "Please Provide second file in argumets.";
			var args = new [] { "test" };

			try {
				new Application(args);
			} catch (ApplicationException ex) {
				Assert.That (ex.Message, Is.EqualTo (expectedMessage));
			}

		}

		[Test]
		public void Validate_MoreThan2_Ony2FilesException ()
		{
			var expectedMessage = "Only 2 arguments are acceptable.";
			var args = new [] { "test", "test", "test" };

			try {
				new Application(args);
			} catch (ApplicationException ex) {
				Assert.That (ex.Message, Is.EqualTo (expectedMessage));
			}
		}

		[Test]
		public void Validate_2_NoException ()
		{
			var args = new [] { "test", "test" };
			new Application (args);
		}


	}
}

