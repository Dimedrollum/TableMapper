using System;
using NUnit.Framework;
using TableMapper;


namespace TableMapperTests
{
    [TestFixture]
    public class FileHandlerTests
    {
        [Test]
        public void ReadFileError_AbsentFile()
        {
            const string fileName = "test";
            const string message = "File does not exist: " + fileName;
            try
            {
                FileHandler.ReadFile(fileName);
            }
            catch (ApplicationException ex)
            {
                Assert.That(ex.Message, Is.EqualTo(message));
            }

        }
    }
}

