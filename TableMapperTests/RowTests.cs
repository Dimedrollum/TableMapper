using NUnit.Framework;
using System;
using TableMapper;
using System.Linq;

namespace TableMapperTests
{
    [TestFixture]
    public class RowTests
    {
        [Test]
        public void ConstuctorError_EmptyString_InvaidFormat()
        {
            const string message = "First Element of a Row is not a Char";
            const string str = "";
            try
            {
                new Row(str);
            }
            catch (ApplicationException ex)
            {
                Assert.That(ex.Message, Is.EqualTo(message));
            }
        }

        [Test]
        public void ConstuctorError_3elements_InvaidFormat()
        {
            const string message = "Row in invalid format is detected";
            const string str = "test,test,test";
            try
            {
                new Row(str);
            }
            catch (ApplicationException ex)
            {
                Assert.That(ex.Message, Is.EqualTo(message));
            }
        }

        [Test]
        public void ConstructorError_Key_NotAChar()
        {
            const string message = "First Element of a Row is not a Char";
            const string str = "test,test";
            try
            {
                new Row(str);
            }
            catch (ApplicationException ex)
            {
                Assert.That(ex.Message, Is.EqualTo(message));
            }
        }

        [Test]
        public void ConstructorError_Key_NotAnAlfabethic()
        {
            const string message = "First Element of a Row is not an Alfabetic Char";
            const string str = "1,test";
            try
            {
                new Row(str);
            }
            catch (ApplicationException ex)
            {
                Assert.That(ex.Message, Is.EqualTo(message));
            }
        }   

        [Test]
        public void ConstructorError_Value_NotAnInt()
        {
            const string message = "Second Element of a Row is not an Integer";
            const string str = "c,test";
            try
            {
                new Row(str);
            }
            catch (ApplicationException ex)
            {
                Assert.That(ex.Message, Is.EqualTo(message));
            }
        }

        [Test]
        public void ConstructorError_2Elements_NormaFlow()
        {
            var row = new Row("a,1");
            Assert.That(row, Is.Not.Null);
            Assert.That(row.Key, Is.EqualTo('a'));
            Assert.That(row.Value, Is.EqualTo(1));
        }

        [Test]
        public void ConstructorError_1Element_NormaFlow()
        {
            var row = new Row("a");
            Assert.That(row, Is.Not.Null);
            Assert.That(row.Key, Is.EqualTo('a'));
        }

    }
}

