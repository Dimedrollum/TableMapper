using System;
using NUnit.Framework;
using TableMapper;
using System.Linq;

namespace TableMapperTests
{
    [TestFixture]
    public class TableTests
    {
        [Test]
        public void Constructor_1RowTable()
        {
            var table = new Table("A,1");
            Assert.That(table.Rows.Count, Is.EqualTo(1));
        }

        [Test]
        public void Constructor_2RowTable()
        {
            var table = new Table("A,1\nB,2");
            Assert.That(table.Rows.Count, Is.EqualTo(2));
        }

        [Test]
        public void MapValuesFrom_OneValueFound()
        {
            var table1 = new Table("A,1");
            var table2 = new Table("A");

            table2.MapValuesFrom(table1);

            Assert.That(table2.Rows.First().Value, Is.EqualTo(1));
        }

        [Test]
        public void MapValuesFrom_2ValuesFound()
        {
            var table1 = new Table("A,1\nB,2");
            var table2 = new Table("A\nB");

            table2.MapValuesFrom(table1);

            Assert.That(table2.Rows[0].Value, Is.EqualTo(1));
            Assert.That(table2.Rows[1].Value, Is.EqualTo(2));
        }

        [Test]
        public void MapValuesFrom_MultipleKeys_FirstValueMapped()
        {
            var table1 = new Table("A,1\nA,2");
            var table2 = new Table("A");

            table2.MapValuesFrom(table1);

            Assert.That(table2.Rows.First().Value, Is.EqualTo(1));
        }

        [Test]
        public void MapValuesFromError_KeyNotFound()
        {
            var table1 = new Table("A,1");
            var table2 = new Table("B");
            const string message = "Key not found in source Table";

            try
            {
                table2.MapValuesFrom(table1);
            }
            catch (ApplicationException ex)
            {
                Assert.That(ex.Message, Is.EqualTo(message));
            }
        }

        [Test]
        public void ToSting_1Row()
        {
            const string expectedString = "A,1";
            var table1 = new Table(expectedString);
            var result = table1.ToString();

            Assert.That(result, Is.EqualTo(expectedString));
        }

        [Test]
        public void ToSting_2Rows()
        {
            const string expectedString = "A,1\nA,2";
            var table1 = new Table(expectedString);
            var result = table1.ToString();

            Assert.That(result, Is.EqualTo(expectedString));
        }

    }
}

