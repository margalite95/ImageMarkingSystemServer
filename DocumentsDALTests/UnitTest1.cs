using ImageMarkingDocumentsDAL;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OracleDAL;

namespace DocumentsDALTests
{
    public class Tests
    {
        IConfiguration _configuration;
        [SetUp]
        public void Setup()
        {

            _configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        }

        [Test]
        public void GetDocumentsOkTest()
        {
            var dal = new ImageMarkingDocumentsDALImpl(new InfraDAL(), _configuration);
            var result = dal.GetDocuments("159@gmail.com");
            Assert.IsTrue(result.Tables[0].Rows.Count > 0);
        }


        [Test]
        public void CreateDocument()
        {
            var dal = new ImageMarkingDocumentsDALImpl(new InfraDAL(), _configuration);
            var result = dal.CreateDocuments("159@gmail.com", "https://www.w3schools.com/css/paris.jpg","paris","123456789");
            result = dal.GetDocuments("159@gmail.com");
            Assert.IsTrue(result.Tables[0].Rows.Count > 0);
        }

        [Test]
        public void RemoveDocument()
        {
            var dal = new ImageMarkingDocumentsDALImpl(new InfraDAL(), _configuration);
            var result = dal.RemoveDocument("123456789");
            Assert.AreEqual(0, result.Tables[0].Rows.Count);
        }


    }

}
}