using NUnit.Framework;
using System;
using TableMapper;

namespace TableMapperTests
{
    [TestFixture]
    public class ApplicationTests
    {
        [Test]
        public void ErrorHandling_ProvideInstructions()
        {
            const string expectedMessage = 
                "To run the Application please provide addresses to 2 Coma Separated files.\n" + 
                "Files should have 2 coulmns: 1st - Char and 2nd - Integer.\n" + 
                "The values will be mapped from 1st table to 2nd.\n" + 
                "If key is not distinct in sourse file, the first occurance will be used." + 
                "The result will be saved to 2nd file.";
            var args = new string[] { };

            try
            {
                new Application(args).Run();				
            }
            catch (ApplicationException ex)
            {
                Assert.That(ex.Message, Is.EqualTo(expectedMessage));
            }
        }

        [Test]
        public void ErrorHandling_SecondFileException()
        {
            const string expectedMessage = "Please Provide second file in argumets.";
            var args = new [] { "test" };

            try
            {
                new Application(args).Run();
            }
            catch (ApplicationException ex)
            {
                Assert.That(ex.Message, Is.EqualTo(expectedMessage));
            }

        }

        [Test]
        public void Validate_MoreThan2_Ony2FilesException()
        {
            const string expectedMessage = "Only 2 arguments are acceptable.";
            var args = new [] { "test", "test", "test" };

            try
            {
                new Application(args).Run();
            }
            catch (ApplicationException ex)
            {
                Assert.That(ex.Message, Is.EqualTo(expectedMessage));
            }
        }

        [Test]
        public void ValidArgumetsCostructorTest()
        {
            var args = new [] { "test", "test" };
            var app = new Application(args);
            Assert.That(app, Is.Not.Null);
        }

        [Test]
        public void FileNamesConstuctorTest()
        {
            var app = new Application("file1", "file2");
            Assert.That(app, Is.Not.Null);
        }


    }
}

