using System;
using XmlParser;
using XmlParserTests.TestModels;
using NUnit;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using System.IO;

namespace XmlParserTests
{
    [TestFixture]
    public class Tests
    {
        public IXmlParser xmlParser;

        [TestFixtureSetUp]
        public void Setup()
        {
            xmlParser = new XmlParser.XmlParser();
        }

        [Test]
        public void Deserialize()
        {
            Tuple<Catalog, string> deserilizeResult = DeserializeXml();
            Catalog catalog = deserilizeResult.Item1;
            Assert.NotNull(catalog);
            Assert.NotNull(catalog.BookList);
            Assert.AreEqual(catalog.BookList.Length, 7);

            foreach (Book book in catalog.BookList)
            {
                Assert.NotNull(book.Author);
                Assert.NotNull(book.Description);
                Assert.NotNull(book.Genre);
                Assert.NotNull(book.ID);
                Assert.Greater(book.Price, 0);
                Assert.Greater(book.PublishDate, DateTime.MinValue);
            }
        }

        [Test]
        public void Serialize()
        {
            Tuple<Catalog, string> deserilizeResult = DeserializeXml();
            Catalog origCatalog = deserilizeResult.Item1;
            string origXml = deserilizeResult.Item2;

            string parsedXml = xmlParser.Serialize(origCatalog);
            Catalog parsedCatalog = xmlParser.Deserialize<Catalog>(parsedXml);

            Assert.AreEqual(origCatalog.BookList.Length, parsedCatalog.BookList.Length);

            for (int i = 0; i < origCatalog.BookList.Length; i++)
            {
                Book origBook = origCatalog.BookList[i];
                Book parsedBook = parsedCatalog.BookList[i];

                Assert.AreEqual(origBook.Author,parsedBook.Author);
                Assert.AreEqual(origBook.Description, parsedBook.Description);
                Assert.AreEqual(origBook.Genre, parsedBook.Genre);
                Assert.AreEqual(origBook.ID, parsedBook.ID);
                Assert.AreEqual(origBook.Price, parsedBook.Price);
                Assert.AreEqual(origBook.PublishDate, parsedBook.PublishDate);
                Assert.AreEqual(origBook.Title, parsedBook.Title);
            }
        }

        private Tuple<Catalog,string> DeserializeXml()
        {
            Catalog catalog;
            string xml;
            using (StreamReader reader = new StreamReader(File.Open("TestData\\catalog.xml",FileMode.Open)))
            {
                xml = reader.ReadToEnd();
                catalog = xmlParser.Deserialize<Catalog>(xml);
            }

            return new Tuple<Catalog, string>(catalog, xml);
        }
    }
}