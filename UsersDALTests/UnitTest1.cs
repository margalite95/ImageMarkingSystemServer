using ImageMarkingContract.DTO;
using ImageMarkingUsersDAL;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OracleDAL;
using SignInService;


namespace UsersDALTests
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
        public void SignInOkTest()
        {
            var dal = new ImageMarkingUsersDALImpl(new InfraDAL(), _configuration);
            var result = dal.GetUser("159@gmail.com");
            Assert.IsTrue(result.Tables[0].Rows.Count > 0);
        }

     
        [Test]
        public void CreateUser()
        {
            var dal = new ImageMarkingUsersDALImpl(new InfraDAL(), _configuration);
            var result = dal.CreateUser("111111@gmail.com", "111111");
            result = dal.GetUser("111111@gmail.com");
            Assert.IsTrue(result.Tables[0].Rows.Count > 0);
        }

        [Test]
        public void RemoveUser()
        {
            var dal = new ImageMarkingUsersDALImpl(new InfraDAL(), _configuration);
            var result = dal.UnSubscribeUser("111111@gmail.com");
            result = dal.GetUser("111111@gmail.com");
            Assert.AreEqual(0, result.Tables[0].Rows.Count);
        }


    }
}